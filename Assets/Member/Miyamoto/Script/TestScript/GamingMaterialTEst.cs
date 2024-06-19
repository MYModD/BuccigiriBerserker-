using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamingMaterialTEst : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public List<MeshRenderer> meshRenderers = new List<MeshRenderer>();

    [Range(0, 10f)]
    public float value;

    private float calulatevalue = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calulatevalue += value;
        if(calulatevalue > 360f)
        {
            calulatevalue = 0;
        }
        foreach (var item in meshRenderers)
        {
            item.material.color = Color.HSVToRGB(calulatevalue / 360f, 1, 1);
        }

    }
}
