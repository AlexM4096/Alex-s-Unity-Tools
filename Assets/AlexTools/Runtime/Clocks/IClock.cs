using System;

namespace AlexTools.Clocks
{
    public interface IClock : IDisposable
    {
        float InitialTime { get; }
        float CurrentTime { get; }
        
        bool IsTicking { get; }
        
        event Action StartEvent;
        event Action StopEvent;
        
        event Action PauseEvent;
        event Action ResumeEvent;
        
        event Action<float> TickEvent;

        void Start();
        void Stop();

        void Resume();
        void Pause();

        void Reset(float? value = null);
        void HardReset(float? value = null);

        void Add(float time);
        void Subtract(float time);

        void Tick(float deltaTime);
    }
}