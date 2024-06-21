using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlaneAnimationTEst : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] rudders;

    public Transform[] flaps;

    public Transform[] elevator;

    public Vector2 ruddersDegreeRange = new Vector2(-20, 20);

    public Vector2 flapsDegreeRagne = new Vector2(-20, 20);

    public Vector2 elevatorDegreeRagne = new Vector2(-10, 10);

    public Vector2 elevator222DegreeRagne = new Vector2(-10, 10);

    public float multiplyValue = 1f;


    public float lerpTRudder = 0.1f;
    public float lerpTFlaps = 0.1f; 
    public float lerptElevators = 0.1f;
    public float lerpt222Elevators = 0.1f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateRudder();
        RotateFlaps();
        RotateElevator();


        




    }


    private void RotateRudder()
    {
        float hoge = Input.GetAxis("Horizontal") * multiplyValue;

        hoge = Mathf.Clamp(hoge, ruddersDegreeRange.x, ruddersDegreeRange.y);

        Vector3 hoges = new Vector3(0, hoge, 0);

       

        Quaternion huga = Quaternion.Euler(-1 * hoges);




        var hogehoge = Quaternion.Lerp(rudders[0].transform.rotation, huga, lerpTRudder);

        rudders[0].transform.rotation = hogehoge;
        rudders[1].transform.rotation = hogehoge;

    }


    private void RotateFlaps()
    {
        float vertical = Input.GetAxis("Vertical") * multiplyValue;

        vertical = Mathf.Clamp(vertical, flapsDegreeRagne.x, flapsDegreeRagne.y);

        Vector3 toQua = new Vector3(vertical, 0, 0);

        Quaternion hugahuga = Quaternion.Euler(-1 * toQua);

        var hogehoge = Quaternion.Lerp(flaps[1].transform.rotation, hugahuga, lerpTFlaps);

        flaps[0].transform.rotation = hogehoge;
        flaps[1].transform.rotation = hogehoge;

    }

    private void RotateElevator()
    {
        UpDownRoate();
        LeftRightRoate();
    }

    private void UpDownRoate()
    {
        float vertical = Input.GetAxis("Vertical") * multiplyValue;

        vertical = Mathf.Clamp(vertical, elevatorDegreeRagne.x, elevatorDegreeRagne.y);

        Vector3 toQua = new Vector3(vertical, 0, 0);

        Quaternion hugahuga = Quaternion.Euler(-1 * toQua);

        var hogehoge = Quaternion.Lerp(elevator[0].transform.rotation, hugahuga, lerptElevators);

        elevator[0].transform.rotation = hogehoge;
        elevator[1].transform.rotation = hogehoge;

    }

    private void LeftRightRoate()
    {
        float hoge = Input.GetAxis("Horizontal") * 50f;

        hoge = Mathf.Clamp(hoge, elevator222DegreeRagne.x, elevator222DegreeRagne.y);

        Vector3 hoges = new Vector3(hoge, 0, 0);

        Quaternion hugahuga = Quaternion.Euler(hoges);
        Quaternion hugahuga2 = Quaternion.Euler(hoges * -1);

        Debug.Log($"{hugahuga}{hugahuga2}");

        var hogehoge = Quaternion.Lerp(elevator[0].transform.rotation, hugahuga, lerpt222Elevators);
        var hohogege2 = Quaternion.Lerp(elevator[1].transform.rotation, hugahuga2, lerpt222Elevators);

        elevator[0].transform.rotation = hogehoge;
        elevator[1].transform.rotation = hohogege2;


    }
}
