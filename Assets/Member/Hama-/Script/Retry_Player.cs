using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Retry_Player : MonoBehaviour
{
    private PlayerLife playerlife;

    void Start()
    {
        playerlife = GetComponent<PlayerLife>();
    }

    void Update()
    {
        if(playerlife._IsRetry == true)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }

        if(playerlife._IsRetry == false)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }
            
            
       
    }

   
}
