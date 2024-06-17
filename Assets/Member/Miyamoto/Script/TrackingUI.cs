using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackingUI : MonoBehaviour
{    [SerializeField] private GameObject[] _enemyIncameraUI; // ��������̓G��Image

    [SerializeField] private GameObject[] _enemyInCone; // �~�����̓G��Image

    public LockOnManager lockOnManager;

    void Start()
    {
        InitializeUIElements(_enemyIncameraUI);
        InitializeUIElements(_enemyInCone);
    }

    void Update()
    {
        UpdateUIPositions(lockOnManager.targetsInCamera, _enemyIncameraUI);
        UpdateUIPositions(lockOnManager.targetsInCone, _enemyInCone);
    }


    /// <summary>
    /// UI����image�R���|�[�l���g��������
    /// </summary>
    private void InitializeUIElements(GameObject[] uiElements)
    {
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.GetComponent<Image>().enabled = false;
        }
    }

    private void UpdateUIPositions(List<Transform> targets, GameObject[] uiElements)
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if (i < uiElements.Length)
            {
                Vector3 enemyScreenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, targets[i].position);
                uiElements[i].transform.position = enemyScreenPosition;
                uiElements[i].GetComponent<Image>().enabled = true;
            }
        }

        // �]����UI�v�f���\���ɂ���
        for (int i = targets.Count; i < uiElements.Length; i++)
        {
            uiElements[i].GetComponent<Image>().enabled = false;
        }
    }
}
