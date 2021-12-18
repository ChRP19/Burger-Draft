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

        float lastPositon = 0;
        float currentPosition = 0;
        float deltaPositon = 0;

        private void FixedUpdate()
        {
            MoveForward();
            //MoveHorizontalMouse();
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

        private void MoveHorizontalMouse()
        {
            if (Input.GetMouseButton(0))
            {
                currentPosition = Input.mousePosition.x;
                deltaPositon = currentPosition - lastPositon;
                lastPositon = currentPosition;
                if (Input.GetAxisRaw("Mouse X") != 0 && deltaPositon != 0)
                {
                    float positionX = transform.position.x + deltaPositon * HorizontalSpeed;
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