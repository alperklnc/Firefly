using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject welcomeWindow;
        [SerializeField] private GameObject continueWindow;
        [SerializeField] private GameObject scoreWindow;
        [SerializeField] private GameObject gameOverWindow;

        [SerializeField] private Text scoreTextInPlay;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text highscoreText;
        [SerializeField] private Text newHighscoreText;

        [SerializeField] private Text distanceTextInPlay;
        [SerializeField] private Text distanceText;
        [SerializeField] private Text highDistanceText;
        [SerializeField] private Text newHighDistanceText;

        [SerializeField] private Button continueButton;

        private ScoreManager scoreManager;

        #region Singleton

        public static UIManager Instance { get; private set; }

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
            
            welcomeWindow.SetActive(true);
            scoreWindow.SetActive(false);
            gameOverWindow.SetActive(false);
        }

        #endregion

        private void Start()
        {
            scoreManager = ScoreManager.Instance;
            
            GameManager.gameStart += UI_OnGameStart;
            GameManager.gameOver += UI_OnGameOver;
        }

        private void Update()
        {
            scoreTextInPlay.text = scoreManager.Score.ToString();
            distanceTextInPlay.text = scoreManager.Distance + "m";
        }

        public void Reload(bool isContinued)
        {
            gameOverWindow.SetActive(false);
            welcomeWindow.SetActive(!isContinued);
            continueWindow.SetActive(isContinued);
            scoreWindow.SetActive(isContinued);
        }
        
        /// <summary>
        /// Adjusts the UI Windows OnGameStart.
        /// </summary>
        private void UI_OnGameStart()
        {
            gameOverWindow.SetActive(false);
            welcomeWindow.SetActive(false);
            continueWindow.SetActive(false);
            scoreWindow.SetActive(true);
        }

        /// <summary>
        /// Adjusts the UI Windows OnGameOver.
        /// </summary>
        private void UI_OnGameOver()
        {
            SetInteractable(!GameManager.Instance.IsContinued);
            
            scoreWindow.SetActive(false);

            scoreText.text = scoreManager.Score.ToString();
            if (Score.isNewHighscore)
            {
                newHighscoreText.enabled = true;
                highscoreText.text = scoreManager.Score.ToString();
            }
            else
            {
                highscoreText.text = Score.GetHighscore().ToString();
                newHighscoreText.enabled = false;
            }

            distanceText.text = scoreManager.Distance + "m";
            if (Distance.isNewHighDistance)
            {
                newHighDistanceText.enabled = true;
                highDistanceText.text = scoreManager.Distance+ "m";
            }
            else
            {
                highDistanceText.text = Distance.GetHighDistance() + "m";
                newHighDistanceText.enabled = false;
            }

            gameOverWindow.SetActive(true);
        }
        
        /// <summary>
        /// Changes continueButton's interactablity.
        /// </summary>
        /// <param name="interactable"></param>
        private void SetInteractable(bool interactable)
        {
            continueButton.GetComponentInChildren<Text>().color = interactable ? Color.white : Color.gray;
            continueButton.interactable = interactable;
        }
    }
}