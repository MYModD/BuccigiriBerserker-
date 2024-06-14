using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class TrackingUI : MonoBehaviour
{
    public List<Transform> _enemyTransform = new List<Transform>();
    [SerializeField] private Transform[] _uiTransform;

    private Plane[] planes;

    public LockOnManager lockOnManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        //Debug.Log(string.Join("", planes));




        for (int i = 0; i < lockOnManager.targetsInCamera.Count; i++)
        {
            Vector3 enemyScreenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, lockOnManager.targetsInCamera[i].position);
            _uiTransform[i].GetComponent<RectTransform>().position = enemyScreenPosition;



            // AABB 軸平行境界ボックス Axis-Aligned Bounding Box   六面体同士で判定を行うものらしいです
            // boundsはcolliderのサイズ、中心データが入ってる コライダーなかったらとれない

            
        }
        
        //for(int i = _enemyTransform.Count; i < _uiTransform.Length;i++)//いらないやつはOFFにする
        //{
        //    _uiTransform[i].GetComponent<Image>().enabled = false;
        //}
    }
}
