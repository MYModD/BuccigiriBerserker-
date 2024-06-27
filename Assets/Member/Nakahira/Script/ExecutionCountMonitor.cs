using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionCountMonitor : MonoBehaviour
{
    private List<MethodExecutionCounter> counters = new List<MethodExecutionCounter>();

    private void Start()
    {
        // シーン内のすべての MethodExecutionCounter を取得する
        MethodExecutionCounter[] allCounters = FindObjectsOfType<MethodExecutionCounter>();
        counters.AddRange(allCounters);
    }

    private void Update()
    {
        // 非アクティブになったオブジェクトの実行回数を取得して表示する
        for (int i = counters.Count - 1; i >= 0; i--)
        {
            MethodExecutionCounter counter = counters[i];
            if (!counter.gameObject.activeSelf)
            {
                int count = counter.GetExecutionCount();
                Debug.Log($"オブジェクト {counter.gameObject.name} の実行回数: {count}");

                // リストから削除する
                counters.RemoveAt(i);
            }
        }
    }
}
