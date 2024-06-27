using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_weapon : MonoBehaviour
{

    [SerializeField] private ParticleSystem particle;
    [SerializeField]
    float distance = 10f;
    public BusterControl buster;
    private bool check;


    private void Start()
    {

        // もしまだアタッチされていない場合は、ここで GetComponent を使って初期化する
        if (buster == null)
        {
            buster = GetComponent<BusterControl>();
        }
        check = false;


        if (particle == null)
        {
            particle = GetComponent<ParticleSystem>();
        }

        StopParticle();




    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            particle.Play();

        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            particle.Stop();
        }

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

    private void StartBeam()
    {
        particle = GetComponent<ParticleSystem>();
        Debug.Log("START");
        check = true;
        // パーティクルシステムを再生す


    }

    private void EndBeam()
    {
        particle = GetComponent<ParticleSystem>();
        Debug.Log("END");
        check = false;
        // パーティクルシステムを停止する
        StopParticle();

    }

    private void StopParticle()
    {
        // パーティクルが再生中であれば停止する
        if (particle.isPlaying)
        {
            particle.Stop();
        }
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

        particle.Play();

    }


}







