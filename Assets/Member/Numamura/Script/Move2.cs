using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    
    public float moveSpeed = 5f; // プレイヤーの移動速度
    public float returnSpeed = 2f; // 元の位置に戻る速度

    private Vector3 targetPosition; // 目標位置
    private bool isMoving = false; // プレイヤーが移動中かどうかのフラグ

    void Update()
    {
        // 入力を受け取り、目標位置を更新
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
        if (moveDirection.magnitude >= 0.1f)
        {
            isMoving = true;
            targetPosition = transform.position + moveDirection;
        }
        else
        {
            isMoving = false;
        }

        // プレイヤーを移動させる
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            // 元の位置に戻る
            transform.position = Vector3.MoveTowards(transform.position, transform.parent.position, returnSpeed * Time.deltaTime);
        }
    }
}

