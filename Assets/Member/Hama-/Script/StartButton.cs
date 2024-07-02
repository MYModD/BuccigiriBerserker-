using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private Button enemystart;
    // Start is called before the first frame update
    void Start()
    {
        enemystart = GameObject.Find("/Canavas/Button").GetComponent<Button>();
        enemystart.Select();
    }

   
}
