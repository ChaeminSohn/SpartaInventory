using System;
using _02.Scripts.Item;
using _02.Scripts.Player;
using _09.ScriptableObjects.Script;
using UnityEditor;
using UnityEngine;

namespace _02.Scripts.Editor
{
    public class ItemCreator : EditorWindow
    {
        private string itemName = "New Item";
        private ItemType itemType = ItemType.None;
        private int quantity = 1;
        private int maxStack = 1;
        private bool isMultiple = false;
        private Sprite itemImage;
        
        private EquipType itemEquipType;
        private int itemHealth;
        private int itemMana;
        private int itemAttack;
        private int itemDefense;
        private int itemSpeed;
        private int itemJump;
        
        private UsableType itemUsableType;
        private StatType itemStatType;
        private int itemHealAmount;
        private int itemBuffAmount;
        private float itemBuffDuration;

        [MenuItem("Window/Item Creator")]
        private static void ShowWindow()
        {
            GetWindow<ItemCreator>("아이템 생성기");
        }

        private void OnGUI()
        {
            itemName = EditorGUILayout.TextField("아이템 명", itemName);
            itemType = (ItemType)EditorGUILayout.EnumPopup("아이템 종류", itemType);
            quantity = EditorGUILayout.IntField("수량", quantity);
            maxStack = EditorGUILayout.IntField("최대 보유 개수", maxStack);
            isMultiple = EditorGUILayout.Toggle("복수 보유", isMultiple);
            itemImage = (Sprite)EditorGUILayout.ObjectField("아이템 아이콘", 
                itemImage, typeof(Sprite), false);
            
            EditorGUILayout.HelpBox("장비 아이템 설정", MessageType.Info);
            itemEquipType = (EquipType)EditorGUILayout.EnumPopup("장비 종류", itemEquipType);
            itemHealth = EditorGUILayout.IntField("최대 체력", itemHealth);
            itemMana = EditorGUILayout.IntField("최대 마나", itemMana);
            itemAttack = EditorGUILayout.IntField(("공격력"), itemAttack);
            itemDefense = EditorGUILayout.IntField("방어력", itemDefense);
            itemSpeed = EditorGUILayout.IntField("이동 속도", itemSpeed);
            itemJump = EditorGUILayout.IntField("점프력", itemJump);
            
            EditorGUILayout.HelpBox("소비 아이템 설정", MessageType.Info);
            itemUsableType = (UsableType)EditorGUILayout.EnumPopup("소비 종류", itemUsableType);
            itemStatType = (StatType)EditorGUILayout.EnumPopup("회복/버프 스탯 종류", itemStatType);   
            itemHealAmount = EditorGUILayout.IntField("회복 수치", itemHealAmount);
            itemBuffAmount = EditorGUILayout.IntField("버프 수치", itemBuffAmount);
            itemBuffDuration = EditorGUILayout.FloatField("버프 지속시간", itemBuffDuration);
            
            if(GUILayout.Button("아이템 생성"))
            {
                ItemData data = ScriptableObject.CreateInstance<ItemData>();
                data.itemName = itemName;
                data.itemType = itemType;
                data.quantity = quantity;
                data.maxStack = maxStack;
                data.isMultiple = isMultiple;
                data.equipType = itemEquipType;
                data.healthStat = itemHealth;
                data.manaStat = itemMana;
                data.attackStat = itemAttack;
                data.defenseStat = itemDefense;
                data.speedStat = itemSpeed;
                data.jumpStat = itemJump;
                data.statType = itemStatType;
                data.healAmount = itemHealAmount;
                data.buffStat = itemBuffAmount;
                data.duration = itemBuffDuration;
                data.usableType = itemUsableType;   
                data.itemIcon = itemImage; AssetDatabase.CreateAsset(data, $"Assets/09.ScriptableObjects/Data/ItemData/{itemName}.asset");
                AssetDatabase.SaveAssets();
            }
        }
    }
    
}
