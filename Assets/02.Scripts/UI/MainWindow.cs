using UnityEngine.UI;

namespace _02.Scripts.UI
{
    public class MainWindow : BaseWindow
    {
        public Text headerText;
        public Button inventoryButton;
        public Button equipmentButton;
        public Button statusButton;
        public override UIType UIType => UIType.MainWindow;

        public override void OnOpen()
        {
            inventoryButton.onClick.AddListener(() =>
            {
                UIManager.Instance.OpenWindow((UIType.InventoryWindow));
            });
            equipmentButton.onClick.AddListener(() =>
            {
                UIManager.Instance.OpenWindow((UIType.EquipWindow));
            });
            statusButton.onClick.AddListener(() =>
            {
                UIManager.Instance.OpenWindow((UIType.StatWindow));
            });
        }

        public override void OnClose()
        {
            inventoryButton.onClick.RemoveAllListeners();
            equipmentButton.onClick.RemoveAllListeners();
            statusButton.onClick.RemoveAllListeners();
        }
    }
}
