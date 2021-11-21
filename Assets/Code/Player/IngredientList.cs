using System.Collections.Generic;
using Code.Ingredients;
using UnityEngine;

namespace Code.Player
{
    public class IngredientList : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _ingredients;

        public void AddIngredient(GameObject ingredient)
        {
            _ingredients.Add(ingredient);
        }

        public void RemoveIngredient(GameObject ingredient)
        {
            int index = _ingredients.IndexOf(ingredient);
            for (int i = _ingredients.Count - 1; i >= index; i--)
            {
                if (i > 0)
                {
                    RemoveFixedJoint(i);
                    _ingredients.RemoveAt(i);
                    
                    Debug.Log("Delete item # " + i);
                }
            }
        }

        private void RemoveFixedJoint(int i) => 
            Destroy(_ingredients[i].GetComponent<FixedJoint>());

        public Transform GetLastTransform()
        {
            GameObject last = _ingredients[_ingredients.Count - 1];
            return last.transform;
        }

        public int GetCount() => 
            _ingredients.Count - 1;
    }
}