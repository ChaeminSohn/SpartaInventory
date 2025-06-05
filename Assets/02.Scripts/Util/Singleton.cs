using UnityEngine;

namespace _02.Scripts.Util
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static readonly object _lock = new object();
        private static bool applicationIsQuitting;

        public static T Instance
        {
            get
            {
                if (applicationIsQuitting)
                {
                    Debug.LogWarning($"[Singleton] {typeof(T)} 이미 종료되었습니다. 새 인스턴스는 반환되지 않습니다.");
                    return null;
                }

                lock (_lock)
                {
                    if (_instance) return _instance;
                    _instance = FindObjectOfType<T>();

                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        Debug.LogError($"[Singleton] {typeof(T)} 인스턴스가 2개 이상 존재합니다!");
                        return _instance;
                    }

                    if (_instance) return _instance;
                    var singletonObject = new GameObject($"{typeof(T)} (Singleton)");
                    _instance = singletonObject.AddComponent<T>();
                    DontDestroyOnLoad(singletonObject);

                    return _instance;
                }
            }
        }

        // ✅ 중복 방지를 위한 핵심 로직
        protected virtual void Awake()
        {
            if (!_instance)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this)
            {
                Destroy(gameObject); // 중복 인스턴스 제거
            }
        }

    
        protected virtual void OnApplicationQuit()
        {
            applicationIsQuitting = true;
        }

        protected virtual void OnDestroy()
        {
            if (_instance == this)
                applicationIsQuitting = true;
        }
    }
}