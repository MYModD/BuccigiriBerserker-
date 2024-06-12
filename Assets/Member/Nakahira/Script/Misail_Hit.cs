using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misail_Hit : MonoBehaviour
{
    //public Transform missile;
    public Transform player;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = player.position;
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "missile")
        {
            PooledReturn();

        }
    }
    public void PooledReturn()
    {
        this.gameObject.SetActive(false);
    }
}
