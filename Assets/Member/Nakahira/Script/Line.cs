using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] LineRenderer m_line = null;
    [SerializeField, Tooltip("���x[m/sec]")] float m_speed = 0.1f;
    [SerializeField, Tooltip("���C����𓮂�Object")] Transform m_targetTr = null;
    int m_linePtr;
    float[] m_costArr;
    float m_remain;

    // Start is called before the first frame update
    void Start()
    {
        if (m_targetTr == null)
        {
            m_targetTr = transform;
        }
        init();
    }

    // Update is called once per frame
    void Update()
    {
        float delta = m_speed * Time.deltaTime;
        while (delta > 0f)
        {
            if (m_remain > delta)
            {
                m_remain -= delta;
                delta = 0f;
                break;
            }
            else
            {
                delta -= m_remain;
                if (m_linePtr == 0 && m_remain > 0f)
                {
                    // ���C���̍ŏ��̃|�C���g�ɓ��B���Ďc�肪����ꍇ�A�t�����Ɉړ�
                    m_linePtr = 1;
                    m_remain = m_costArr[m_linePtr];
                }
                else if (m_linePtr == m_line.positionCount - 1 && m_remain > 0f)
                {
                    // ���C���̍Ō�̃|�C���g�ɓ��B���Ďc�肪����ꍇ�A�t�����Ɉړ�
                    m_linePtr = m_line.positionCount - 2;
                    m_remain = m_costArr[m_linePtr];
                }
                else
                {
                    // �ʏ�̈ړ������ɐi��
                    m_linePtr = (m_linePtr + 1) % m_line.positionCount;
                    m_remain = m_costArr[m_linePtr];
                }
            }
        }

        Vector3 basePos = m_line.GetPosition(m_linePtr);
        if (m_remain > 0f)
        {
            float rate = 1f - m_remain / m_costArr[m_linePtr];
            basePos += (m_line.GetPosition((m_linePtr + 1) % m_line.positionCount) - basePos) * rate;
        }
        if (!m_line.useWorldSpace)
        {
            basePos = m_line.transform.position + Vector3.Scale(m_line.transform.rotation * basePos, m_line.transform.lossyScale);
        }
        m_targetTr.position = basePos;
    }
    private void init()
    {
        m_costArr = new float[m_line.positionCount];
        Vector3 pos = m_line.GetPosition(0);
        for (int i = 0; i < m_line.positionCount; ++i)
        {
            Vector3 nextPos = m_line.GetPosition((i + 1) % m_line.positionCount);
            m_costArr[i] = (nextPos - pos).magnitude;
            pos = nextPos;
        }
        if (!m_line.loop)
        {
            m_costArr[m_line.positionCount - 1] = 0f;
        }
        m_linePtr = 0;
        m_remain = m_costArr[0];
    }
}
