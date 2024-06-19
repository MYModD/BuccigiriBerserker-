using UnityEngine;

public class exefe : MonoBehaviour
{
    
    public GameObject explosionPrefab; // 爆発エフェクトのプレハブ
    public AudioClip Explosion1;
    AudioSource audioSource;
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        // 衝突時に爆発エフェクトを生成する
        Debug.Log("ok");
        Explode();
    }

    void Explode()
    {
        // 爆発エフェクトのプレハブをインスタンス化して生成する
        if (explosionPrefab != null)
        {
            
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            
            //Destroy(explosion, 3.0f); // 爆発エフェクトを3秒後に破棄する（任意の時間）
            //Destroy(this.gameObject,0.5f);

        }audioSource.PlayOneShot(Explosion1);

        // ここに他の処理を追加する（例えば、音の再生、オブジェクトの破壊など）
    }
}
