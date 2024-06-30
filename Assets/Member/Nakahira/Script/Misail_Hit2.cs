using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Misail_Hit2 : MonoBehaviour
{
    public Collider hako;
    private MeshRenderer childRenderer ;
    public int DesEne;
    public int _desEne { get => DesEne; }
    public GameObject explosionPrefab; // 爆発エフェクトのプレハブ
    public AudioSource ExplodeAudioSource;
    void Start()
    {
        childRenderer = GetComponentInChildren<MeshRenderer>();
        DesEne = 0;
      
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Missile")
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
        childRenderer = GetComponentInChildren<MeshRenderer>();
        DesEne = +1;
        childRenderer.enabled = false;
        hako.enabled = false;
        //this.gameObject.SetActive(false);
       
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
        // ここに他の処理を追加する（例えば、音の再生、オブジェクトの破壊など）
    }

    void ExplodeSE()
        
    {
        if(ExplodeAudioSource != null)
        {
            ExplodeAudioSource.Play();
        }
    }

}
