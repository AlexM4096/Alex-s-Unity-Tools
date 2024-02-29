using System;
using AlexTools.Attributes;
using AlexTools.Extensions;
using UnityEngine;

namespace AlexTools
{
    public class Test : MonoBehaviour
    {
        [ShowOnly] public int a;
        public int b;
        
        private void Awake()
        {
             
        }
    }
}