using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MoveMiyamotoTest : MonoBehaviour
{
    //private const float threshold = 0.5f;

    [Range(0, 90f)]
    public float yokoRange;

    [Range(0, 90f)]
    public float tateRange;

    [Range(0, 1f)]
    public float yokoLerpT;

    [Range(0, 1f)]
    public float tateLerpT;

    private Rigidbody rb;

    private float holizontalValue;

    private float verticalValue;

    private Vector3 Player_pos;

    private new Rigidbody rigidbody;

    [SerializeField]
    float speed = 5f;
    [SerializeField]
    Vector2 _moveMinMaxX;
    [SerializeField]
    Vector2 _moveMinMaxY;
    




    public float multiplyAxis = 40f;
    


    private float rotationSpeed = 45f;
    private float rotationx = 0f;
    private float rotationz = 0f;          // zé≤ÇÃâÒì]äpìx
    private float resetTime = 30f;
    private float rotaiony = 180f;
    private Roll_Move roll_move;
    private Vector3 startPostion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        roll_move = GetComponent<Roll_Move>(); // Ç±Ç±Ç≈èCê≥
        startPostion = transform.position;
    }

    // Update is called once per frame




    // Update is called once per frame
    void RollMove()
    {


        if (roll_move._isRotating == false)
        {
            holizontalValue = Input.GetAxisRaw("Horizontal") * multiplyAxis * -1f;

            verticalValue = Input.GetAxisRaw("Vertical") * multiplyAxis;



            holizontalValue = Mathf.Clamp(holizontalValue,yokoRange * -1,yokoRange);
            verticalValue = Mathf.Clamp(holizontalValue, tateRange * -1, tateRange);


            Vector3 yokoidou = new Vector3( verticalValue, transform.rotation.y +180f,    holizontalValue);


            Quaternion hoge = Quaternion.Slerp(transform.rotation, Quaternion.Euler(yokoidou), yokoLerpT);

            rb.rotation = hoge;

            
            

        }

    }





    private void FixedUpdate()
    {
        RollMove();
        
        
        holizontalValue = Input.GetAxisRaw("Horizontal");

        verticalValue = Input.GetAxisRaw("Vertical") * -1f;




        float postionX = transform.position.x + (multiplyAxis * Time.fixedDeltaTime * holizontalValue);
        postionX = Mathf.Clamp(postionX, startPostion.x + _moveMinMaxX.x, startPostion.x + _moveMinMaxX.y);


        float postionY = transform.position.y + (multiplyAxis * Time.fixedDeltaTime * verticalValue);
        postionY = Mathf.Clamp(postionY, startPostion.y + _moveMinMaxY.x, startPostion.y + _moveMinMaxY.y);


        float postionZ = transform.position.z + (speed * Time.fixedDeltaTime);

        rb.MovePosition(new Vector3(postionX, postionY, postionZ));








        
    }

}
