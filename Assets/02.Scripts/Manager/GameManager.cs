using _02.Scripts.Player;
using _02.Scripts.UI;
using _02.Scripts.Util;
using UnityEngine;

namespace _02.Scripts.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public GameObject Player;
        public Inventory inventory;
        private void Start()
        {
            UIManager.Instance.OpenWindow(UIType.MainWindow);
        }
    }
}
