using System;

namespace AlexTools.Clocks
{
    public class AccelerationClock : IClock
    {
        private readonly IClock _clock;
        public float Acceleration { get; set; }
        
        public AccelerationClock(IClock clock, float acceleration = 1)
        {
            _clock = clock;
            Acceleration = acceleration;
            
            Subscribe();
        }

        private float AcceleratedTime(float time) => time * Acceleration;

        private void Subscribe()
        {
            _clock.StartEvent += StartEvent;
            _clock.StopEvent += StopEvent;

            _clock.PauseEvent += PauseEvent;
            _clock.ResumeEvent += ResumeEvent;

            _clock.TickEvent += TickEvent;
        }
        
        private void Unsubscribe()
        {
            _clock.StartEvent -= StartEvent;
            _clock.StopEvent -= StopEvent;
            
            _clock.PauseEvent -= PauseEvent;
            _clock.ResumeEvent -= ResumeEvent;

            _clock.TickEvent -= TickEvent;
        }
        
        public void Dispose()
        {
            Unsubscribe();
        }

        public float InitialTime => _clock.InitialTime;
        public float CurrentTime => _clock.CurrentTime;
        
        public bool IsTicking => _clock.IsTicking;

        public event Action StartEvent;
        public event Action StopEvent;

        public event Action PauseEvent;
        public event Action ResumeEvent;

        public event Action<float> TickEvent;

        public void Start() => _clock.Start();
        public void Stop() => _clock.Stop();

        public void Resume() => _clock.Resume();
        public void Pause() => _clock.Pause();

        public void Reset(float? value = null) => _clock.Reset(value);
        public void HardReset(float? value = null) => _clock.HardReset(value);

        public void Add(float time) => _clock.Add(AcceleratedTime(time));
        public void Subtract(float time) => _clock.Subtract(AcceleratedTime(time));

        public void Tick(float deltaTime) => _clock.Tick(AcceleratedTime(deltaTime));
    }
}