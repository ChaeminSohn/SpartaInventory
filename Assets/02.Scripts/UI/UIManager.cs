using System.Collections.Generic;
using System.Linq;
using _02.Scripts.Util;
using UnityEngine;

namespace _02.Scripts.UI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private Transform fixedRoot;
        [SerializeField] private Transform windowRoot;
        [SerializeField] private Transform popupRoot;

        private readonly Dictionary<UIType, BaseWindow> activeWindows = new();
        private readonly Stack<BasePopup> popupStack = new();
        private readonly List<BaseFixed> fixedUIs = new();

        private UIPool pool = new();

        public BaseFixed OpenFixedUI(UIType type, OpenParam param = null)
        {
            var ui = (BaseFixed)pool.GetUI(type, fixedRoot);
            ui.OnOpen(param);
            fixedUIs.Add(ui);
            ui.gameObject.SetActive((true));
            return ui;
        }

        public BaseWindow OpenWindow(UIType type, OpenParam param = null)
        {
            if (activeWindows.ContainsKey(type)) return activeWindows[type];

            var window = (BaseWindow)pool.GetUI(type, windowRoot);
            window.OnOpen(param);
            window.gameObject.SetActive(true);
            activeWindows[type] = window;
            return window;
        }

        public void CloseWindow(UIType type)
        {
            if (activeWindows.TryGetValue(type, out var window))
            {
                window.OnClose();
                pool.ReturnUI(type, window);
                activeWindows.Remove(type);
            }
        }

        public BasePopup OpenPopup(UIType type, OpenParam param = null)
        {
            var popup = (BasePopup)pool.GetUI(type, popupRoot);
            popup.OnOpen(param);
            popupStack.Push(popup);
            popup.gameObject.SetActive(true);
            return popup;
        }

        public void CloseTopPopup()
        {
            if (popupStack.TryPop(out var popup))
            {
                popup.OnClose();
                pool.ReturnUI(popup.UIType, popup);
            }
        }

        public BaseWindow CurrentWindow => activeWindows.Count > 0 ? activeWindows.Values.LastOrDefault() : null;

        public T GetWindow<T>() where T : BaseWindow
        {
            foreach (var window in activeWindows.Values)
            {
                if (window is T tWindow)
                    return tWindow;
            }
            return null;
        }
    }
}
