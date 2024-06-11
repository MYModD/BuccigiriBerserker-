using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLock : MonoBehaviour
{
    public Camera mainCamera;
    public bool _isLock ;

    private void Update()
    {
        // オブジェクトがカメラから見えているかどうかをチェックする
        CheckIfVisible();
        //Debug.Log(locksw);
    }

    void CheckIfVisible()
    {
        Vector3 objectPos = transform.position;

        Vector3 screenPos = mainCamera.WorldToViewportPoint(objectPos);
        /**
         オブジェクトがカメラのビュー内にあるかどうかをチェック
        screenpos.x >= 0 && screenpos.x <= 1 :オブジェクトのｘ座標がビューポートの幅内にあるかどうか
        screenpos.y >= 0 && screenpos.y <= 1 :オブジェクトのｙ座標がビューポートの高さ内にあるかどうか
        screenpos.z > 0 :オブジェクトのｚ座標が０より大きいかを確認する
        **/
        bool isVisible = (screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1 && screenPos.z > 0);

        if (!isVisible)
        {
            // オブジェクトがカメラのビューから見えなくなったときの処理を行う
            OnBecameInvisible();
        }

        if (isVisible)
        {
            //Debug.Log("utut");
            _isLock = true;
        }
    }

    void OnBecameInvisible()
    {
        // オブジェクトがビューから見えなくなったときの処理を記述
        //Debug.Log("Object became invisible!");
        _isLock = false;
    }
}

