using System;
using System.Collections.Generic;
using AlexTools.Extensions;
using UnityEngine;

namespace AlexTools.Clocks
{
    public class TTS : MonoBehaviour
    {
        private IClock _countdown;
        private IClock _accel;

        private Dictionary<bool, string> _a = new();

        private void Awake()
        {
            _countdown = new Countdown(10);
            _accel = new AccelerationClock(_countdown);

            _accel.TickEvent += f => print(f);

            _accel.Start();

            _a[false] = "False";
            Pip(_a.AsFunc);
        }

        private void Update()
        {
            _accel.Tick(Time.deltaTime);
        }

        private void Pip(Func<bool, string> func) => print(func(true));
    }
}