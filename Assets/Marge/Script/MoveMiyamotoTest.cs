using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMiyamotoTest : MonoBehaviour
{
    //private const float threshold = 0.5f;

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
    private float rotationz = 0f;          // z軸の回転角度
    private float resetTime = 30f;
    private float rotaiony = 180f;
    private Roll_Move roll_move;
    private Vector3 startPostion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        roll_move = GetComponent<Roll_Move>(); // ここで修正
        startPostion = transform.position;
    }

    // Update is called once per frame




    // Update is called once per frame
    void RollMove()
    {


        if (roll_move._isRotating == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Z軸の回転
            float rotationChangez = horizontalInput * rotationSpeed * Time.fixedDeltaTime * 5;
            rotationz += rotationChangez;
            rotationz = Mathf.Clamp(rotationz, -rotationSpeed, rotationSpeed);

            // X軸の回転
            float rotationChangex = verticalInput * -rotationSpeed * Time.fixedDeltaTime * 5;
            rotationx += rotationChangex;
            rotationx = Mathf.Clamp(rotationx, -rotationSpeed, rotationSpeed);

            // 入力がないかつ回転が残っている場合、リセット
            if (horizontalInput == 0 && verticalInput == 0 && (rotationx != 0 || rotationz != 0))
            {
                float resetAmount = resetTime * Time.fixedDeltaTime * 5;
                if (rotationx != 0)
                {
                    rotationx = Mathf.MoveTowards(rotationx, 0f, resetAmount);
                }
                if (rotationz != 0)
                {
                    rotationz = Mathf.MoveTowards(rotationz, 0f, resetAmount);
                }
            }

            // プレイヤーの回転を適用
            transform.rotation = Quaternion.Euler(rotationx, rotaiony, rotationz);
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

        //// プレイヤーの前進方向ベクトルを計算
        //Vector3 moveDirection = Vector3.forward;

        //// プレイヤーの移動方向を左右および上下の入力に基づいて調整します
        //moveDirection += Vector3.right * HolizontalValue;

        //moveDirection += Vector3.down * VerticalValue;

        //// Rigidbody に力を加えて移動させます
        //rb.velocity = moveDirection.normalized * speed;

        //// Rigidbodyに速度を与えて移動させる
        //rb.velocity = moveDirection * speed;
    }

}
