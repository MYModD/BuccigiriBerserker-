using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranteki : MonoBehaviour
{
    public float speed = 5f; // 移動速度
    public float rangeX = 5f; // X軸方向の移動範囲
    public float rangeY = 5f; // Y軸方向の移動範囲

    private Vector3 initialPosition; // 初期位置
    private float timeCounter = 0f;

    void Start()
    {
        // 初期位置を保持
        initialPosition = transform.position;
    }

    void Update()
    {
        // X軸方向の振動
        float x = initialPosition.x + Mathf.Sin(timeCounter) * rangeX;
        // Y軸方向の振動
        float y = initialPosition.y + Mathf.Cos(timeCounter) * rangeY;

        // 新しい位置を設定
        Vector3 newPosition = new Vector3(x, y, transform.position.z);
        // 移動
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        // 時間を更新
        timeCounter += Time.deltaTime;
    }
}
