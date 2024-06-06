using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    private float distancex;

    private float distancey;

    private float forcex;

    private float forcey;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("f15");

        forcex = 0f;
        forcey = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        float x = player.transform.position.x;

        float y = player.transform.position.y;

        float z = player.transform.position.z;

        distancex = this.transform.position.x - player.transform.position.x;

        if(distancex > 40f)
        {
            forcex = x;
        }

        if (distancex < -40f)
        {
            forcex = x;
        }

        if(distancey > 40f)
        {
            forcey = y;
        }

        if(distancey < -40f)
        {
            forcey = y;
        }

        Debug.Log(distancex);
        this.transform.position = new Vector3(forcex * Time.deltaTime * 100, forcey * Time.deltaTime * 100 , z + 20);
    }
}
