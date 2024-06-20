using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move5 : MonoBehaviour
{

    [SerializeField]
    private Transform _player;

    private Quaternion _startRotation;
    private Quaternion _endRotation;
    private float _countTime;
    private bool _startRotate;
    private bool _isRotating = false; // 回転中かどうかを示すフラグ

    private Collider objectCollider; // オブジェクトのコライダー


    private void Start()
    {
        objectCollider = GetComponent<Collider>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Right_Roll") && !_isRotating)
        {
            OnKeyDownRotate(1);
        }
        else if (Input.GetButtonDown("Left_Roll") && !_isRotating)
        {
            OnKeyDownRotate(-1);
        }

        UpdateKeyDownRotate();
    }

    private void OnKeyDownRotate(int direction)
    {
        _countTime = 0f;
        _startRotation = _player.rotation;
        _endRotation = _player.rotation * Quaternion.AngleAxis(719f * direction, _player.up);
        _startRotate = true;
    }

    private void UpdateKeyDownRotate()
    {
        if (_startRotate == false)
        {
            return;
        }

        _isRotating = true;
        objectCollider.enabled = false;
        _countTime = Mathf.Clamp(_countTime + Time.deltaTime, 0f, 3f);
        float rate = _countTime / 0.5f;
        _player.rotation = Quaternion.Lerp(_startRotation, _endRotation, rate);

        if (rate >= 1f)
        {
            _startRotate = false;
            objectCollider.enabled = true;

            _isRotating = false;
        }
    }
}

