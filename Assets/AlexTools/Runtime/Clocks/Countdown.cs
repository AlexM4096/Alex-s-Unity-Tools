using UnityEngine;

namespace AlexTools.Clocks
{
    public class Countdown : Clock
    {
        public Countdown(MonoBehaviour context, float initialTime) : base(context, initialTime)
        {
        }

        protected override void Tick(float deltaTime)
        {
            CurrentTime -= deltaTime;

            if (CurrentTime < 0)
            {
                CurrentTime = 0;
                Stop();
            }
        }
    }
}