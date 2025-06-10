using UnityEngine.UI;

namespace _02.Scripts.UI
{
    public class InventoryWindow : BaseWindow
    {
        public Button closeButton;
        public Button EquipCategoryButton;
        public Button UsableCategoryButton;
        public Button OtherCategoryButton;
        public Button CashCategoryButton;

        public InventorySlot[] slots;    
        public override UIType UIType => UIType.InventoryWindow;

        public override void OnOpen()
        {
            closeButton.onClick.AddListener(() =>
            {
                UIManager.Instance.CloseWindow(UIType.InventoryWindow);
            });
        }
    }
}
