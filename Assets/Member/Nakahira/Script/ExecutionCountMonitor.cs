using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionCountMonitor : MonoBehaviour
{
    private List<MethodExecutionCounter> counters = new List<MethodExecutionCounter>();

    private void Start()
    {
        // �V�[�����̂��ׂĂ� MethodExecutionCounter ���擾����
        MethodExecutionCounter[] allCounters = FindObjectsOfType<MethodExecutionCounter>();
        counters.AddRange(allCounters);
    }

    private void Update()
    {
        // ��A�N�e�B�u�ɂȂ����I�u�W�F�N�g�̎��s�񐔂��擾���ĕ\������
        for (int i = counters.Count - 1; i >= 0; i--)
        {
            MethodExecutionCounter counter = counters[i];
            if (!counter.gameObject.activeSelf)
            {
                int count = counter.GetExecutionCount();
                Debug.Log($"�I�u�W�F�N�g {counter.gameObject.name} �̎��s��: {count}");

                // ���X�g����폜����
                counters.RemoveAt(i);
            }
        }
    }
}
