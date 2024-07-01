using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class ButtonSelect : MonoBehaviour
{
    private Button start;

    private Button exit;
    // Start is called before the first frame update
    void Start()
    {
        start = GameObject.Find("/Canvas/Start").GetComponent<Button>();
        exit = GameObject.Find("/Canvas/Exit").GetComponent<Button>();
        start.Select();
    }

   
}
