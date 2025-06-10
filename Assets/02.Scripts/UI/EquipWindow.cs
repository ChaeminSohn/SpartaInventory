using System.Collections.Generic;
using _02.Scripts.Item;
using UnityEngine;
using UnityEngine.UI;

namespace _02.Scripts.UI
{
    public class EquipWindow : BaseWindow
    {
        public Button closeButton;
        public Dictionary<EquipType, EquipSlotUI> equipSlots = new Dictionary<EquipType, EquipSlotUI>(); 
        public override UIType UIType => UIType.EquipWindow;
    
        public override void OnOpen()
        {
            closeButton.onClick.AddListener(() =>
            {
                UIManager.Instance.CloseWindow(UIType.EquipWindow);
            });
        }

        public override void OnClose()
        {
            closeButton.onClick.RemoveAllListeners();
        }
    }
}
