using UnityEngine;

namespace Code.Player
{
    public class PlayerMove : MonoBehaviour
    {
        private const float minX = -3.6f;
        private const float maxX = 3.6f;

        private Touch touch;
        
        public float HorizontalSpeed;
        public float ForwardSpeed;

        private void FixedUpdate()
        {
            MoveForward();
            MoveHorizontal();
        }

        private void MoveHorizontal()
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    float positionX = transform.position.x + touch.deltaPosition.x * HorizontalSpeed;
                    float clampPositionX = ClampPositionX(positionX);
                    var newPosition = new Vector3(clampPositionX, transform.position.y, transform.position.z);

                    transform.position = newPosition;
                }
            }
        }

        private void MoveForward() => 
            transform.position += transform.forward * Time.deltaTime * ForwardSpeed;

        private float ClampPositionX(float positionX)
        {
            float clampPositionX = Mathf.Clamp(positionX, minX, maxX);
            return clampPositionX;
        }
    }
}