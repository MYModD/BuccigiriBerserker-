using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestExploson : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        //�A�����炱��������
        
        var renders = GetComponentsInChildren<Renderer>();
        foreach (var renderer in renders)
        {
            //renders;

        }
        var renderers = this.GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            var rigidbody = renderer.gameObject.AddComponent<Rigidbody>();
            rigidbody.isKinematic = true;
            renderer.gameObject.AddComponent<MeshCollider>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

        }
    }
}
