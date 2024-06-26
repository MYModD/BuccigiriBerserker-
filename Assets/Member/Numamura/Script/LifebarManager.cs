using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifebarManager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[3];
    private int lifePoint = 6;

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
