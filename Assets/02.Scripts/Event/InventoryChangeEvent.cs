using _09.ScriptableObjects.Script;

namespace _02.Scripts.Event
{
    public struct InventoryChangeEvent
    {
        public ItemType ItemType;
        public int SlotIndex;

        public InventoryChangeEvent(ItemType itemType, int slotIndex)
        {
            this.ItemType = itemType;
            this.SlotIndex = slotIndex;
        }
    }
}