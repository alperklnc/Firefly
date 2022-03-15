using UnityEngine;
using Managers;

namespace Utils
{
    public static class Distance
    {
        public static bool isNewHighDistance = false;

        public static int GetHighDistance()
        {
            return PlayerPrefs.GetInt("HIGH_DISTANCE");
        }

        /// <summary>
        /// Updates the high distance if the given distance is higher.
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        private static void TrySetNewHighDistance(int distance)
        {
            int currentHighDistance = GetHighDistance();
            if (distance > currentHighDistance)
            {
                isNewHighDistance = true;
                PlayerPrefs.SetInt("HIGH_DISTANCE", distance);
                PlayerPrefs.Save();
            }
            else
            {
                isNewHighDistance = false;
            }
        }

        /// <summary>
        /// Resets High Distance.
        /// </summary>
        public static void ResetHighDistance()
        {
            PlayerPrefs.SetInt("HIGH_DISTANCE", 0);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Close the Distance function and updates the high distance.
        /// </summary>
        public static void Close()
        {
            TrySetNewHighDistance(ScoreManager.Instance.Distance);
        }
    }
}