// using System.Collections.Generic;
// using System.Linq;
// using AlexTools.Collections;
// using AlexTools.Extensions;
// using AlexTools.Flyweight;
// using UnityEditor;
// using UnityEngine;
// using UnityEngine.UIElements;
//
// namespace AlexTools
// {
//     [CustomEditor(typeof(MonoFlyweight<,>), true)]
//     public class MonoFlyweightEditor : Editor
//     {
//         private SerializedProperty _settings;
//
//         private void OnEnable()
//         {
//             _settings = serializedObject.FindAutoProperty("Settings");
//         }
//
//         public override VisualElement CreateInspectorGUI()
//         {
//             
//
//             return CreateInspectorGUI((dynamic)target);
//         }
//         
//         private VisualElement CreateInspectorGUI<T1, T2>(
//             MonoFlyweight<T1, T2> flyweight) 
//             where T1 : MonoFlyweight<T1, T2> 
//             where T2 : MonoFlyweightSettings<T1, T2>
//         {
//             
//             var context = this.GetDefaultInspectorGUI();
//
//             var c = Test(flyweight);
//             var b = new DropdownField(c.First.ToList(), c[flyweight.Settings]);
//             b.RegisterValueChangedCallback(evt =>
//             {
//                 if (!c.TryGetValue(evt.newValue, out var settings))
//                 {
//                     settings = AssetDatabase.LoadAssetAtPath<T2>(evt.newValue);
//                     c.Add(evt.newValue, settings);
//                 }
//                 
//                 flyweight.Initialize(settings);
//             });
//             context.Add(b);
//
//             return context;
//         }
//
//         private static BiMap<string, T2> Test<T1, T2>(
//             MonoFlyweight<T1, T2> flyweight)
//             where T1 : MonoFlyweight<T1, T2> 
//             where T2 : MonoFlyweightSettings<T1, T2>
//         {
//             BiMap<string, T2> a = new();
//
//             var guids = AssetDatabase.FindAssets($"t:{typeof(T2)}");
//             foreach (var guid in guids)
//             {
//                 var path = AssetDatabase.GUIDToAssetPath(guid);
//                 var settings = AssetDatabase.LoadAssetAtPath<T2>(path);
//                 a.Add(path.Split('/').Last(), settings);
//             }
//
//             return a;
//         }
//     }
// }