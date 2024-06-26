using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         float sliderValue = Input.GetAxis("T.16000M Slider");
        Debug.Log("Slider Value: " + sliderValue);
    }
}
