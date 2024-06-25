using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] GameObject player;

    private float _playerlife = 5;

    public bool _IsRetry;

    private bool _Ismesh;

    private bool _Iscolider;

    

    

    //private void Start()
    //{
        
    //}
    // Update is called once per frame
    void Update()
    {
        if (_playerlife == 0)
        {

            _IsRetry = true;
            Invoke(nameof(Dead), 5f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _playerlife = _playerlife - 1;
        }
    }

    private void OnTriggerEnter(Collider colider)
    {
        if (colider.gameObject.tag == "Enemy")
        {
            _playerlife = _playerlife - 1;
        }

    }

    void Dead()
    {
        //_Ismesh = false;
        //_Iscolider = false;
        //this.gameObject.SetActive(false);

    }
}
