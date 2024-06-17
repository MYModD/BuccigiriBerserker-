using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackingUI : MonoBehaviour
{
    public List<Transform> _enemyTransform = new List<Transform>();
    [SerializeField] private Transform[] _uiTransform;

    private Plane[] planes;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        Debug.Log(string.Join("", planes));

        for (int i = 0; i < _enemyTransform.Count; i++)
        {
            Vector3 enemyScreenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, _enemyTransform[i].position);
            _uiTransform[i].GetComponent<RectTransform>().position = enemyScreenPosition;



            // AABB 軸平行境界ボックス Axis-Aligned Bounding Box   六面体同士で判定を行うものらしいです
            // boundsはcolliderのサイズ、中心データが入ってる コライダーなかったらとれない

            bool inPlanes = GeometryUtility.TestPlanesAABB(planes, _enemyTransform[i].GetComponent<Collider>().bounds);
            
            if (inPlanes)
            {
                _uiTransform[i].GetComponent<Image>().enabled = true;
            }
            else
            {
                _uiTransform[i].GetComponent<Image>().enabled = false;
            }
        }
        
        for(int i = _enemyTransform.Count; i < _uiTransform.Length;i++)//いらないやつはOFFにする
        {
            _uiTransform[i].GetComponent<Image>().enabled = false;
        }
    }
}
