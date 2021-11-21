using DG.Tweening;
using UnityEngine;

namespace Code.Ingredients
{
    public class IngredientAnimator : MonoBehaviour
    {
        public float offsetY = 1f;
        [SerializeField] private Vector3 fullAngle = new Vector3(0f, -180f, 0f);

        private void Start()
        {
            UpDownAnimation();
            RotateAnimation();
        }

        public void PauseAnimation()
        {
            DOTween.Pause(transform);
        }

        private void UpDownAnimation()
        {
            Vector3 endPoint = new Vector3(transform.position.x, offsetY, transform.position.z);
            transform
                .DOMove(endPoint, 1)
                .SetLoops(-1, LoopType.Yoyo);
        }

        private void RotateAnimation() =>
            transform
                .DORotate(fullAngle, 2f, RotateMode.Fast)
                .SetLoops(-1)
                .SetEase(Ease.Linear);
    }
}