using UnityEngine.UI;

namespace _02.Scripts.UI
{
    public class StatWindow : BaseWindow
    {
        public Button closeButton;
        public override UIType UIType => UIType.StatWindow;
    
        public override void OnOpen()
        {
            closeButton.onClick.AddListener(() =>
            {
                UIManager.Instance.CloseWindow(UIType.StatWindow);
            });
        }

        public override void OnClose()
        {
            closeButton.onClick.RemoveAllListeners();
        }
    }
}
