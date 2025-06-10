using UnityEngine;
using UnityEngine.Serialization;

namespace _09.ScriptableObjects.Script
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public string id;
        public int level;
        public int gold;
        

    }
}
