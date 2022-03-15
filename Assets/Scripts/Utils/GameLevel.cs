using Managers;

namespace Utils
{
    public enum Level {
        level1 = 1,
        level2 = 2,
        level3 = 3,
        level4 = 4,
        level5 = 5,
        level6 = 6,
        level7 = 7,
        level8 = 8,
        level9 = 9,
        level10 = 10,
    }

    public static class GameLevel
    {
        /// <summary>
        /// Changes the Game Level according to score.
        /// </summary>
        /// <returns></returns>
        public static Level GetLevel()
        {
            int score = ScoreManager.Instance.Score;
            if(score >= 55)
                return Level.level10;
            if(score >= 45)
                return Level.level9;
            if(score >= 36)
                return Level.level8;
            if(score >= 28)
                return Level.level7;
            if(score >= 21)
                return Level.level6;
            if(score >= 15)
                return Level.level5;
            if(score >= 10)
                return Level.level4;
            if(score >= 6)
                return Level.level3;
            if(score >= 3)
                return Level.level2;
            return Level.level1;
        }
    }
}