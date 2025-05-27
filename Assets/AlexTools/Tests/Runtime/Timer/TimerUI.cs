using System.Collections;
using AlexTools.Clocks;
using AlexTools.Coroutines;
using TMPro;
using UnityEngine;

namespace AlexTools
{
    public enum ClockType : byte
    { 
        Countdown,
        Stopwatch
    }

    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private ClockType clockType;
        [SerializeField] private float initTime;
        [SerializeField] private string timeFormat = Clock.DefaultTimeFormat;
        [SerializeField, Range(0, 1)] private float tick = 0.1f;

        private Clock _clock;

        private void Start()
        {
            _clock = clockType switch
            {
                ClockType.Countdown => new Countdown(initTime, timeFormat),
                ClockType.Stopwatch => new Stopwatch(initTime, timeFormat),
                _ => throw new System.NotImplementedException(),
            };

            _clock.TickEvent += OnTick;

            _clock.Start();
            // StartCoroutine(TickingRoutine());
        }
        
        private void OnTick(Clock clock)
        {
            var value = _clock.ToString();
            text.text = value;
            print(clock);
        }

        private IEnumerator TickingRoutine()
        {
            while (true)
            {
                yield return WaitFor.Seconds(tick);
                _clock.Tick(tick);
            }
        }
    }
}