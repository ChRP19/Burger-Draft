using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "StaticData/Player")]
    public class PlayerData : ScriptableObject
    {
        [Range(0.01f, 0.02f)]
        public float HorizontalSpeed = 0.012f;
        [Range(1f, 100f)]
        public float ForwardSpeed = 20f;
    }
}