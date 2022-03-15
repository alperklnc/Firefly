using UnityEngine;
using UnityEngine.EventSystems;

namespace Managers
{
    public class InputManager:MonoBehaviour
    {
        private void Update()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (GameManager.Instance.IsWaitingToStart)
                {
                    if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
                    {
                        GameManager.gameStart.Invoke();
                    }
                        
                }
                
                else if (GameManager.Instance.IsPlaying)
                {
                    // PC Control
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        GameManager.Instance.firefly.Jump();
                    }

                    // MOBILE Control
                    for (int i = 0; i < Input.touchCount; i++)
                    {
                        if (Input.GetTouch(i).phase == TouchPhase.Began)
                            GameManager.Instance.firefly.Jump();
                    }
                }
            }
        }
    }
}