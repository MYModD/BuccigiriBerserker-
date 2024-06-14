using System.Collections.Generic;
using UnityEngine;

public class LockOnManager : MonoBehaviour
{
    public List<Transform> targetsInCamera = new List<Transform>();
    public List<Transform> targetsInCone = new List<Transform>();

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float _searchRadius = 95f; // ãÖèÛÇÃîÕàÕÇÃîºåa

    [SerializeField, Range(0f, 180f)]
    private float _coneAngle = 45f; // â~êçÇÃäpìx

    void Update()
    {
        UpdateTargets();
        
        for (int i = 0; i < targetsInCamera.Count; i++)
        {
            targetsInCamera[i].GetComponent<MeshRenderer>().material.color = Color.red;
            
        }

        for(int j = 0; j < targetsInCamera.Count; j++)
        {
            targetsInCone[j].GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    private void UpdateTargets()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

        targetsInCamera.Clear();
        targetsInCone.Clear();

        Collider[] hits = GetSphereOverlapHits();

        foreach (Collider hit in hits)
        {
            ProcessHit(hit, planes);
            hit.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    private Collider[] GetSphereOverlapHits()
    {
        return Physics.OverlapSphere(
            _camera.transform.position,
            _searchRadius,
            LayerMask.GetMask("Enemy")
        );
    }

    private void ProcessHit(Collider hit, Plane[] planes)
    {
        if (hit.CompareTag("Enemy"))
        {
            Transform target = hit.transform;
            Renderer renderer = target.GetComponent<Renderer>();

            if (renderer != null && IsInFrustum(renderer, planes))
            {
                targetsInCamera.Add(target);

                if (IsInCone(target))
                {
                    targetsInCone.Add(target);
                }
            }
        }
    }

    private bool IsInFrustum(Renderer renderer, Plane[] planes)
    {
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }

    private bool IsInCone(Transform target)
    {
        Vector3 cameraPosition = _camera.transform.position;
        Vector3 cameraForward = _camera.transform.forward;

        Vector3 toObject = target.position - cameraPosition;
        float distanceToObject = toObject.magnitude;

        if (distanceToObject <= _searchRadius)
        {
            Vector3 toObjectNormalized = toObject.normalized;
            float angle = Vector3.Angle(cameraForward, toObjectNormalized);
            return angle <= _coneAngle / 2;
        }
        return false;
    }

    void OnDrawGizmos()
    {
        if (_camera != null)
        {
            // Search radius (sphere)
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_camera.transform.position, _searchRadius);

            // Cone (angle)
            Gizmos.color = Color.red;
            Vector3 forward = _camera.transform.forward * _searchRadius;
            Vector3 up = Quaternion.Euler(0, _coneAngle / 2, 0) * forward;
            Vector3 down = Quaternion.Euler(0, -_coneAngle / 2, 0) * forward;

            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + forward);
            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + up);
            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + down);


            Gizmos.DrawLine(_camera.transform.position + up, _camera.transform.position + down);
        }
    }
}
