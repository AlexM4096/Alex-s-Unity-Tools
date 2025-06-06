﻿namespace AlexTools.Clocks
{
    public class Stopwatch : Clock
    {
        public Stopwatch(float initialTime = 0, string timeFormat = DefaultTimeFormat) 
            : base(initialTime, timeFormat) {}

        public override void Tick(float deltaTime)
        {
            base.Tick(deltaTime);
            
            CurrentTime += deltaTime;
        }
    }
}