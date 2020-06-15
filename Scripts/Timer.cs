using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Timer
    {
        public float RemainingSeconds { get; set; }

        public event Action OnTimerEnd;

        public Timer(float duration)
        {
            RemainingSeconds = duration;
        }

        public void Tick(float deltaTime)
        {
            if (RemainingSeconds == 0f) return;

            RemainingSeconds -= deltaTime;

            CheckForTimerEnd();
        }

        public void CheckForTimerEnd()
        {
            if (RemainingSeconds > 0f) return;

            RemainingSeconds = 0f;

            OnTimerEnd?.Invoke();
        }
      
    }
}
