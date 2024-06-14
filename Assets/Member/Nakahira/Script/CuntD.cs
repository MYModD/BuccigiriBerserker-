using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuntD : MonoBehaviour
{
    GameObject[] tagObjects;

    float timer = 0.0f;
    float interval = 0.2f;
    public Text countText;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;  
        countText.text = "Count: 0";
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
        countText.text = "Count: 0";
        //if (tagObjects.Length == 0)
        //{

        //}
    }
}
