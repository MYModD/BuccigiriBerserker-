using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItest : MonoBehaviour
{
    public Image[] images;


    private void Update()
    {
        




    }

    private void zenbuoff()
    {

        foreach (var item in images)
        {
            item.enabled = false;
        }

    }

}
