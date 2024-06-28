using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gauge_lock : MonoBehaviour
{
    [SerializeField]
    private float gaugeradius = 230f;
    [SerializeField]
    private float gaugeangle = 80f;

    private float undoradius;

    private float undoangle;

    public LockOnManager manager;

    public BusterControl buster;
    // Start is called before the first frame update
    void Start()
    {
        if (buster == null)
        {
            buster = GetComponent<BusterControl>();
        }

        if (manager == null)
        {
            manager = GetComponent<LockOnManager>();
        }



        undoangle = manager._coneAngle;
        undoradius = manager._searchRadius;
    }

    // Update is called once per frame
    void Update()
    {

        if (buster._Beamshot)
        {

            manager._searchRadius = gaugeradius;
            manager._coneAngle = gaugeangle;
        }
        if (!buster._Beamshot)
        {
            manager._searchRadius = undoradius;
            manager._coneAngle = undoangle;
        }
    }
}
