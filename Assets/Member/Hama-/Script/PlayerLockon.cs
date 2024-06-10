using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq; // LINQを使用するために必要

public class PlayerLockon : MonoBehaviour
{
    public float serch_distance = 30f;

    [SerializeField]
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        var hits = Physics.SphereCastAll(
            player.transform.position,
            serch_distance,
            player.transform.forward,
            0.01f,
            LayerMask.GetMask("Enemy")
        ).Select(h => h.transform.gameObject).ToList();

    }
}
