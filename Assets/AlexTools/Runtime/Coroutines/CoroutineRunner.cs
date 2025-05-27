using UnityEngine;

namespace AlexTools.Coroutines
{
    public class CoroutineRunner : MonoBehaviour
    {
        private static MonoBehaviour _instance;
        public static MonoBehaviour Instance 
        {
            get
            {
                if (_instance) return _instance;
                _instance = CreateInstance();
                return _instance;
            }
            set
            {
                if (_instance) Debug.LogError("Instance is already declared!!!");
                _instance = value;
            }
        }

        private static MonoBehaviour CreateInstance()
        {
            var instance = new GameObject().AddComponent<CoroutineRunner>();
            DontDestroyOnLoad(instance);
            return instance;
        }

        private void Awake() => Instance = this;
    }
}