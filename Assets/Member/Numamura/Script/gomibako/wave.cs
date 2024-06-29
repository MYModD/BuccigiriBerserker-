using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{
    private float waveVal = 22;
    private float waveScale;
    private bool _switch = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waveScale = this.transform.localScale.y;

        if(waveScale > 170)
        {
            _switch = false;
        }

        if(waveScale < 80)
        {
            _switch = true;
        }

        if(_switch == true)
        {
            waveScale += waveVal * Time.deltaTime;
        }

        if(_switch == false)
        {
            waveScale -= waveVal * Time.deltaTime;
        }

        this.transform.localScale = new Vector3(this.transform.localScale.x, waveScale, this.transform.localScale.z);
        Debug.Log(_switch);
        Debug.Log(waveScale);
    }
}
