using UnityEngine;

namespace Managers
{
    public enum Sound
    {
        Score,
        GameOver
    }

    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip score;
        [SerializeField] private AudioClip gameOver;

        private AudioSource audioSource;

        #region Singleton

        public static SoundManager Instance { get; private set; }

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

        private void Start()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        public void PlaySound(Sound sound)
        {
            audioSource.PlayOneShot(GetAudioClip(sound));
        }

        private AudioClip GetAudioClip(Sound sound)
        {
            switch (sound)
            {
                case Sound.Score:
                    return score;
                case Sound.GameOver:
                    return gameOver;
                default:
                    Debug.LogError("Sound " + sound + " not found!");
                    return null;
            }
        }
    }
}