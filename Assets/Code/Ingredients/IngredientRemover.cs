using UnityEngine;

namespace Code.Ingredients
{
    public class IngredientRemover : MonoBehaviour
    {
        private const string Barrier = "Barrier";

        public IngredientAdder IngredientAdder;
        public FixedJoint FixedJoint;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(Barrier) && FixedJoint != null)
            {
                IngredientAdder.IngredientList.RemoveRandomLastIngredients();
            }
        }
        
        private void OnJointBreak(float breakForce)
        {
            IngredientAdder.IngredientList.RemoveIngredient(gameObject);
        }
    }
}