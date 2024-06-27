using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifebarManager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[6];
    
    private int lifePoint;
    private int StartLife;


    public PlayerLife playerLife;
    private void Start()
    {
        StartLife = (int)playerLife.playerLife;
        Debug.LogWarning(playerLife.playerLife);
    }
    void Update()
    {
        lifePoint = (int)playerLife.playerLife;
        //if (Input.GetMouseButtonDown(0) && lifePoint < 6)
        //{
            //lifePoint++;
        //}

        //else if (Input.GetMouseButtonDown(1) && lifePoint > 0)
        //{
            //lifePoint--;
       // }

        if (lifePoint < 6 && lifePoint >= 0)
        {
            lifeArray[lifePoint].SetActive(false);
        }

        if(lifePoint == 0)
            
        {
            while(StartLife >= lifePoint)
            {
                lifeArray[lifePoint].SetActive(true);
                lifePoint++;
            }
        }

    }
}
