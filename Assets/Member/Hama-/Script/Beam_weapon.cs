using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_weapon : MonoBehaviour
{
    [SerializeField]
    ParticleSystem longparticleSystem;
    [SerializeField]
    float distance = 10f;
    public BusterControl buster;
    private bool check;
    private float time;

    private void Start()
    {

        // もしまだアタッチされていない場合は、ここで GetComponent を使って初期化する
        if (buster == null)
        {
            buster = GetComponent<BusterControl>();
        }
        check = false;
        if (longparticleSystem == null)
        {
            longparticleSystem = GetComponent<ParticleSystem>();
        }

        longparticleSystem.Stop();
    }

    private void Update()
    {
        if (buster._Beamshot)
        {
            StartBeam();
        }

        if (check)
        {
            Beam();
        }

        if (check && !buster._Beamshot)
        {
            EndBeam();
        }
    }

    void StartBeam()
    {

        check = true;
        time = 0f;
        // パーティクルシステムを再生する

        longparticleSystem.Play();

    }

    void EndBeam()
    {
        check = false;
        // パーティクルシステムを停止する
        longparticleSystem.Stop();

    }

    void Beam()
    {
        var scale = transform.lossyScale.x * 2f;

        // ボックスのサイズを定義する変数
        Vector3 boxSize = new Vector3(6f, 6f, 2f);

        // レイキャストの結果を格納する変数
        RaycastHit[] hits;

        // BoxCastAllを使用してすべてのヒットを取得する
        hits = Physics.BoxCastAll(transform.position, boxSize, transform.forward, transform.rotation, distance);

        // ヒットしたすべてのオブジェクトに対して処理を行う
        foreach (RaycastHit hit in hits)
        {
            Debug.Log("HIT");
        }

    }
}







