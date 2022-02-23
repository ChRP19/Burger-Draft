using System;
using System.Collections.Generic;
using Code.Ingredients;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Player
{
    public class IngredientList : MonoBehaviour
    {
        [SerializeField] private List<GameObject> ingredients;
        public event Action OnRemoveIngredient;
        
        public void AddIngredient(GameObject ingredient)
        {
            ingredients.Add(ingredient);
        }

        public Transform GetLastTransform()
        {
            GameObject last = ingredients[ingredients.Count - 1];
            return last.transform;
        }
        public int GetCount() => 
            ingredients.Count - 1;
        
        public Rigidbody GetLastRigidbody()
        {
            GameObject last = ingredients[ingredients.Count - 1];
            return last.gameObject.GetComponent<Rigidbody>();
        }
        
        private void RemoveFixedJoint(int i) => 
           Destroy(ingredients[i].GetComponent<FixedJoint>());
        
        public void RemoveIngredient(GameObject ingredient)
        {
            int index = ingredients.IndexOf(ingredient);
            for (int i = ingredients.Count - 1; i >= index; i--)
            {
                if (i > 0)
                {
                    RemoveFixedJoint(i);
                    ingredients.RemoveAt(i);
                }
            }
            OnRemoveIngredient?.Invoke();
        }
        
        public void RemoveRandomLastIngredients()
        {
            int index = ingredients.Count - Random.Range(2, 3);
            for (int i = ingredients.Count - 1; i >= index; i--)
            {
                if (i > 0)
                {
                    RemoveFixedJoint(i);
                    ingredients.RemoveAt(i);
                }
            }
            OnRemoveIngredient?.Invoke();
        }
    }
}