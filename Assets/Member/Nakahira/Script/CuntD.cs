using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuntD : MonoBehaviour
{
    GameObject[] tagObjects;

    float timer = 0.0f;
    float interval = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            Check("Enemy");
            timer = 0;
        }
    }


    void Check(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        if (tagObjects.Length == 0)
        {
            
        }
    }
}
