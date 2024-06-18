using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranteki : MonoBehaviour
{
    public float speed = 5f; // �ړ����x
    public float rangeX = 5f; // X�������̈ړ��͈�
    public float rangeY = 5f; // Y�������̈ړ��͈�

    private Vector3 initialPosition; // �����ʒu
    private float timeCounter = 0f;

    void Start()
    {
        // �����ʒu��ێ�
        initialPosition = transform.position;
    }

    void Update()
    {
        // X�������̐U��
        float x = initialPosition.x + Mathf.Sin(timeCounter) * rangeX;
        // Y�������̐U��
        float y = initialPosition.y + Mathf.Cos(timeCounter) * rangeY;

        // �V�����ʒu��ݒ�
        Vector3 newPosition = new Vector3(x, y, transform.position.z);
        // �ړ�
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        // ���Ԃ��X�V
        timeCounter += Time.deltaTime;
    }
}
