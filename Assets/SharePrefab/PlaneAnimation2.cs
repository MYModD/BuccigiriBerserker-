using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAnimation2 : MonoBehaviour
{
    [Header("可動部のTransform")]
    public Transform[] rudders; // 方向舵
    public Transform[] flaps; // フラップ
    public Transform[] elevator; // 昇降舵

    [Header("可動範囲")]

    [Range(0, 30f)]
    public float ruddersDegreeRange = 20f; // 方向舵の回転範囲
    [Range(0, 30f)]
    public float flapsDegreeRange = 10f; // フラップの回転範囲
    [Range(0, 40f)]
    public float elevatorUpDownDegreeRange = 40f; // 昇降舵の上下方向の回転範囲
    [Range(0, 40f)]
    public float elevatorLeftRightDegreeRange = 30f; // 昇降舵の左右方向の回転範囲

    [Header("可動倍率")]
    public float multiplyValue = 40f; // 入力の倍率

    [Header("補間速度")]

    [Range(0, 1f)]
    public float lerpTRudder = 0.1f; // 方向舵の補間速度
    [Range(0, 1f)]
    public float lerpTFlaps = 0.01f; // フラップの補間速度
    [Range(0, 1f)]
    public float lerpTElevators = 0.54f; // 昇降舵の補間速度
    [Range(0, 1f)]
    public float lerpTRightLeftElevators = 0.5f; // 昇降舵（左右）の補間速度

    // Start is called before the first frame update
    void Start()
    {
        // 初期化処理が必要ならここに記述
    }

    // Update is called once per frame
    void Update()
    {
        RotateRudder();
        RotateFlaps();
        RotateElevator();
    }

    // 方向舵を回転させる
    private void RotateRudder()
    {
        float input = Input.GetAxis("Horizontal") * multiplyValue;
        input = Mathf.Clamp(input, -ruddersDegreeRange, ruddersDegreeRange);
        Vector3 rotation = new Vector3(0, input, 0);
        Quaternion targetRotation = Quaternion.Euler(-rotation);
        Quaternion currentRotation = Quaternion.Lerp(rudders[0].transform.localRotation, targetRotation, lerpTRudder);

        rudders[0].transform.localRotation = currentRotation;
        rudders[1].transform.localRotation = currentRotation;
    }

    // フラップを回転させる
    private void RotateFlaps()
    {
        float input = Input.GetAxis("Vertical") * multiplyValue;
        input = Mathf.Clamp(input, -flapsDegreeRange, flapsDegreeRange);
        Vector3 rotation = new Vector3(input, 0, 0);
        Quaternion targetRotation = Quaternion.Euler(-rotation);
        Quaternion currentRotation = Quaternion.Lerp(flaps[1].transform.localRotation, targetRotation, lerpTFlaps);

        Debug.Log(currentRotation.eulerAngles);

        flaps[0].transform.localRotation = currentRotation;
        flaps[1].transform.localRotation = currentRotation;
    }

    // 昇降舵を回転させる
    private void RotateElevator()
    {
        RotateElevatorUpDown();
        RotateElevatorLeftRight();
    }

    // 昇降舵を上下に回転させる
    private void RotateElevatorUpDown()
    {
        float input = Input.GetAxis("Vertical") * multiplyValue;
        input = Mathf.Clamp(input, -elevatorUpDownDegreeRange, elevatorUpDownDegreeRange);
        Vector3 rotation = new Vector3(input, 0, 0);
        Quaternion targetRotation = Quaternion.Euler(-rotation);
        Quaternion currentRotation = Quaternion.Lerp(elevator[0].transform.localRotation, targetRotation, lerpTElevators);

        elevator[0].transform.localRotation = currentRotation;
        elevator[1].transform.localRotation = currentRotation;
    }

    // 昇降舵を左右に回転させる
    private void RotateElevatorLeftRight()
    {
        float input = Input.GetAxis("Horizontal") * multiplyValue;
        input = Mathf.Clamp(input, -elevatorLeftRightDegreeRange, elevatorLeftRightDegreeRange);
        Vector3 rotation = new Vector3(input, 0, 0);
        Quaternion targetRotation1 = Quaternion.Euler(rotation);
        Quaternion targetRotation2 = Quaternion.Euler(-rotation);

        Quaternion currentRotation1 = Quaternion.Lerp(elevator[0].transform.localRotation, targetRotation1, lerpTRightLeftElevators);
        Quaternion currentRotation2 = Quaternion.Lerp(elevator[1].transform.localRotation, targetRotation2, lerpTRightLeftElevators);

        elevator[0].transform.localRotation = currentRotation1;
        elevator[1].transform.localRotation = currentRotation2;
    }
}
