using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform target;
    public float torqueRatio;
    public float speed;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        print(rb.velocity.magnitude);
        if (rb.velocity.magnitude > 20f) return;
        
        if (target == null)
            return;

        // ターゲットの方向を向く
        Vector3 diff = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(diff);
        Quaternion deltaRotation = targetRotation * Quaternion.Inverse(transform.rotation);

        if (deltaRotation.w < 0f)
        {
            deltaRotation = new Quaternion(-deltaRotation.x, -deltaRotation.y, -deltaRotation.z, -deltaRotation.w);
        }

        Vector3 torque = new Vector3(deltaRotation.x, deltaRotation.y, deltaRotation.z) * torqueRatio;
        rb.AddTorque(torque);

        // 前進する
        rb.velocity = transform.forward * speed;
    }
}
