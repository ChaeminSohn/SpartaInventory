using _02.Scripts.Manager;
using _02.Scripts.Util;
using _09.ScriptableObjects.Script;
using TMPro;
using UnityEngine.UI;

namespace _02.Scripts.UI
{
    public class MainWindow : BaseWindow
    {
        public Button inventoryButton;
        public Button equipmentButton;
        public Button statusButton;

        public TextMeshProUGUI classText;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI levelText;
        public TextMeshProUGUI expText;
        public TextMeshProUGUI descriptionText;

        private PlayerData data;
        public override UIType UIType => UIType.MainWindow;

        public override void OnOpen()
        {
            if (data == null)
            {
                data = GameManager.Instance.PlayerStat.playerData;
            }
            
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
            
            InitUi();
        }

        public override void OnClose()
        {
            inventoryButton.onClick.RemoveAllListeners();
            equipmentButton.onClick.RemoveAllListeners();
            statusButton.onClick.RemoveAllListeners();
        }
        
        private void InitUi()
        {
            classText.text = data.classType.GetDescription();
            nameText.text = data.name;
            levelText.text = data.level.ToString();
            expText.text = $"{data.currentExp} / {data.expThreshold}";
            descriptionText.text = data.description;
        }
    }
    
   
}
