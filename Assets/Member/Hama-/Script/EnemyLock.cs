using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLock : MonoBehaviour
{
    public bool locksw = false;
    private void OnBecameVisible()
    {
        //��ʂɉf���Ă����瓮��
        this.GetComponent<Renderer>().material.color = Color.red;
        locksw = true;
    }

    private void OnBecameInvisible()
    {
        //��ʉf���Ă��Ȃ��Ƃ�����
        this.GetComponent<Renderer>().material.color = Color.blue;
        locksw = false;
    }

    private void Update()
    {
        Debug.Log(locksw);
    }
}
