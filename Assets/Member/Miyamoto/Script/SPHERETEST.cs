using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SPHERETEST : MonoBehaviour
{
    public List<Transform> list = new List<Transform>();
    
    // Start is called before the first frame update
    void Start()
    {
        var hits = Physics.SphereCastAll(transform.position, 500f, transform.forward, 10f);


        foreach (var hit in hits)
        {
            // ヒットしたオブジェクトの位置を取得
            var hitPosition = hit.transform.GameObject().transform;
            list.Add(hitPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
