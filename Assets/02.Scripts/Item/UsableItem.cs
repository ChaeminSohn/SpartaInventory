using _09.ScriptableObjects.Script;
using UnityEngine;

namespace _02.Scripts.Item
{
    public class UsableItem : IUsable
    {
    public ItemData ItemData;
        
        public UsableItem(ItemData itemData)
        {
            this.ItemData = itemData;
        }
        public void Use(GameObject target)
        {
            
        }
    }
}
