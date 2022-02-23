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
		public Transform TopBun;

		private void Start()
		{
			_ingredientList = this.GetComponent<IngredientList>();
			JoinBody();

			_ingredientList.OnRemoveIngredient += MoveTopBunAboveTheLastIngredient;
			_ingredientList.OnRemoveIngredient += JoinBody;
		}
		private void JoinBody() =>
			FixedJoint.connectedBody = _ingredientList.GetLastRigidbody();
		
		private void OnTriggerEnter(Collider other)
		{
			if(other.CompareTag(IngredientTag))
			{
				Debug.Log(other.GetComponent<IngredientAdder>().isIngredient);

				MoveTopBunAboveTheLastIngredient();
				JoinBody();
			}
		}
		private void MoveTopBunAboveTheLastIngredient()
		{
			Transform lastIngredient = _ingredientList.GetLastTransform();
			
			var position = lastIngredient.transform.position;
			Vector3 lastIngredientPosition =
				new Vector3(position.x, lastIngredient.position.y + offsetOverIngredients, position.z);
			Quaternion lastIngredientRotation = lastIngredient.rotation;
			
			TopBun.position = lastIngredientPosition;
			TopBun.rotation = lastIngredientRotation;
		}
	}
}