using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class TimerBehaviour : MonoBehaviour
    {
        [SerializeField] private float duration;
        [SerializeField] private GameObject playerShip;
        [SerializeField] private UnityEvent onTimerEnd = null;

        public Timer timer { get; private set; }
        public float Duration => duration;
        public UnityEvent OnTimerEnd { get => onTimerEnd; set => onTimerEnd = value; }

        private void Start()
        {

            timer = new Timer(duration);

            timer.OnTimerEnd += HandleTimerEnd;
        }
        
        private void HandleTimerEnd()
        {
            
            onTimerEnd?.Invoke();

        }

        private void Update()
        {
            timer.Tick(Time.deltaTime);

            //Debug.Log(Mathf.RoundToInt(timer.RemainingSeconds));
        }

        public void ResetTimer()
        {
            timer.RemainingSeconds = duration;
        }
    }
}
