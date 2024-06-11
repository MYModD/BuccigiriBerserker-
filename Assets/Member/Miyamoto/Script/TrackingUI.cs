using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrackingUI : MonoBehaviour
{
    RectTransform rectTransform ;
    [SerializeField] private Transform[] _enemyTransfrom;

    [SerializeField] private Transform[] _uiTransform; 

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _enemyTransfrom.Length; i++)
        {
            _uiTransform[i].GetComponent<RectTransform>().position = RectTransformUtility.WorldToScreenPoint(Camera.main, _enemyTransfrom[i].transform.position);
        }
    }
}
