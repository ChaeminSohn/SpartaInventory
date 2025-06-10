using _02.Scripts.UI;
using _02.Scripts.Util;

namespace _02.Scripts.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private void Start()
        {
            UIManager.Instance.OpenWindow(UIType.MainWindow);
        }
    }
}
