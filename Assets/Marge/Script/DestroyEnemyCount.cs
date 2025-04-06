using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyEnemyCount : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    public int value = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();   
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    CountUp();
        //}
    }

    public void CountUp()
    {
        Debug.Log("‚æ‚Î‚ê‚½");
        value++;
        textMeshPro.text = value.ToString();


    }

}
