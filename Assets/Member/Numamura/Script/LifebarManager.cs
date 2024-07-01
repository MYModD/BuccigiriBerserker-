using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifebarManager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[6];
    
    public bool _ComboReset = default;
    private int lifePoint;
    private int lifeCheck;
    private int StartLife;


    public PlayerLife playerLife;
    private void Start()
    {
        StartLife = (int)playerLife.playerLife;
        lifeCheck = (int)playerLife.playerLife;
        Debug.LogWarning(playerLife.playerLife);
        _ComboReset = false;
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

        if(lifeCheck > lifePoint)
        {
            lifeCheck = lifePoint;
            _ComboReset = true;
        }

        

        Debug.LogWarning(_ComboReset);
        Debug.LogWarning(lifePoint);

        if (lifePoint == 0)
            
        {
            while(StartLife >= lifePoint)
            {
                lifeArray[lifePoint].SetActive(true);
                lifePoint++;
            }
        }

    }
}
