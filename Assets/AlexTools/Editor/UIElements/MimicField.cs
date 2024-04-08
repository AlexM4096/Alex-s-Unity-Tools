using System;
using UnityEditor;
using UnityEditor.UIElements;
using Object = UnityEngine.Object;

namespace AlexTools.UIElements
{
    public class MimicField<T1, T2> : ObjectField where T1 : class
    {
        private readonly SerializedProperty _property;
        private readonly Func<T1, T2> _func;

        public MimicField(SerializedProperty property, Func<T1, T2> func)
        {
            _func = func;
            _property = property;
            
            objectType = typeof(T1);
        }

        public override void SetValueWithoutNotify(Object newValue)
        {
            _property.boxedValue = _func(newValue as T1);
            base.SetValueWithoutNotify(newValue);
        }
    }
}