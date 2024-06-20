using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Misail_Hit2 : MonoBehaviour
{

    public GameObject explosionPrefab; // 爆発エフェクトのプレハブ
    public AudioClip Explosion1;
    AudioSource audioSource;
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
            PooledReturn();
            Explode();

        }
        if (coll.gameObject.tag == "????")
        {
            PooledReturn();
            Explode();

        }
    }
    public void PooledReturn()
    {
        this.gameObject.SetActive(false);
       
    }
    void Explode()
    {
        // 爆発エフェクトのプレハブをインスタンス化して生成する
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //Destroy(explosion, 3.0f); // 爆発エフェクトを3秒後に破棄する（任意の時間）
            //Destroy(this.gameObject,0.5f);
        }
        audioSource.PlayOneShot(Explosion1);
        // ここに他の処理を追加する（例えば、音の再生、オブジェクトの破壊など）
    }

}
