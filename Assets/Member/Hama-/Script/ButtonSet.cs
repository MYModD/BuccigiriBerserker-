using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonSet : MonoBehaviour
{
    private Button gamestart;
    // Start is called before the first frame update
    void Start()
    {
        gamestart = GameObject.Find("/Canvas/GameStartButton").GetComponent<Button>();
        gamestart.Select();
    }

}
