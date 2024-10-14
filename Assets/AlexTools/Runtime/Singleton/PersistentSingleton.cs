using UnityEngine;

namespace AlexTools.Singleton
{
    public class PersistentSingleton<T> : MonoBehaviour where T : PersistentSingleton<T>
    {
        private static readonly string Name = $"{typeof(T).Name} (Auto-Generated)";
        
        public bool AutoUnParentOnAwake { get; protected set; } = true;

        private static T _instance;
        public static bool HasInstance => _instance;

        public static T Instance 
        {
            get 
            {
                if (HasInstance) return _instance;
                
                _instance = FindAnyObjectByType<T>();
                if (HasInstance) return _instance;
                
                var go = new GameObject(Name);
                _instance = go.AddComponent<T>();

                return _instance;
            }
            set => _instance = value;
        }
        
        protected virtual void Awake() 
        {
            InitializeSingleton();
        }

        protected virtual void InitializeSingleton() 
        {
            if (!Application.isPlaying) return;

            if (AutoUnParentOnAwake)
                transform.SetParent(null);

            if (HasInstance && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }
}