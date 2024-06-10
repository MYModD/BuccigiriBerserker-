using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLock : MonoBehaviour
{
    public bool locksw = false;
    private void OnBecameVisible()
    {
        //‰æ–Ê‚É‰f‚Á‚Ä‚¢‚½‚ç“®‚­
        this.GetComponent<Renderer>().material.color = Color.red;
        locksw = true;
    }

    private void OnBecameInvisible()
    {
        //‰æ–Ê‰f‚Á‚Ä‚¢‚È‚¢‚Æ‚«“®‚­
        this.GetComponent<Renderer>().material.color = Color.blue;
        locksw = false;
    }

    private void Update()
    {
        Debug.Log(locksw);
    }
}
