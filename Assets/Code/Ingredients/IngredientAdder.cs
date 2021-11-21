using Code.Player;
using UnityEngine;

namespace Code.Ingredients
{
    public class IngredientAdder : MonoBehaviour
    {
        private const string PlayerTag = "Player";
        
        public FixedJoint FixedJoint;
        public IngredientAnimator IngredientAnimator;
        public BoxCollider BoxCollider;
        
        public float firstIngredientForce = 10000f;
        public float firstIngredientTorque = 10000f;
        public float breakForceDecrementMultiplier = 200f;
        public float breakTorqueDecrementMultiplier = 200f;
        public float offsetBetweenIngredients = 0.7f;
        public bool isFirstIngredient = true;
        public bool isIngredient = false;

        private IngredientList _ingredientList;
        private Rigidbody _playerRigidbody;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag) && !isIngredient)
            {
                _ingredientList = other.GetComponent<IngredientList>();
                _playerRigidbody = other.GetComponent<Rigidbody>();
                
                AddIngredient(other);
            }
        }

        private void OnJointBreak(float breakForce)
        {
            _ingredientList.RemoveIngredient(gameObject);
        }

        private void AddIngredient(Collider other)
        {
            Transform lastIngredient = _ingredientList.GetLastTransform();

            PauseAnimation();
            DisableTrigger();
            
            MoveToLastIngredientPosition(lastIngredient);
            FirstIngredientChecker();
            ConnectToJoint(lastIngredient);

            AddIngredientList();
        }

        private void DisableTrigger()
        {
            BoxCollider.isTrigger = false;
        }

        private void AddIngredientList()
        {
            _ingredientList.AddIngredient(gameObject);
            isIngredient = true;
        }

        private void PauseAnimation() =>
            IngredientAnimator.PauseAnimation();


        private void ConnectToJoint(Transform lastIngredient)
        {
            if (isFirstIngredient)
            {
                isFirstIngredient = false;
                
                FixedJoint.breakForce = firstIngredientForce;
                FixedJoint.breakTorque = firstIngredientTorque;
                
                FixedJoint.connectedBody = _playerRigidbody;
            }
            else
            {
                DecrementTorque();
                FixedJoint.connectedBody = lastIngredient.GetComponent<Rigidbody>();
            }
        }

        private void DecrementTorque()
        {
            FixedJoint.breakForce -= _ingredientList.GetCount() * breakForceDecrementMultiplier;
            FixedJoint.breakTorque -= _ingredientList.GetCount() * breakTorqueDecrementMultiplier;
        }

        private void MoveToLastIngredientPosition(Transform lastIngredient)
        {
            var position = lastIngredient.transform.position;
            Vector3 lastChildPosition =
                new Vector3(position.x, lastIngredient.position.y + offsetBetweenIngredients, position.z);
            Quaternion lastChildRotation = lastIngredient.rotation;

            transform.position = lastChildPosition;
            transform.rotation = lastChildRotation;
        }

        private bool FirstIngredientChecker()
        {
            if ((_ingredientList.GetCount()) >= 1)
                isFirstIngredient = false;
            return isFirstIngredient;
        }
    }
}