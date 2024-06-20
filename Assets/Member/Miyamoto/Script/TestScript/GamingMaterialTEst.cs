using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GamingMaterialTEst : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public List<MeshRenderer> meshRenderers = new List<MeshRenderer>();

    public List<Transform> explsionTest = new List<Transform>();

    [Range(0, 10f)]
    public float value;

    private float calulatevalue = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in explsionTest)
        {
            var hoge = item.AddComponent<Rigidbody>();
            item.AddComponent<MeshCollider>();
            hoge.useGravity = false;
            hoge.SetDensity(200f);

        }
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
