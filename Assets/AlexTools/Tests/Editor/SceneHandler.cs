using System.Collections.Generic;
using UnityEngine;

namespace AlexTools
{
    [CreateAssetMenu]
    public class SceneHandler : ScriptableObject
    {
        [SerializeField] [ScenePath]
        private string scene;

        [SerializeField] [ScenePath]
        private List<string> listOfScenes;

        private void OnValidate()
        {
            Debug.Log(scene);
            listOfScenes.ForEach(Debug.Log);
        }
    }
}