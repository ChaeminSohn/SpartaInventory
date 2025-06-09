using UnityEngine.UI;

namespace _02.Scripts.UI
{
    public class MainWindow : BaseWindow
    {
        public Text headerText;
        public Button inventoryButton;
        public Button statButton;
        public override UIType UIType => UIType.MainWindow;

        public override void OnOpen()
        {
            inventoryButton.onClick.RemoveAllListeners();
            inventoryButton.onClick.AddListener(() =>
            {
                UIManager.Instance.OpenWindow((UIType.InventoryWindow));
            });
        }
    }
}
