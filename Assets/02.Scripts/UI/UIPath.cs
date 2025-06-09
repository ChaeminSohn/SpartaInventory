using System.Collections.Generic;
using UnityEngine;

namespace _02.Scripts.UI
{
    public class UIPath : MonoBehaviour
    {
        private static readonly Dictionary<UIType, string> pathTable = new()
        {
            { UIType.MainWindow, "UI/WindowUI/MainWindow" },
            { UIType.InventoryWindow, "UI/WindowUI/InventoryWindow" },
            { UIType.EquipWindow, "UI/WindowUI/EquipWindow" },
            { UIType.StatWindow, "UI/WindowUI/StatWindow" },
            { UIType.ConfirmPopup, "UI/PopupUI/ConfirmPopup" },
            { UIType.ToastMessage, "UI/FixedUI/ToastMessage" },
        };

        public static string GetPath(UIType type) => pathTable[type];
    }
}
