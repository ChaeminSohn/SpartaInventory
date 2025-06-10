using System;
using System.Collections.Generic;
using _02.Scripts.Event;
using _02.Scripts.Item;
using _02.Scripts.Player;
using _02.Scripts.Util;
using _09.ScriptableObjects.Script;
using UnityEngine;

namespace _02.Scripts.Manager
{
    public class EquipmentManager : Singleton<EquipmentManager>
    {
        private Dictionary<EquipType, EquipmentItem> equippedItems = new Dictionary<EquipType, EquipmentItem>();

        [Header("연결 필요한 컴포넌트")] [SerializeField]
        private PlayerStat playerStats; // 플레이어의 스탯을 관리하는 컴포넌트

        [SerializeField] private Inventory inventory; // 플레이어의 인벤토리 관리 컴포넌트

        public void Equip(EquipmentItem newItem, int slotIndex)
        {
            if (newItem == null) return;

            EquipType type = newItem.ItemData.equipType;
            EquipmentItem oldItem = null;

            //같은 부위에 이미 다른 아이템이 장착되어 있는지 확인
            if (equippedItems.TryGetValue(type, out oldItem))
            {
                //기존 아이템이 있었다면, 해당 아이템의 스탯을 플레이어에게서 제거
                playerStats.RemoveStatModifiers(oldItem);
                
                //해제된 아이템의 원래 인벤토리 슬롯을 찾아 '장착 해제' 상태로 변경
                int oldItemSlotIndex = inventory.FindEquippedSlotIndex(oldItem.ItemData);
                if(oldItemSlotIndex != -1)
                {   
                    inventory.SetEquippedState(oldItemSlotIndex, false);
                }
            }

            //새로운 아이템을 장착 딕셔너리에 등록
            equippedItems[type] = newItem;

            //새로운 아이템의 스탯을 플레이어에게 적용
            playerStats.AddStatModifiers(newItem);
            
            inventory.SetEquippedState(slotIndex, true);
            
            //장비가 변경되었음을 모든 구독자(UI 등)에게 알림
            EventBus.Raise(new EquipmentChangeEvent(type, newItem));
            
        }

        public void Unequip(EquipmentItem equipment)
        {
            EquipType type = equipment.ItemData.equipType;
            
            if (!equippedItems.TryGetValue(type, out EquipmentItem oldItem)) return;
            // 장착 딕셔너리에서 아이템 제거
            equippedItems.Remove(type);

            //아이템의 스탯을 플레이어에게서 제거
            playerStats.RemoveStatModifiers(oldItem);
            
            // 해제된 아이템의 원래 인벤토리 슬롯을 찾아 '장착 해제' 상태로 변경
            int oldItemSlotIndex = inventory.FindEquippedSlotIndex(oldItem.ItemData);
            if(oldItemSlotIndex != -1)
            {
                inventory.SetEquippedState(oldItemSlotIndex, false);
            }

            //장비가 해제되었음을 모든 구독자에게 알림 
            EventBus.Raise(new EquipmentChangeEvent(type, equipment));
        }

        /// 특정 부위에 장착된 아이템 데이터를 반환하는 메소드 (UI 표시용)
        public EquipmentItem GetEquippedItem(EquipType type)
        {
            equippedItems.TryGetValue(type, out EquipmentItem item);
            return item;
        }
    }
}
