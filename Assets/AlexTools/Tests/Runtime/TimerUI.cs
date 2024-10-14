using AlexTools.Clocks;
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
        }

        private void OnTick(float time) => text.text = _clock.ToString();

        private void Update() => _clock.Tick(Time.deltaTime);
    }
}