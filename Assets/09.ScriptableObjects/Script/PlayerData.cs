using System.ComponentModel;
using UnityEngine;
using UnityEngine.Serialization;
using System.ComponentModel;


namespace _09.ScriptableObjects.Script
{
    public enum ClassType
    {
        [Description("없음")]
        None,
        [Description("전사")]
        Warrior,        //전사
        [Description("마법사")]
        Mage,           //마법사
        [Description("궁수")]
        Archer,         //궁수
        [Description("도적")]
        Thief,          //도적
    }
    
    
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public string name;         //이름
        public ClassType classType; //직업
        public int level;           //레벨
        public int currentExp;      //현재 경험치
        public int expThreshold;    //레벨업까지 필요한 경험치
        public string guild;        //길드
        public int fame;            //인기도
        public int gold;            //골드
        public string description;  //설명

        public int baseHealth;
        public int baseMana;
        public int baseAttack;
        public int baseDefense;
        public int baseSpeed;
        public int baseJump;
    }
}
