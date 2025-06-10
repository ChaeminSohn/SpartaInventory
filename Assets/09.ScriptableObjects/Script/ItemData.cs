using _02.Scripts.Item;
using _02.Scripts.Player;
using UnityEngine;

namespace _09.ScriptableObjects.Script
{
    public enum ItemType
    {
        None,
        Equipment,  // 장비
        Usable, // 소비
        Etc,        // 기타
        Cash,       // 캐시
    }
    
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
    public class ItemData : ScriptableObject
    {
        [Header("공통 데이터")] 
        public ItemType itemType; // 아이템 종류
        public int itemID; // 아이템 고유 ID
        public string itemName; // 아이템 이름
        public int quantity;    //아이템 보유량
        public int maxStack = 1; // 최대 중첩 개수
        public bool isMultiple; //복수 소지 가능(소비, 기타)
        [Header("장비 데이터")]
        public EquipType equipType;     //장비 종류
        public int healthStat;      
        public int manaStat;
        public int attackStat;
        public int defenseStat;
        public int speedStat;
        public int jumpStat;
        [Header("소비 데이터")]
        public UsableType usableType;
        public StatType statType;       //스탯 종류
        public int healAmount;          //회복량
        public int buffStat;            //버프량
        public float duration;          //버프 지속시간
        [TextArea] 
        public string itemDescription; // 아이템 설명
        public Sprite itemIcon; // 아이템 아이콘
    }
}
