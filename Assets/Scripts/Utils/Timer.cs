using UnityEngine;

namespace Utils
{
    public class Timer : MonoBehaviour
    {
        private float totalTime = 0f;
        private float passedTime = 0f;

        bool isRunning = false;
        bool isStarted = false;
        
        public float TotalTime
        {
            set
            {
                if (!isRunning)
                {
                    totalTime = value;
                }
            }
        }

        public bool IsFinished => isStarted && !isRunning;

        public void RunTimer()
        {
            if (totalTime > 0f)
            {
                isRunning = true;
                isStarted = true;
                passedTime = 0f;
            }
        }

        void Update()
        {
            if (isRunning)
            {
                passedTime += Time.deltaTime;
                if (passedTime >= totalTime)
                {
                    isRunning = false;
                }
            }
        }
    }
}