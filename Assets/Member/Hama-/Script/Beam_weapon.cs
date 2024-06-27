using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_weapon : MonoBehaviour
{
    [SerializeField]
    ParticleSystem longparticleSystem;
    [SerializeField]
    float distance = 10f;
    private BusterControl buster;
    private bool check;
    private float time;

    private void Start()
    {
        buster = GetComponent<BusterControl>();
        check = false;
        longparticleSystem.Stop();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartBeam();
        }

        if (check)
        {
            Beam();
            time += Time.deltaTime;
            if (time >= 5f)
            {
                EndBeam();
            }
        }
    }

    void StartBeam()
    {
        check = true;
        time = 0f;
        longparticleSystem.Play();
    }

    void EndBeam()
    {
        check = false;
        longparticleSystem.Stop();
    }

    void Beam()
    {
        var scale = transform.lossyScale.x * 2f;

        // レイキャストの結果を格納する変数
        RaycastHit[] hits;

        // BoxCastAllを使用してすべてのヒットを取得する
        hits = Physics.BoxCastAll(transform.position, Vector3.one * scale, transform.forward, transform.rotation, distance);

        // ヒットしたすべてのオブジェクトに対して処理を行う
        foreach (RaycastHit hit in hits)
        {
            Debug.Log("HIT");
        }

    }
}







