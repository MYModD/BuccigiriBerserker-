using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq; // LINQを使用するために必要

public class PlayerLockon : MonoBehaviour
{
    [SerializeField]
    float _serch_distance = 30f;

    [SerializeField]
    GameObject _player;

    public List<GameObject> _hits;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

       RaycastHit[] hitsArray = Physics.SphereCastAll(
      _player.transform.position,
      _serch_distance,
      _player.transform.forward,
      0.01f,
      LayerMask.GetMask("Enemy")
      );

        List<GameObject> hits = hitsArray.Select(h => h.transform.gameObject).ToList();

    }

    bool IsListEmpty(List<GameObject> list)
    {
        return list != null && list.Count >= 1;
    }
}
