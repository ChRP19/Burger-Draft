using UnityEngine;

namespace Code.Camera
{
    public class CameraFollow : MonoBehaviour
    { 
        private Transform _playerTransform; 
        public float offset = -17f;            

        private void LateUpdate()
        {
            if (_playerTransform == null)
                return;

            FollowToPlayer();
        }

        public void Follow(GameObject following) =>
            _playerTransform = following.transform;
        private void FollowToPlayer()
        {
            Vector3 playerPosition = new Vector3(transform.position.x, transform.position.y, _playerTransform.position.z + offset);
            transform.position = playerPosition;
        }
    }
}
