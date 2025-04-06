using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damageeffect : MonoBehaviour
{
    [SerializeField] Image DamageImg;

    private PlayerLife life;
    void Start()
    {
        life = GetComponent<PlayerLife>();
        DamageImg.color = Color.clear;
    }


    void Update()
    { 
        DamageImg.color = Color.Lerp(DamageImg.color, Color.clear, Time.deltaTime);
        if (life.damage)
        {
          
            Damaged();
        }

    }

    void Damaged()
    {
       
        
            DamageImg.color = new Color(0.7f, 0, 0, 0.7f);
            life.damage = false;
        
    }
}
