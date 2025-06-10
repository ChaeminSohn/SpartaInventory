namespace _02.Scripts.Item
{
    public enum EquipType
    {
        None,
        Weapon,         //무기
        SubWeapon,      //보조무기
        Head,           //머리
        Armor,          //몸
        Shoe,            //신발
        Glove,          //장갑
        Belt,           //벨트
        Cape,           //망토
        Ring,           //반지
        Necklace,       //목걸이
    }
    public interface IEquippable
    {
        void Equip();
        void UnEquip();
    }
}


