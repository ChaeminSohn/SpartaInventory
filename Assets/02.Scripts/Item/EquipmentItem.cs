using _02.Scripts.Manager;
using _09.ScriptableObjects.Script;
using UnityEngine;

namespace _02.Scripts.Item
{
    public class EquipmentItem : IEquippable
    {
        public ItemData ItemData;

        public EquipmentItem(ItemData itemData)
        {
            this.ItemData = itemData;
        }
        
        public void Equip(EquipmentManager manager, int slotIndex)
        {
            // 장비 장착 로직 구현
            manager.Equip(this, slotIndex);
        }

        public void Unequip(EquipmentManager manager)
        {
            // 장비 해제 로직 구현
          
            manager.Unequip(this);
        }
    }
}
