using UnityEngine;

public class Retry_Player : MonoBehaviour
{
    private PlayerLife playerlife;

    public MeshRenderer[] meshRenderer;

    void Start()
    {
        playerlife = GetComponent<PlayerLife>();
    }

    void Update()
    {
        foreach (MeshRenderer renderer in meshRenderer)
                {
            if (playerlife._IsRetry == true)
            {
                renderer.enabled = false;
            }

            if (playerlife._IsRetry == false)
            {
                renderer.enabled = true;
            }
             }





    }


}
