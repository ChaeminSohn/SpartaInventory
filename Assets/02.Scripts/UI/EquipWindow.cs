using System.Collections.Generic;
using _02.Scripts.Event;
using _02.Scripts.Item;
using _02.Scripts.Manager;
using _02.Scripts.Util;
using UnityEngine.UI;

namespace _02.Scripts.UI
{
    public class EquipWindow : BaseWindow
    {
        public Button closeButton;
        public EquipSlotUI[] slots;
        public Dictionary<EquipType, EquipSlotUI> equipSlots = new Dictionary<EquipType, EquipSlotUI>(); 
        public override UIType UIType => UIType.EquipWindow;

        private void Start()
        {
            foreach (EquipSlotUI slot in slots )
            {
                equipSlots[slot.equipType] = slot;  //반지같이 복수 착용 가능한 부위는 어떡하지...?
            }
        }

        public override void OnOpen()
        {
            closeButton.onClick.AddListener(() =>
            {
                UIManager.Instance.CloseWindow(UIType.EquipWindow);
            });
            EventBus.Subscribe<EquipmentChangeEvent>(EquipmentChangedHandler);
            UpdateAllSlots();
            
        }

        public override void OnClose()
        {
            closeButton.onClick.RemoveAllListeners();
            EventBus.UnSubscribe<EquipmentChangeEvent>(EquipmentChangedHandler);
        }
        
        //현재 장착 정부를 바탕으로 모든 장비 슬롯 타입을 순회,업데이트
        private void UpdateAllSlots()
        {
            foreach (var equipSlotPair in equipSlots)
            {
                EquipType type = equipSlotPair.Key;
                EquipSlotUI slotUI = equipSlotPair.Value;
                
                EquipmentItem equippedItem = EquipmentManager.Instance.GetEquippedItem(type);
                
                slotUI.UpdateSlot(equippedItem);
            }
        }
        
        private void EquipmentChangedHandler(EquipmentChangeEvent args)
        {
            if (equipSlots.TryGetValue(args.EquipType, out EquipSlotUI slotUI))
            {
                slotUI.UpdateSlot(args.Equipment);
            }
        }
    }
}
