using System;
using _02.Scripts.Item;
using _09.ScriptableObjects.Script;
using UnityEditor;
using UnityEngine;

namespace _02.Scripts.Editor
{
    public class ItemCreator : EditorWindow
    {
        private string itemName = "New Item";
        private ItemType itemType = ItemType.None;
        private EquipType equipType = EquipType.None;
        private UsableType usableType = UsableType.None;
        private int quantity = 1;
        private bool isMultiple = false;

        [MenuItem("Window/Item Creator")]
        private static void ShowWindow()
        {
            GetWindow<ItemCreator>("아이템 생성기");
        }

        private void OnGUI()
        {
            itemName = EditorGUILayout.TextField("아이템 명", itemName);
            itemType = (ItemType)EditorGUILayout.EnumPopup("아이템 종류", itemType);
            equipType = (EquipType)EditorGUILayout.EnumPopup("장비 종류", equipType);
            usableType = (UsableType)EditorGUILayout.EnumPopup("소비 종류", usableType);
            quantity = EditorGUILayout.IntField("수량", quantity);
            isMultiple = EditorGUILayout.Toggle("복수 보유", isMultiple);

            if(GUILayout.Button("아이템 생성"))
            {
                
                ItemData data = ScriptableObject.CreateInstance<ItemData>();
                data.itemName = itemName;
                data.itemType = itemType;
                data.quantity = quantity;
                data.isMultiple = isMultiple;
                data.equipType = equipType;
                data.usableType = usableType;   
                AssetDatabase.CreateAsset(data, $"Assets/09.ScriptableObjects/Data/ItemData/{itemName}.asset");
                AssetDatabase.SaveAssets();
            }
        }
    }
}
