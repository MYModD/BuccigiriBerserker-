using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movez : MonoBehaviour
{
    private float i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         i = i + Time.deltaTime;

        transform.position = new Vector3(0, 2, i);
    }
}
