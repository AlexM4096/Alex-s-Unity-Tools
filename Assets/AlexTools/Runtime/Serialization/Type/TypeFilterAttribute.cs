using System;
using AlexTools.Extensions;
using UnityEngine;

namespace AlexTools.Serialization
{
    public class TypeFilterAttribute : PropertyAttribute
    {
        public readonly Func<Type, bool> Filter;
        
        public TypeFilterAttribute(Type filterType)
        {
            Filter = type => type.IsStandard() && type.InheritsOrImplements(filterType);
        }
    }
}