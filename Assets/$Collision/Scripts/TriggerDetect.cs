namespace Collision
{
    using UnityEngine;
    [RequireComponent(typeof(Rigidbody))]
    public class TriggerDetect : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            Debug.Log($"TriggerEnter: {other.name}");
        }
        void OnTriggerStay(Collider other)
        {
            Debug.Log($"TriggerStay: {other.name}");
        }
        void OnTriggerExit(Collider other)
        {
            Debug.Log($"TriggerExit: {other.name}");
        }
    }
}