using UnityEngine;

public class exefe : MonoBehaviour
{
    
    public GameObject explosionPrefab; // �����G�t�F�N�g�̃v���n�u
    public AudioClip Explosion1;
    AudioSource audioSource;
    void Start()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        // �Փˎ��ɔ����G�t�F�N�g�𐶐�����
        Debug.Log("ok");
        Explode();
    }

    void Explode()
    {
        // �����G�t�F�N�g�̃v���n�u���C���X�^���X�����Đ�������
        if (explosionPrefab != null)
        {
            
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            
            //Destroy(explosion, 3.0f); // �����G�t�F�N�g��3�b��ɔj������i�C�ӂ̎��ԁj
            //Destroy(this.gameObject,0.5f);

        }audioSource.PlayOneShot(Explosion1);

        // �����ɑ��̏�����ǉ�����i�Ⴆ�΁A���̍Đ��A�I�u�W�F�N�g�̔j��Ȃǁj
    }
}
