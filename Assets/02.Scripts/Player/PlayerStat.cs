using System;
using _02.Scripts.Event;
using _02.Scripts.Item;
using _02.Scripts.Util;
using _09.ScriptableObjects.Script;
using UnityEngine;

namespace _02.Scripts.Player
{
    public enum StatType
    {
        None,
        Health,     //최대 체력
        Mana,       //최대 마나
        Attack,     //공격력
        Defense,    //방어력
        Speed,      //이동속도
        Jump,       //점프력
    }
    public class PlayerStat : MonoBehaviour
    {
        public PlayerData playerData;
        public int TotalHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public int TotalMana { get; private set; }
        public int CurrentMana { get; private set; }
        public int TotalAttack { get; private set; }
        public int TotalDefense { get; private set; }
        public int TotalSpeed { get; private set; }
        public int TotalJump { get; private set; }

        public Action StatChangeEvent;
        
        private void Awake()
        {
            if (!playerData)
            {
                Debug.LogWarning(this.name + "플레이어 데이터 없음");
                return;
            }

            TotalHealth = playerData.baseHealth;
            CurrentHealth = TotalHealth;
            TotalMana = playerData.baseMana;
            CurrentMana = TotalMana;
            TotalAttack = playerData.baseAttack;
            TotalDefense = playerData.baseDefense;
            TotalSpeed = playerData.baseSpeed;
            TotalJump = playerData.baseJump;
        }
        
        public void AddStatModifiers(EquipmentItem equipment)
        {
            TotalHealth += equipment.ItemData.healthStat;
            TotalMana += equipment.ItemData.manaStat;
            TotalAttack += equipment.ItemData.attackStat;
            TotalDefense += equipment.ItemData.defenseStat;
            TotalSpeed += equipment.ItemData.speedStat;
            TotalJump += equipment.ItemData.jumpStat;
            StatChangeEvent?.Invoke();
        }

        public void RemoveStatModifiers(EquipmentItem equipment)
        {
            TotalHealth -= equipment.ItemData.healthStat;
            TotalMana -= equipment.ItemData.manaStat;
            TotalAttack -= equipment.ItemData.attackStat;
            TotalDefense -= equipment.ItemData.defenseStat;
            TotalSpeed -= equipment.ItemData.speedStat;
            TotalJump -= equipment.ItemData.jumpStat;
            StatChangeEvent?.Invoke();
        }
    }
}