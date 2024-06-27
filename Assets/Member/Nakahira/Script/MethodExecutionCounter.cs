using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodExecutionCounter : MonoBehaviour
{
    private int executionCount = 0;

    public void ExecuteMethod()
    {
        // メソッドの内容

        // 実行回数をインクリメント
        executionCount++;

        // 自身のオブジェクトを非アクティブにする
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
