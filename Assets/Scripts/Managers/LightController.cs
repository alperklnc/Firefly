using UnityEngine;

using Utils;

namespace Managers
{
    public class LightController : MonoBehaviour
    {
        new UnityEngine.Rendering.Universal.Light2D light;

        float decreaseTime = 0.1f;

        [SerializeField] private float minOuterRadius = 1.85f;
        [SerializeField] private float maxOuterRadius = 4.0f;

        float outerRadiusIncreaseAmount = 0.5f;
        float outerRadiusDecreaseAmount = 0.01f;

        private Timer timer;
        private Color color;

        void Start()
        {
            light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
            timer = gameObject.AddComponent<Timer>();
            timer.TotalTime = decreaseTime;
            timer.RunTimer();

            color = light.color;
        }

        private void Update()
        {
            if (timer.IsFinished && GameManager.Instance.IsPlaying)
            {
                Decrease();
                timer.RunTimer();
            }
        }

        /// <summary>
        /// Increases the light of the fire fly and makes the light more yellowish.
        /// </summary>
        public void Increase()
        {
            if (light.pointLightOuterRadius + GetIncreaseAmount() > maxOuterRadius)
            {
                light.pointLightOuterRadius = maxOuterRadius;
            }
            else
            {
                light.pointLightOuterRadius += GetIncreaseAmount();
            }

            color.g = light.pointLightOuterRadius / 4;
            light.color = color;
        }

        /// <summary>
        /// Decreases the light of the fire fly and makes the light more reddish.
        /// </summary>
        private void Decrease()
        {
            if (light.pointLightOuterRadius - outerRadiusDecreaseAmount < minOuterRadius)
            {
                light.pointLightOuterRadius = minOuterRadius;
            }
            else
            {
                light.pointLightOuterRadius -= outerRadiusDecreaseAmount;
            }

            color.g = light.pointLightOuterRadius / 4;
            light.color = color;
        }

        /// <summary>
        /// Makes firefly's light red when game is over.
        /// </summary>
        public void RedDead()
        {
            color.g = 0;
            light.color = color;
        }

        /// <summary>
        /// Changes increase amount according to the Game Level.
        /// </summary>
        /// <returns>increase amount</returns>
        private float GetIncreaseAmount()
        {
            switch (GameLevel.GetLevel())
            {
                case Level.level1:
                case Level.level2:
                    return 0.5f;
                case Level.level3:
                case Level.level4:
                    return 0.45f;
                case Level.level5:
                case Level.level6:
                    return 0.42f;
                case Level.level7:
                case Level.level8:
                    return 0.39f;
                case Level.level9:
                case Level.level10:
                    return 0.35f;
            }

            return outerRadiusIncreaseAmount;
        }
    }
}