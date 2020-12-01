namespace Collision
{
    using UnityEngine;

    public class CollisionDetect : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"OnCollisionEnter: {collision.collider.name}");
        }
        void OnCollisionStay(Collision collision)
        {
            Debug.Log($"OnCollisionStay: {collision.collider.name}");
        }
        void OnCollisionExit(Collision collision)
        {
            Debug.Log($"OnCollisionExit: {collision.collider.name}");
        }
    }
}