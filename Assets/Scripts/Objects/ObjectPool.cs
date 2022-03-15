using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance { get; private set; }

        [Header("Obstacle Pooling")] [SerializeField]
        GameObject obstacleToPool;

        [SerializeField] int obstacleAmountToPool;
        private List<GameObject> pooledObstacles;

        [Header("Mini Light Pooling")] [SerializeField]
        GameObject miniLightsToPool;

        [SerializeField] int miniLightsAmountToPool;
        private List<GameObject> pooledMiniLights;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        void Start()
        {
            GameObject obstacles = new GameObject("Obstacles");
            pooledObstacles = new List<GameObject>();
            GameObject obstacle;
            for (int i = 0; i < obstacleAmountToPool; i++)
            {
                obstacle = Instantiate(obstacleToPool);
                obstacle.SetActive(false);
                pooledObstacles.Add(obstacle);
                obstacle.transform.SetParent(obstacles.transform);
            }

            GameObject miniLights = new GameObject("Mini Lights");
            pooledMiniLights = new List<GameObject>();
            GameObject miniLight;
            for (int i = 0; i < miniLightsAmountToPool; i++)
            {
                miniLight = Instantiate(miniLightsToPool);
                miniLight.SetActive(false);
                pooledMiniLights.Add(miniLight);
                miniLight.transform.SetParent(miniLights.transform);
            }
        }

        public GameObject GetPooledObstacle()
        {
            for (int i = 0; i < obstacleAmountToPool; i++)
            {
                if (!pooledObstacles[i].activeInHierarchy)
                {
                    return pooledObstacles[i];
                }
            }

            return null;
        }

        public GameObject GetPooledOMiniLight()
        {
            for (int i = 0; i < miniLightsAmountToPool; i++)
            {
                if (!pooledMiniLights[i].activeInHierarchy)
                {
                    return pooledMiniLights[i];
                }
            }

            return null;
        }

        public void DeactivateAll()
        {
            foreach (var obstacle in pooledObstacles)
            {
                obstacle.SetActive(false);
            }

            foreach (var miniLight in pooledMiniLights)
            {
                miniLight.SetActive(false);
            }
        }
    }
}