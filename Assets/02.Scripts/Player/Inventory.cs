using System;
using System.Collections.Generic;
using _02.Scripts.Event;
using _02.Scripts.Item;
using _02.Scripts.Util;
using _09.ScriptableObjects.Script;
using UnityEngine;

namespace _02.Scripts.Player
{
    public class Inventory : MonoBehaviour
    {
        private const int MaxSlots = 24;
        public Dictionary<ItemType, InventorySlot[]> ItemSlots = new Dictionary<ItemType, InventorySlot[]>();
        public Dictionary<EquipType, InventorySlot> EquippedItems = new Dictionary<EquipType, InventorySlot>(); //현재 장착중인 아이템 목록
        
        private void Start()
        {
            // 모든 아이템 타입에 대해 인벤토리 슬롯 배열을 생성하고 초기화
            foreach (ItemType type in Enum.GetValues(typeof(ItemType)))
            {
                if(type == ItemType.None) continue;
                
                ItemSlots[type] = new InventorySlot[MaxSlots];
                for (int i = 0; i < MaxSlots; i++)
                {
                    ItemSlots[type][i] = new InventorySlot(); // 각 슬롯을 비어있는 상태로 생성
                }
            }
        }

        public bool AddItem(ItemData itemToAdd, int count = 1)
        {
            InventorySlot[] slots = ItemSlots[itemToAdd.itemType];
            
            
            //겹치기가 가능한 아이템이고, 이미 인벤토리에 같은 아이템이 있는지 확인
            if (itemToAdd.isMultiple)
            {
                for (int i = 0; i < slots.Length; i++)
                {
                    InventorySlot slot = slots[i];
                    // 같은 아이템이 있고, 아직 슬롯에 여유가 있다면
                    if (slot.itemData != null && slot.itemData.itemID == itemToAdd.itemID && slot.quantity < itemToAdd.maxStack)
                    {
                        int spaceLeft = itemToAdd.maxStack - slot.quantity; // 슬롯에 남은 공간
                        int amountToAdd = Mathf.Min(count, spaceLeft);   // 추가할 수량과 남은 공간 중 더 작은 값만큼 추가

                        slot.quantity += amountToAdd;
                        count -= amountToAdd;

                        // 추가할 수량이 모두 소진되었다면 함수 종료
                        if (count <= 0)
                        {
                            EventBus.Raise(new InventoryChangeEvent(itemToAdd.itemType, i));
                            return true;
                        }
                    }
                }
            }

            //남은 아이템을 빈 슬롯에 추가
            for (int i = 0; i < slots.Length; i++)
            {
                InventorySlot slot = slots[i];
                if (slot.itemData != null) continue;
                // 비어있는 슬롯을 찾았다면
                int amountToAdd = Mathf.Min(count, itemToAdd.maxStack);

                slot.itemData = itemToAdd;
                slot.quantity = amountToAdd;
                count -= amountToAdd;

                if (count <= 0)
                {
                    EventBus.Raise(new InventoryChangeEvent(itemToAdd.itemType, i));
                    return true;
                }
            }

            // 모든 과정을 거쳤음에도 count가 남아있다면 인벤토리가 꽉 찬 것
            Debug.LogWarning($"{itemToAdd.itemName}을(를) 추가하지 못했습니다. 인벤토리가 가득 찼습니다.");
            return false;
        }
        
        public void RemoveItem(ItemType itemType, int slotIndex, int count = 1)
        {
            if (slotIndex < 0 || slotIndex >= MaxSlots)
            {
                Debug.LogError("잘못된 슬롯 인덱스입니다: " + slotIndex);
                return;
            }

            InventorySlot slot = ItemSlots[itemType][slotIndex];

            // 슬롯이 비어있으면 아무것도 하지 않음
            if (slot.itemData == null) return;

            // 수량을 감소시킴
            slot.quantity -= count;

            // 수량이 0 이하가 되면 슬롯을 완전히 비움
            if (slot.quantity <= 0)
            {
                slot.itemData = null;
                slot.quantity = 0;
            }
            EventBus.Raise(new InventoryChangeEvent(itemType, slotIndex));
        }

        public void SetEquippedState(int slotIndex, bool isEquipped)
        {
            if (slotIndex < 0 || slotIndex >= MaxSlots) return;

            InventorySlot slot = ItemSlots[ItemType.Equipment][slotIndex];
            if (slot.itemData != null)
            {
                slot.isEquipped = isEquipped;
                // 상태 변경 후, 해당 슬롯 UI가 갱신되도록 이벤트 발생.
                EventBus.Raise(new InventoryChangeEvent(ItemType.Equipment, slotIndex));
            }
        }
        
        public int FindEquippedSlotIndex(ItemData itemToFind)
        {
            if (itemToFind == null) return -1;
    
            ItemType type = itemToFind.itemType;
            InventorySlot[] slots = ItemSlots[type];

            for (int i = 0; i < slots.Length; i++)
            {
                // 조건을 추가합니다: 아이템 데이터가 같고, isEquipped가 true인가?
                if (slots[i].itemData == itemToFind && slots[i].isEquipped == true)
                {
                    return i; // 두 조건 모두 만족하는 슬롯을 찾았으므로 인덱스 반환
                }
            }

            // 장착된 아이템을 찾지 못함
            return -1;
        }
    }
    
    [System.Serializable] // 이 줄을 추가하면 유니티 인스펙터에서 볼 수 있습니다 (디버깅용).
    public class InventorySlot
    {
        public int slotIndex;
        public ItemData itemData; // 아이템 원본 데이터 (어떤 아이템인가?)
        public int quantity;      // 이 슬롯에 들어있는 개수 (몇 개인가?)
        public bool isEquipped = false;     //장착 여부(장비 아이템)

        // 슬롯이 비어있을 때를 위한 기본 생성자
        public InventorySlot()
        {
            itemData = null;
            quantity = 0;
        }
    }
}
