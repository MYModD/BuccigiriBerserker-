using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    float playerLife = 5;
    [SerializeField]
    float spawnSpeed = 50.0f;

    public bool _IsRetry = false;

    private MoveMiyamotoTest move;

    private Animator anim;
    private Vector3 originalPosition;

    void Start()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<MoveMiyamotoTest>();
        originalPosition = transform.position;
    }

    void Update()
    {
        if (playerLife == 0)
        {
            _IsRetry = true;
            // originalPosition = transform.position;  // この行は不要です（Start()で既に設定済み）
            StartCoroutine(Respawn());
        }

        if (playerLife > 0)
        {
            anim.SetBool("invincible", false);  // パラメーター名を修正
            anim.SetBool("Normal", true);       // パラメーター名を修正
            _IsRetry = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerLife--;
        }
    }

    IEnumerator Respawn()
    {
        move.enabled = false;
        // プレイヤーが後ろに動く距離（例としてspawnSpeed * 5秒分後退）
        float moveDistance = spawnSpeed * 5 * Time.deltaTime;

        // 後退開始
        while (transform.position.z > originalPosition.z - moveDistance)
        {
            transform.Translate(Vector3.forward * spawnSpeed * Time.deltaTime);  // 後ろに動かすためにbackを使用
            yield return null;
        }

        anim.SetBool("invincible", true);   // パラメーター名を修正
        anim.SetBool("Normal", false);      // パラメーター名を修正

        yield return new WaitForSeconds(3f);

        // 後退後のアニメーションの後に必要な処理を記述する
        // 例えば、位置のリセットや他の処理を行う
        transform.position = originalPosition; // 位置を元に戻す（実際のゲームに合わせて適切な位置に）
        playerLife = 5; // プレイヤーのライフをリセットする（実際のゲームに合わせて適切な値に）

        // アニメーションのリセットなどもここで行う
        anim.SetBool("invincible", false);  // パラメーター名を修正
        anim.SetBool("Normal", true);       // パラメーター名を修正
        move.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            playerLife--;
        }
    }
}
