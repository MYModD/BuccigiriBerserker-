using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneAnimationTest : MonoBehaviour
{
    [Header("‰Â“®•”‚ÌTransform")]
    public Transform[] rudders; // •ûŒü‘Ç
    public Transform[] flaps; // ƒtƒ‰ƒbƒv
    public Transform[] elevator; // ¸~‘Ç

    [Header("‰Â“®”ÍˆÍ")]

    [Range(0,30f)]
    public float ruddersDegreeRange = 20f; // •ûŒü‘Ç‚Ì‰ñ“]”ÍˆÍ
    [Range(0, 30f)]
    public float flapsDegreeRange = 20f; // ƒtƒ‰ƒbƒv‚Ì‰ñ“]”ÍˆÍ
    [Range(0, 40f)]
    public float elevatorUpDownDegreeRange = 10f; // ¸~‘Ç‚Ìã‰º•ûŒü‚Ì‰ñ“]”ÍˆÍ
    [Range(0, 40f)]
    public float elevatorLeftRightDegreeRange = 10f; // ¸~‘Ç‚Ì¶‰E•ûŒü‚Ì‰ñ“]”ÍˆÍ

    [Header("‰Â“®”{—¦")]
    public float multiplyValue = 1f; // “ü—Í‚Ì”{—¦

    [Header("•âŠÔ‘¬“x")]

    [Range(0, 1f)]
    public float lerpTRudder = 0.1f; // •ûŒü‘Ç‚Ì•âŠÔ‘¬“x
    [Range(0, 1f)]
    public float lerpTFlaps = 0.1f; // ƒtƒ‰ƒbƒv‚Ì•âŠÔ‘¬“x
    [Range(0, 1f)]
    public float lerpTElevators = 0.1f; // ¸~‘Ç‚Ì•âŠÔ‘¬“x
    [Range(0, 1f)]
    public float lerpTRightLeftElevators = 0.1f; // ¸~‘Çi¶‰Ej‚Ì•âŠÔ‘¬“x

    // Start is called before the first frame update
    void Start()
    {
        // ‰Šú‰»ˆ—‚ª•K—v‚È‚ç‚±‚±‚É‹Lq
    }

    // Update is called once per frame
    void Update()
    {
        RotateRudder();
        RotateFlaps();
        RotateElevator();
    }

    // •ûŒü‘Ç‚ğ‰ñ“]‚³‚¹‚é
    private void RotateRudder()
    {
        float input = Input.GetAxis("Horizontal") * multiplyValue;
        input = Mathf.Clamp(input, -ruddersDegreeRange, ruddersDegreeRange);
        Vector3 rotation = new Vector3(0, input, 0);
        Quaternion targetRotation = Quaternion.Euler(-rotation);
        Quaternion currentRotation = Quaternion.Lerp(rudders[0].transform.rotation, targetRotation, lerpTRudder);

        rudders[0].transform.rotation = currentRotation;
        rudders[1].transform.rotation = currentRotation;
    }

    // ƒtƒ‰ƒbƒv‚ğ‰ñ“]‚³‚¹‚é
    private void RotateFlaps()
    {
        float input = Input.GetAxis("Vertical") * multiplyValue;
        input = Mathf.Clamp(input, -flapsDegreeRange, flapsDegreeRange);
        Vector3 rotation = new Vector3(input, 0, 0);
        Quaternion targetRotation = Quaternion.Euler(-rotation);
        Quaternion currentRotation = Quaternion.Lerp(flaps[1].transform.rotation, targetRotation, lerpTFlaps);

        flaps[0].transform.rotation = currentRotation;
        flaps[1].transform.rotation = currentRotation;
    }

    // ¸~‘Ç‚ğ‰ñ“]‚³‚¹‚é
    private void RotateElevator()
    {
        RotateElevatorUpDown();
        RotateElevatorLeftRight();
    }

    // ¸~‘Ç‚ğã‰º‚É‰ñ“]‚³‚¹‚é
    private void RotateElevatorUpDown()
    {
        float input = Input.GetAxis("Vertical") * multiplyValue;
        input = Mathf.Clamp(input, -elevatorUpDownDegreeRange, elevatorUpDownDegreeRange);
        Vector3 rotation = new Vector3(input, 0, 0);
        Quaternion targetRotation = Quaternion.Euler(-rotation);
        Quaternion currentRotation = Quaternion.Lerp(elevator[0].transform.rotation, targetRotation, lerpTElevators);

        elevator[0].transform.rotation = currentRotation;
        elevator[1].transform.rotation = currentRotation;
    }

    // ¸~‘Ç‚ğ¶‰E‚É‰ñ“]‚³‚¹‚é
    private void RotateElevatorLeftRight()
    {
        float input = Input.GetAxis("Horizontal") * multiplyValue;
        input = Mathf.Clamp(input, -elevatorLeftRightDegreeRange, elevatorLeftRightDegreeRange);
        Vector3 rotation = new Vector3(input, 0, 0);
        Quaternion targetRotation1 = Quaternion.Euler(rotation);
        Quaternion targetRotation2 = Quaternion.Euler(-rotation);

        Quaternion currentRotation1 = Quaternion.Lerp(elevator[0].transform.rotation, targetRotation1, lerpTRightLeftElevators);
        Quaternion currentRotation2 = Quaternion.Lerp(elevator[1].transform.rotation, targetRotation2, lerpTRightLeftElevators);

        elevator[0].transform.rotation = currentRotation1;
        elevator[1].transform.rotation = currentRotation2;
    }
}
