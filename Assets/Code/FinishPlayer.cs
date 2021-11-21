using Code.Player;
using UnityEngine;

namespace Code
{
    public class FinishPlayer : MonoBehaviour
    {
        private const string PlayerTag = "Player";
    

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                other.GetComponent<PlayerMove>().enabled = false;
            }
        }

    }
}
