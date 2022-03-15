using UnityEngine;
using Managers;
using Utils;

namespace Objects
{
    public class Firefly : MonoBehaviour
    {
        private Rigidbody2D fireFlyRB;
        private LightController lightController;
        [SerializeField] private float velocity = 4;

        #region Singleton

        private static Firefly instance;
        
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
        }
        
        #endregion

        void Start()
        {
            fireFlyRB = GetComponent<Rigidbody2D>();
            lightController = GetComponent<LightController>();
            fireFlyRB.bodyType = RigidbodyType2D.Static;
        }

        void Update()
        {
            transform.eulerAngles = new Vector3(0, 0, fireFlyRB.velocity.y * 1f);
            if (transform.position.y >= ScreenCalculator.Top || transform.position.y <= ScreenCalculator.Bottom)
            {
                GameManager.gameOver.Invoke();
            }
        }

        public void Jump()
        {
            fireFlyRB.velocity = Vector2.up * velocity;
        }

        public void ResetPosition()
        {
            transform.position = Vector3.zero;
        }
        
        /// <summary>
        /// Change firefly rigidbody bodytype to dynamic and give a initial jump
        /// </summary>
        public void ActiveFireFly()
        {
            fireFlyRB.bodyType = RigidbodyType2D.Dynamic;
            Jump(); // Initial jump
        }
        
        /// <summary>
        /// Change firefly rigidbody bodytype to static and make the light red.
        /// </summary>
        public void Dead()
        {
            fireFlyRB.bodyType = RigidbodyType2D.Static;
            lightController.RedDead();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniLight"))
            {
                collision.gameObject.GetComponent<MiniLight>().DestroyMiniLight();
                lightController.Increase();
                ScoreManager.Instance.AddScore();
            } else if (collision.CompareTag("Obstacle")) {
                GameManager.gameOver.Invoke();
            }
        }
    }
}