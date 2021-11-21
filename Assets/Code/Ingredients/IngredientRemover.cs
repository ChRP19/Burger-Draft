using UnityEngine;

namespace Code.Ingredients
{
    public class IngredientRemover : MonoBehaviour
    {
        private const string Barrier = "Barrier";

        public FixedJoint FixedJoint;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(Barrier) && FixedJoint != null)
            {
                FixedJoint.breakTorque = 100f;
            }
        }
    }
}