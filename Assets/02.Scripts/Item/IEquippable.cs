using _02.Scripts.Manager;

namespace _02.Scripts.Item
{
    public enum EquipType
    {
        None,
        Weapon,         //무기
        SubWeapon,      //보조무기
        Head,           //머리
        Armor,          //몸
        Pants,          //바지
        Shoe,            //신발
        Glove,          //장갑
        Belt,           //벨트
        Cape,           //망토
        Emblem,         //엠블렘
        Ring,           //반지
        Pendant,       //팬던트
        ForeHead,       //얼굴장식
        EyeAcc,         //눈장식
        EarAcc,        //귀걸이
        Shoulder,       //어깨장식
        Badge,          //뱃지
        Medal,          //훈장
        Pocket,         //포켓 
        Android,        //안드로이드
        Heart,          //기계심장
    }
    public interface IEquippable
    {
        void Equip(EquipmentManager manager, int slotIndex);
        void Unequip(EquipmentManager manager);
    }
}


