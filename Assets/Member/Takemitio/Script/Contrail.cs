using UnityEngine;

public class MultipleTrailRendererController : MonoBehaviour
{
    public float minRotationAngle = -45f; // �ŏ��̉�]�p�x
    public float maxRotationAngle = 45f;  // �ő�̉�]�p�x
    public TrailRenderer[] trailRenderers; // TrailRenderer�̔z��

    void Update()
    {
        // �e�I�u�W�F�N�g�̌��݂̉�]�p�x���擾����
        float currentRotation = transform.rotation.eulerAngles.z;

        // ��]�p�x���w�肳�ꂽ�͈͓��ɂ��邩�ǂ������`�F�b�N����
        if (currentRotation >= minRotationAngle && currentRotation <= maxRotationAngle)
        {
            // �w��͈͓��ɂ���ꍇ�͑S�Ă�TrailRenderer�𖳌��ɂ���
            foreach (TrailRenderer renderer in trailRenderers)
            {
                if (renderer != null && renderer.enabled)
                {
                    renderer.enabled = false;
                }
            }
        }
        else
        {
            // �w��͈͊O�ɂ���ꍇ�͑S�Ă�TrailRenderer��L���ɂ���
            foreach (TrailRenderer renderer in trailRenderers)
            {
                if (renderer != null && !renderer.enabled)
                {
                    renderer.enabled = true;
                }
            }
        }
    }
}
