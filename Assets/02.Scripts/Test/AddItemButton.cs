using System;
using _02.Scripts.Manager;
using _02.Scripts.Player;
using _09.ScriptableObjects.Script;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _02.Scripts.Test
{
    public class AddItemButton : MonoBehaviour
    {
        public Inventory Inventory;
        public ItemType ItemType;
        public ItemData[] ItemDatas;

        private void Start()
        {
            Inventory = GameManager.Instance.inventory;

            ItemDatas = Resources.LoadAll<ItemData>($"Data/ItemData/{ItemType}");
        }

        public void OnClick()
        {
            int i = Random.Range(0, ItemDatas.Length);  
            Inventory.AddItem(ItemDatas[i], 1);
        }
    }
}
