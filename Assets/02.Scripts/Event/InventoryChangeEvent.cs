using _09.ScriptableObjects.Script;

namespace _02.Scripts.Event
{
    public struct InventoryChangeEvent
    {
        public ItemType ItemType { get; private set; }
        public int SlotIndex{ get; private set; }

        public InventoryChangeEvent(ItemType itemType, int slotIndex)
        {
            this.ItemType = itemType;
            this.SlotIndex = slotIndex;
        }
    }
}