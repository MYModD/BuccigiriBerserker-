using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackingUI : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyIncameraUI; // 視錐台内の敵のImage
    [SerializeField] private GameObject[] _enemyInCone; // 円錐内の敵のImage

    public LockOnManager lockOnManager;

    private Image[] _enemyInCameraImages;               //キャッシュ用の
                                                        //Imageコンポーネント
    private Image[] _enemyInConeImages;

    void Start()
    {
        _enemyInCameraImages = InitializeUIElements(_enemyIncameraUI);
        _enemyInConeImages = InitializeUIElements(_enemyInCone);
    }

    void Update()
    {
        UpdateUIPositions(lockOnManager.targetsInCamera, _enemyInCameraImages);

        if(lockOnManager.isSpecial == true)
        {
            UpdateUIPositions(lockOnManager.targetsInCone, _enemyInConeImages);
        }
        else
        {
            for (int i = 0; i < lockOnManager.targetsInSide.Length; i++)
            {
                if (i < _enemyInConeImages.Length)
                {
                    Vector3 enemyScreenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, lockOnManager.targetsInSide[i].position);
                    _enemyInConeImages[i].transform.position = enemyScreenPosition;
                    _enemyInConeImages[i].enabled = true;
                }
            }

            // 余ったUI要素を非表示にする
            for (int i = lockOnManager.targetsInSide.Length; i < _enemyInConeImages.Length; i++)
            {
                _enemyInConeImages[i].enabled = false;
            }
        }

        
    }

    /// <summary>
    /// UI内のImageコンポーネントを初期化し、キャッシュを作成
    /// </summary>
    private Image[] InitializeUIElements(GameObject[] uiElements)
    {
        Image[] images = new Image[uiElements.Length];
        for (int i = 0; i < uiElements.Length; i++)
        {
            images[i] = uiElements[i].GetComponent<Image>();
            images[i].enabled = false;
        }
        return images;
    }


    /// <summary>
    /// updateごとに
    /// </summary>
    private void UpdateUIPositions(List<Transform> targets, Image[] uiElements)
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if (i < uiElements.Length)
            {
                Vector3 enemyScreenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, targets[i].position);
                uiElements[i].transform.position = enemyScreenPosition;
                uiElements[i].enabled = true;
            }
        }

        // 余ったUI要素を非表示にする
        for (int i = targets.Count; i < uiElements.Length; i++)
        {
            uiElements[i].enabled = false;
        }
    }
}
