using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifebarManager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[6];
    
    private int lifePoint = 6;


    private void Start()
    {
        PlayerLife playerlife = GetComponent<PlayerLife>();
        //int value = playerlife.playerLife;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && lifePoint < 6)
        {
            lifePoint++;
            lifeArray[lifePoint - 1].SetActive(true);
        }

        else if (Input.GetMouseButtonDown(1) && lifePoint > 0)
        {
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
        }
    }
}
