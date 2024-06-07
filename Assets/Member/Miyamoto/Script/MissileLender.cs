using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissileLender : MonoBehaviour
{
    LineRenderer lineRenderer;
    public float invokeTime;
  
    List<Vector3> linePos = new List<Vector3>();
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        

        InvokeRepeating(nameof(LineRenderDebug), invokeTime,invokeTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LineRenderDebug()
    {

        linePos.Add(transform.position);

        lineRenderer.positionCount = linePos.Count;

        lineRenderer.SetPositions(linePos.ToArray());
    }
}
