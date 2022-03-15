using UnityEngine;
using Managers;

namespace Utils
{
    public static class Score
    {

        public static bool isNewHighscore = false;

        public static int GetHighscore()
        {
            return PlayerPrefs.GetInt("HIGHSCORE");
        }

        /// <summary>
        /// Updates the highscore if the given score is higher.
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public static void TrySetNewHighscore(int score)
        {
            int currentHighscore = GetHighscore();
            if (score > currentHighscore)
            {
                isNewHighscore = true;
                PlayerPrefs.SetInt("HIGHSCORE", score);
                PlayerPrefs.Save();
            }
            else
            {
                isNewHighscore = false;
            }
        }

        /// <summary>
        /// Resets Highscore.
        /// </summary>
        public static void ResetHighscore()
        {
            PlayerPrefs.SetInt("HIGHSCORE", 0);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Close the Score function and Updates the high score.
        /// </summary>
        public static void Close()
        {
            TrySetNewHighscore(ScoreManager.Instance.Score);
        }
    }
}