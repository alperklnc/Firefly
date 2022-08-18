using UnityEngine;
using Objects;
using Utils;

public enum State {
    WaitingToStart,
    Playing,
    Dead,
}

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public delegate void OnGameStart();
        public static OnGameStart gameStart;
        
        public delegate void OnGameOver();
        public static OnGameOver gameOver;
        
        public bool IsContinued { get; private set; }
        
        
        public State State { get; set; }
        public bool IsWaitingToStart => State == State.WaitingToStart;
        public bool IsPlaying => State == State.Playing;
        
        public Firefly firefly;

        public static GameManager Instance { get; private set; }
        
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

            State = State.WaitingToStart;
            ScreenCalculator.Init();
        }

        private void Start()
        {
            ScoreManager.Instance.Reset();
        }

        private void OnEnable()
        {
            gameStart += GameManager_OnGameStart;
            gameOver += GameManager_OnGameOver;
        }

        private void OnDisable()
        {
            gameStart -= GameManager_OnGameStart;
            gameOver -= GameManager_OnGameOver;
        }

        private void GameManager_OnGameStart()
        {
            State = State.Playing;
            firefly.ActiveFireFly();
            
            SpawnManager.Instance.StartSpawning();
        }
        
        private void GameManager_OnGameOver()
        {
            State = State.Dead;
            firefly.Dead();
            
            SpawnManager.Instance.StopSpawning();
            SoundManager.Instance.PlaySound(Sound.GameOver);

            Score.Close();
            Distance.Close();
        }

        private void ReloadScene(bool isContinued)
        {
            IsContinued = isContinued;
            UIManager.Instance.Reload(IsContinued);
            ObjectPool.Instance.DeactivateAll();
            firefly.ResetPosition();
            State = State.WaitingToStart;
        }
        
        // Button Actions
        public void Retry()
        {
            ScoreManager.Instance.Reset();
            ReloadScene(false);
        }

        public void Continue()
        {
            if (!IsContinued)
            {
                //AdManager.Show();
                ReloadScene(true);
            }
        }
    }
}
