using _02.Scripts.Item;

namespace _02.Scripts.Event
{
    public struct EquipmentChangeEvent
    {
        public EquipType EquipType{ get; private set; }
        public EquipmentItem Equipment{ get; private set; }

        public EquipmentChangeEvent(EquipType equipType, EquipmentItem equipment)
        {
            this.EquipType = equipType;
            this.Equipment = equipment;
        }
    }
}