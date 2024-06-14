using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public Transform enemyTransform;
    [Range(0, 1f)]
    public float lerpT = 0.5f; // �f�t�H���g�l��ݒ�

    // Update is called once per frame
    private void Update()
    {
        if (enemyTransform != null)
        {
            // �G�Ƃ̈ʒu�̍����擾
            Vector3 direction = enemyTransform.position - transform.position;

            // ���������݂̂ɉ�]������ꍇ�iY�������b�N�j
            direction.y = 0;

            // ��]�ʂ��v�Z
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // ��]���X���[�Y�ɕ��
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lerpT);
        }
    }
}
