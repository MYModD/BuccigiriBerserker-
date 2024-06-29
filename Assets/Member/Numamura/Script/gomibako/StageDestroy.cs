using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDestroy : MonoBehaviour
{
    // Update is called once per frame
    public GameObject _player;

    // �v���C���[�Ƃ̍ő勗��
    public float _maxDistance = 7000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        if (_player != null)
        {
            // �v���C���[��z���W���擾
            float playerZ = _player.transform.position.z;

            // ������z���W���擾
            float myZ = transform.position.z;

            // �v���C���[�Ƃ̋������v�Z
            float distance = Mathf.Abs(playerZ - myZ);

            // �v���C���[�Ƃ̋������ő勗�����傫���ꍇ
            if (distance >= _maxDistance)
            {
                // ������j�󂷂�
                Destroy(gameObject);
            }
        }
    }
}
    

