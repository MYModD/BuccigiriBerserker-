using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GamingMaterialTEst : MonoBehaviour
{
    
    public List<MeshRenderer> めっしゅれんだー = new List<MeshRenderer>();

    

    [Range(0, 10f)]
    public float ばりゅー;

    private float かりゅきゅれいとばりゅー = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        かりゅきゅれいとばりゅー += ばりゅー;
        if(かりゅきゅれいとばりゅー > 360f)
        {
            かりゅきゅれいとばりゅー = 0;
        }
        foreach (var item in めっしゅれんだー)
        {
            item.material.color = Color.HSVToRGB(かりゅきゅれいとばりゅー / 360f, 1, 1);
        }

    }
}
