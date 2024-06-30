using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodExecutionCounter : MonoBehaviour
{
    private int executionCount = 0;

    public void ExecuteMethod()
    {
        // ���\�b�h�̓��e

        // ���s�񐔂��C���N�������g
        executionCount++;

        // ���g�̃I�u�W�F�N�g���A�N�e�B�u�ɂ���
        this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "missile")
        {

            ExecuteMethod();

        }
        if (coll.gameObject.tag == "????")
        {

            ExecuteMethod();


        }
    }
   

    public int GetExecutionCount()
    {
        return executionCount;
    }
}
