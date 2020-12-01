namespace Collision
{
    using UnityEngine;
    public class CollisionManage : MonoBehaviour
    {
        public Transform target;

        [ContextMenu("AddTrigger")]
        void AddTrigger() => gameObject.AddComponent<TriggerDetect>();
        [ContextMenu("AddCollision")]
        void AddCollision() => gameObject.AddComponent<CollisionDetect>();
        [ContextMenu("AddPhysic")]
        void AddPhysic() => gameObject.AddComponent<PhysicDetect>().target = target;
    }
}
