using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] GameObject player;

    private float _playerlife = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_playerlife == 0)
        {
            //Debug.Log("ÇÆÇÌÅ[Å[");
            _playerlife = 5;
        }

    }

    private void OnTriggerEnter(Collider colider)
    {
       if(colider.gameObject.tag == "Enemy")
        {
            _playerlife = _playerlife - 1;
        }

    }
}
