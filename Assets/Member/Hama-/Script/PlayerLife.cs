using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] GameObject player;

    public float _playerlife = 5;

    private float spawnspeed = 20.0f;

    public bool _IsRetry;

    private Animator anim = null;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {


        if (_playerlife == 0)
        {

            _IsRetry = true;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - spawnspeed * Time.deltaTime);
            Invoke(nameof(refresh), 5f);
            anim.SetBool("invincible", true);
            anim.SetBool("Normal", false);

        }

        if (_playerlife >= 5)
        {
            anim.SetBool("invincible", false);
            anim.SetBool("Normal", true);
            _IsRetry = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
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

    void refresh()
    {

        _playerlife = 5;

    }
}
