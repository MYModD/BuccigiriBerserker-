using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Misail_Hit2 : MonoBehaviour
{

    public GameObject explosionPrefab; // �����G�t�F�N�g�̃v���n�u
    public AudioSource ExplodeAudioSource;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "missile")
        {
            Explode();
            ExplodeSE();
            PooledReturn();

        }
        if (coll.gameObject.tag == "????")
        {
            Explode();
            ExplodeSE();
            PooledReturn();
            

        }
    }
    public void PooledReturn()
    {
        this.gameObject.SetActive(false);
       
    }
    void Explode()
    {
        // �����G�t�F�N�g�̃v���n�u���C���X�^���X�����Đ�������
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //Destroy(explosion, 3.0f); // �����G�t�F�N�g��3�b��ɔj������i�C�ӂ̎��ԁj
            //Destroy(this.gameObject,0.5f);
        }
        // �����ɑ��̏�����ǉ�����i�Ⴆ�΁A���̍Đ��A�I�u�W�F�N�g�̔j��Ȃǁj
    }

    void ExplodeSE()
        
    {
        if(ExplodeAudioSource != null)
        {
            ExplodeAudioSource.Play();
        }
    }

}
