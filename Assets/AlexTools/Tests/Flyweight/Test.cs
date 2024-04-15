using System;
using System.Collections.Generic;
using System.Linq;
using AlexTools.Extensions;
using UnityEngine;

namespace AlexTools.Tests.Flyweight
{
    [Flags]
    public enum Flags
    {
        A = 1,
        B = 2,
        C = 4,
        D = 8,
    }
    
    public class Test : MonoBehaviour
    {
        [SerializeField] private TestFlyweightSettings settings;
        private void Awake()
        {
            Dictionary<Flags, string> p = new()
            {
                { Flags.A, "Aaa" },
                { Flags.B, "Bbb" },
                { Flags.C, "Ccc" },
                { Flags.D, "Ddd" },
            };
            
            var x = Flags.A | Flags.B | Flags.D;
            x &= Flags.B;
            x |= Flags.D;

            x.GetFlags().Select(p.AsFunc).ForEach(t => print(t));

            string Method(Flags a) => a switch
            {
                Flags.A => "Aaa",
                Flags.B => "Bbb",
                Flags.C => "Ccc",
                Flags.D => "Ddd",
                _ => throw new ArgumentOutOfRangeException(nameof(a), a, null)
            };
        }
    }
}