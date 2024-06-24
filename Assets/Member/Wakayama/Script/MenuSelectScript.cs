using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelectScript : MonoBehaviour
{
    float GetHorizontal = Input.GetAxisRaw("Horizontal");
    float GetFire1 = Input.GetAxisRaw("Fire1");


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMenuSelect();
    }

    private void HorizontalMenuSelect()
    {
        if(GetHorizontal > 0)
        {

        }
        if (GetHorizontal < 0)
        {

        }
    }

    private void ConnectMenuSelect()
    {
        if (GetFire1 > 0)
        {
            
        }
    }
}
