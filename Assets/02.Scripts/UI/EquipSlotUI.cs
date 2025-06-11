using _02.Scripts.Item;
using _09.ScriptableObjects.Script;
using UnityEngine;
using UnityEngine.UI;

namespace _02.Scripts.UI
{
    public class EquipSlotUI : MonoBehaviour
    {
        public Image itemIcon;
        public EquipType equipType;

        public void UpdateSlot(EquipmentItem item)
        {
            if (item == null)
            {
                itemIcon.enabled = false;
                return;
            }

            itemIcon.sprite = item.ItemData.itemIcon;
            itemIcon.enabled = item.IsEquipped;
        }
    }
}
