using Managers;
using UnityEngine;
using Utils;

namespace Objects
{
    public class OncomingObject : MonoBehaviour
    {
        [SerializeField] protected float speed = 3f;

        private void Update()
        {
            if (GameManager.Instance.IsPlaying)
            {
                Move();
                if (transform.position.x < ScreenCalculator.Left - 2f)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        private void Move()
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}