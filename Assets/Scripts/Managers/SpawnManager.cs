using UnityEngine;
using Utils;
using Objects;

namespace Managers
{
    public class SpawnManager : MonoBehaviour
    {
        private float miniLightSpawnTime = 2f;
        private float obstacleSpawnTime = 0.7f;

        Timer miniLightTimer;
        Timer obstacleTimer;

        private bool hasSpawningStarted;

        #region Singleton

        public static SpawnManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        #endregion

        void Start()
        {
            miniLightTimer = gameObject.AddComponent<Timer>();
            miniLightTimer.TotalTime = GetMiniLightSpawnTime();
            miniLightTimer.RunTimer();

            obstacleTimer = gameObject.AddComponent<Timer>();
            obstacleTimer.TotalTime = obstacleSpawnTime;
            obstacleTimer.RunTimer();
        }

        /// <summary>
        /// Changes mini light spawn time according to Game Level.
        /// </summary>
        /// <returns></returns>
        private float GetMiniLightSpawnTime()
        {
            switch (GameLevel.GetLevel())
            {
                case Level.level1:
                    return 2f;
                case Level.level2:
                    return 2.3f;
                case Level.level3:
                    return 2.6f;
                case Level.level4:
                    return 3f;
                case Level.level5:
                    return 3.4f;
                case Level.level6:
                    return 3.8f;
                case Level.level7:
                    return 4.3f;
                case Level.level8:
                    return 4.8f;
                case Level.level9:
                    return 5.3f;
                case Level.level10:
                    return 6f;
            }

            return miniLightSpawnTime;
        }


        public void StartSpawning()
        {
            hasSpawningStarted = true;
        }

        public void StopSpawning()
        {
            hasSpawningStarted = false;
        }

        private void Update()
        {
            if(hasSpawningStarted) Spawn();
        }

        /// <summary>
        /// Spawns obstacles and creates mini light between obstacles at specific spawn times.
        /// </summary>
        private void Spawn()
        {
            Vector3 position = new Vector3();
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);
            position.x = ScreenCalculator.Right + 2f;
            if (obstacleTimer.IsFinished)
            {
                // Create Obstacles
                Vector3 obstaclePosition = position;
                obstaclePosition.y = Random.Range(ScreenCalculator.Top - 1f, ScreenCalculator.Top);

                CreateObstacles(obstaclePosition);

                // Create Mini Light
                Vector3 miniLightPosition = position;
                miniLightPosition.y = Random.Range(-0.7f, 0.7f);
                if (miniLightTimer.IsFinished)
                {
                    CreateMiniLight(miniLightPosition);
                }

                // Reset Obstacle Timer
                obstacleTimer.TotalTime = obstacleSpawnTime;
                obstacleTimer.RunTimer();
            }
        }

        /// <summary>
        /// Creates obstacles for top and bottom according to given position by mirroring y axis.
        /// </summary>
        /// <param name="position"></param>
        private void CreateObstacles(Vector3 position)
        {
            Vector3 scale = new Vector3(Random.Range(3.5f, 4f), Random.Range(5f, 6f), 1);

            GameObject ceilObstacle = ObjectPool.Instance.GetPooledObstacle();
            ceilObstacle.transform.position = position;
            ceilObstacle.transform.localScale = scale;
            ceilObstacle.SetActive(true);

            position.y *= -1;
            GameObject floorObstacle = ObjectPool.Instance.GetPooledObstacle();
            floorObstacle.transform.position = position;
            floorObstacle.transform.localScale = scale;
            floorObstacle.SetActive(true);

            ScoreManager.Instance.AddDistance();
        }

        /// <summary>
        /// Creates mini light according to given position.
        /// </summary>
        /// <param name="position"></param>
        private void CreateMiniLight(Vector3 position)
        {
            GameObject miniLight = ObjectPool.Instance.GetPooledOMiniLight();
            miniLight.transform.position = position;
            miniLight.SetActive(true);

            miniLightTimer.TotalTime = GetMiniLightSpawnTime();
            miniLightTimer.RunTimer();
        }
    }
}