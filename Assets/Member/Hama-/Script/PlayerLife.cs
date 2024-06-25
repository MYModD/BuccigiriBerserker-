using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] GameObject player;

    private float _playerlife = 5;

    private float spawnspeed = 50.0f;

    public bool _IsRetry;

    // Update is called once per frame
    void Update()
    {
        if (_playerlife == 0)
        {

            _IsRetry = true;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - spawnspeed * Time.deltaTime);
            //アニメーションで無敵時間再現したいな
            Invoke(nameof(refresh), 3f);
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
        Debug.Log("NAKAHIRA");
        _playerlife = 5;

    }
}
