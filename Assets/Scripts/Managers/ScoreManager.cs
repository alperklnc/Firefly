namespace Managers
{
    public class ScoreManager
    {
        public int Score { get; private set; }
        public int Distance { get; private set; }

        private ScoreManager() { }

        private static ScoreManager _instance;
        public static ScoreManager Instance => _instance ??= new ScoreManager();

        public void AddScore()
        {
            SoundManager.Instance.PlaySound(Sound.Score);
            Score += 1;
        }

        public void AddDistance()
        {
            Distance += 1;
        }

        public void Reset()
        {
            Score = 0;
            Distance = 0;
        }
    }
}