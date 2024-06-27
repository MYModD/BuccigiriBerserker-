using UnityEngine;

public class Retry_Player : MonoBehaviour
{
    private PlayerLife playerLife;
    public GameObject[] childObjects; // Transform�ł͂Ȃ�GameObject�̔z��ɏC��

    void Start()
    {
        playerLife = GetComponent<PlayerLife>();
        SetMeshRenderersEnabled(true); // ������Ԃł̓��b�V�������_���[��\������
    }

    void Update()
    {
        // �v���C���[��_IsRetry�t���O�ɉ����ă��b�V�������_���[�̕\���E��\����؂�ւ���
        if (playerLife._IsRetry)
        {
            SetMeshRenderersEnabled(false); // ���b�V�������_���[���\���ɂ���
        }
        else
        {
            SetMeshRenderersEnabled(true); // ���b�V�������_���[��\������
        }
    }

    // ���b�V�������_���[�̕\���E��\�����ꊇ�Őݒ肷�郁�\�b�h
    private void SetMeshRenderersEnabled(bool enabled)
    {
        foreach (GameObject obj in childObjects)
        {
            MeshRenderer childRenderer = obj.GetComponent<MeshRenderer>();
            if (childRenderer != null)
            {
                childRenderer.enabled = enabled;
            }
            else
            {
                Debug.LogWarning("MeshRenderer not found on child object: " + obj.name);
            }
        }
    }

}
