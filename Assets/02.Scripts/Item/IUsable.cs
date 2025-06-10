using UnityEngine;

namespace _02.Scripts.Item
{
    public enum UsableType
    {
        None,
        Heal,       //회복(체력, 마나)
        Buff,       //버프
        Upgrade,    //강화 
    }
    
    public interface IUsable 
    {
        void Use(GameObject target);
    }
}
