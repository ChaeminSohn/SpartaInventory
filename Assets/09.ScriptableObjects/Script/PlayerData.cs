using UnityEngine;
using UnityEngine.Serialization;

namespace _09.ScriptableObjects.Script
{
    public enum ClassType
    {
        None,
        Warrior,        //전사
        Mage,           //마법사
        Archer,         //궁수
        Rogue,          //도적
    }
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public string name;         //이름
        public ClassType classType; //직업
        public int level;           //레벨
        public int currentExp;      //현재 경험치
        public int expThreshold;    //레벨업까지 필요한 경험치
        public int gold;            //골드

        public int baseHealth;
        public int baseMana;
        public int baseAttack;
        public int baseDefense;
        public int baseSpeed;
        public int baseJump;
    }
}
