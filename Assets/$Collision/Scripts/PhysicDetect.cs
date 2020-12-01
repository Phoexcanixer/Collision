//#define LineCast
#define Raycast
#define Overlab

namespace Collision
{
    using System.Linq;
    using UnityEngine;

    public class PhysicDetect : MonoBehaviour
    {
        [Range(0, 100)] public float maxDis = 100, radius = 13;
        public Transform target;
#if LineCast
        [ContextMenu("Linecast")]
        void Linecast()
        {
            if (Physics.Linecast(transform.position, target.position, out RaycastHit hit))
            {
                Debug.Log($"Linecast Check: {hit.transform.name}");
            }
        }
#elif Raycast
        [ContextMenu("Raycast")]
        void Raycast()
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, maxDis))
            {
                Debug.Log($"Raycast Check: {hit.transform.name}");
            }
        }
        [ContextMenu("RaycastAll")]
        void RaycastAll()
        {
            RaycastHit[] _hits = Physics.RaycastAll(transform.position, Vector3.forward, maxDis);
            if (_hits.Length > 0)
            {
                for (int i = 0; i < _hits.Length; i++)
                {
                    Debug.Log($"RaycastAll Check: {_hits[i].transform.name}");
                }
            }
        }
        [ContextMenu("RaycastNonAlloc")]
        void RaycastNonAlloc()
        {
            RaycastHit[] _hits = new RaycastHit[2];
            Physics.RaycastNonAlloc(transform.position, Vector3.forward, _hits, maxDis);
            if (_hits.Count(item => item.transform != null) > 0)
            {
                for (int i = 0; i < _hits.Count(item => item.transform != null); i++)
                {
                    Debug.Log($"RaycastNonAlloc Check: {_hits[i].transform.name}");
                }
            }
        }
#elif Overlab
        [ContextMenu("OverlapSphere")]
        void OverlapSphere()
        {
            Collider[] _cols = Physics.OverlapSphere(transform.position, radius);
            if (_cols.Length > 0)
            {
                for (int i = 0; i < _cols.Length; i++)
                {
                    Debug.Log($"OverlapSphere Check: {_cols[i].name}");
                }
            }
        }
        [ContextMenu("OverlapSphereNonAlloc")]
        void OverlapSphereNonAlloc()
        {
            Collider[] _cols = new Collider[2];
            Physics.OverlapSphereNonAlloc(transform.position, radius, _cols);
            if (_cols.Count(item => item.transform != null) > 0)
            {
                for (int i = 0; i < _cols.Count(item => item.transform != null); i++)
                {
                    Debug.Log($"OverlapSphereNonAlloc Check: {_cols[i].name}");
                }
            }
        }
#endif
        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
#if LineCast
            Gizmos.DrawLine(transform.position, target.position);
#elif Raycast
            Gizmos.DrawRay(transform.position, Vector3.forward * maxDis);
#elif Overlab
            Gizmos.DrawWireSphere(transform.position, radius);
#endif
        }
    }
}
