using System;
using Code.Ingredients;
using UnityEngine;

namespace Code.Player
{
	public class TopBreadMover : MonoBehaviour
	{
		private IngredientList _ingredientList;
		private const string IngredientTag = "Ingredient";
		
		public float offsetOverIngredients = 0.5f;
		public FixedJoint FixedJoint;
		public Transform TopBread;
		private void Start()
		{
			TopBread.parent = null;
			_ingredientList = this.GetComponent<IngredientList>();
			JoinBody();
		}
		private void JoinBody() =>
			FixedJoint.connectedBody = _ingredientList.GetLastRigidbody();
		
		private void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.CompareTag(IngredientTag))
			{
				Debug.Log("Я коснулся ингредиента: " + other.tag);

				JoinBody();

				Transform lastIngredient = FixedJoint.connectedBody.transform;
				MoveAboveTheLastIngredient(lastIngredient);
			}
		}
		private void MoveAboveTheLastIngredient(Transform lastIngredient)
		{
			var position = lastIngredient.transform.position;
			Vector3 lastIngredientPosition =
				new Vector3(position.x, lastIngredient.position.y + offsetOverIngredients, position.z);
			Quaternion lastIngredientRotation = lastIngredient.rotation;
			
			TopBread.position = lastIngredientPosition;
			TopBread.rotation = lastIngredientRotation;
		}
	}
}