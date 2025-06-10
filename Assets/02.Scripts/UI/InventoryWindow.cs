using System;
using System.Collections.Generic;
using _02.Scripts.Event;
using _02.Scripts.Item;
using _02.Scripts.Manager;
using _02.Scripts.Player;
using _02.Scripts.Util;
using _09.ScriptableObjects.Script;
using UnityEngine;
using UnityEngine.UI;

namespace _02.Scripts.UI
{
    public class InventoryWindow : BaseWindow
    {
        private Inventory inventory;
        
        public Button closeButton;
        public Button EquipCategoryButton;
        public Button UsableCategoryButton;
        public Button OtherCategoryButton;
        public Button CashCategoryButton;

        public InventorySlotUI[] slots;
        private ItemType currentCategory = ItemType.Equipment;
        public override UIType UIType => UIType.InventoryWindow;

        private void Start()
        {
            for(int i = 0; i < slots.Length; i++)
            {
                slots[i].Initialize(this, i );
            }
        }

        public override void OnOpen()
        {
            inventory = GameManager.Instance.inventory;
            
            closeButton.onClick.AddListener(() =>
            {
                UIManager.Instance.CloseWindow(UIType.InventoryWindow);
            });
            EquipCategoryButton.onClick.AddListener(() =>
            {
                ChangeCategory(ItemType.Equipment);
            });
            UsableCategoryButton.onClick.AddListener(() =>
            {
                ChangeCategory(ItemType.Usable);
            });
            OtherCategoryButton.onClick.AddListener(() =>
            {
                ChangeCategory(ItemType.Etc);
            });
            CashCategoryButton.onClick.AddListener(() =>
            {
                ChangeCategory(ItemType.Cash);
            });
            EventBus.Subscribe<InventoryChangeEvent>(OnInventoryChangeEventHandler);
            
            ChangeCategory(ItemType.Equipment);
        }

        public override void OnClose()
        {
            closeButton.onClick.RemoveAllListeners();
            EquipCategoryButton.onClick.RemoveAllListeners();
            UsableCategoryButton.onClick.RemoveAllListeners();
            OtherCategoryButton.onClick.RemoveAllListeners();
            CashCategoryButton.onClick.RemoveAllListeners();
            EventBus.UnSubscribe<InventoryChangeEvent>(OnInventoryChangeEventHandler);
        }

        private void ChangeCategory(ItemType type)
        {
            currentCategory = type;

            InventorySlot[] datas = inventory.ItemSlots[type];

            for (int i = 0; i < datas.Length; i++)
            {
                slots[i].UpdateSlot(datas[i]);
            }
        }

        public void OnSlotClicked(int slotIndex)
        {
            InventorySlot slotData = inventory.ItemSlots[currentCategory][slotIndex];

            if (slotData == null || slotData.itemData == null)
            {
                Debug.Log("빈 슬롯이 클릭되었습니다.");
                return;
            }

            ItemData data = slotData.itemData;
            Debug.Log($"{data.itemName} 아이템이 클릭되었습니다.");

            switch (data.itemType)
            {
                case ItemType.Equipment:
                    //장비 타입이라면, Equipment 행동 객체를 생성
                    EquipmentItem equipment = new EquipmentItem(data);
                    equipment.Equip(EquipmentManager.Instance, slotIndex);
                    //slotData.isEquipped = !slotData.isEquipped;
                    Debug.Log($"{data.itemName}을(를) 장착했습니다.");
                    break;

                case ItemType.Usable:
                    //소비 타입이라면, UsableItem 행동 객체를 생성
                    UsableItem usableItem = new UsableItem(data);
                    usableItem.Use(GameManager.Instance.Player); 
            
                    // 아이템을 사용했으니 인벤토리에서 1개 제거
                    inventory.RemoveItem(currentCategory, slotIndex, 1);
                    Debug.Log($"{data.itemName}을(를) 사용했습니다.");
                    break;

                case ItemType.Etc:
                case ItemType.Cash:
                default:
                    // 기타, 캐시 아이템 등은 사용/장착 불가
                    Debug.Log($"{data.itemName}은(는) 사용할 수 없는 아이템입니다.");
                    break;
            }
            slots[slotIndex].UpdateSlot(slotData);
        }

        private void OnInventoryChangeEventHandler(InventoryChangeEvent args)
        {   
            //현재 카테고리에 해당하는 아이템이 아니면 인벤토리를 업데이트 할 필요 없음
            if (currentCategory != args.ItemType) return;     
            slots[args.SlotIndex].UpdateSlot(inventory.ItemSlots[args.ItemType][args.SlotIndex]);
        }
    }
}
