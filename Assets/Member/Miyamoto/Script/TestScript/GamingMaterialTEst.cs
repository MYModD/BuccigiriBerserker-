using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GamingMaterialTEst : MonoBehaviour
{
    
    public List<MeshRenderer> �߂������񂾁[ = new List<MeshRenderer>();

    

    [Range(0, 10f)]
    public float �΂��[;

    private float ����カ��ꂢ�Ƃ΂��[ = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ����カ��ꂢ�Ƃ΂��[ += �΂��[;
        if(����カ��ꂢ�Ƃ΂��[ > 360f)
        {
            ����カ��ꂢ�Ƃ΂��[ = 0;
        }
        foreach (var item in �߂������񂾁[)
        {
            item.material.color = Color.HSVToRGB(����カ��ꂢ�Ƃ΂��[ / 360f, 1, 1);
        }

    }
}
