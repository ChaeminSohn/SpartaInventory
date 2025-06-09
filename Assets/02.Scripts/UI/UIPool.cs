using System.Collections.Generic;
using UnityEngine;

namespace _02.Scripts.UI
{
    public class UIPool : MonoBehaviour
    {
        private readonly Dictionary<UIType, Queue<BaseUI>> pool = new();

        public BaseUI GetUI(UIType type, Transform parent)
        {
            if (pool.TryGetValue(type, out var q) && q.Count > 0)
            {
                var ui = q.Dequeue();
                ui.transform.SetParent(parent, false);
                return ui;
            }

            string path = UIPath.GetPath((type));
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject go = GameObject.Instantiate(prefab, parent);
            return go.GetComponent<BaseUI>();
        }

        public void ReturnUI(UIType type, BaseUI ui)
        {
            ui.gameObject.SetActive((false));
            pool.TryAdd(type, new Queue<BaseUI>());
            pool[type].Enqueue(ui);
        }
    }
}
