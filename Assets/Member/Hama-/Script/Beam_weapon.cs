using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_weapon : MonoBehaviour
{
    float _timer = 0.0f;
    float effectDisplayTime = 7f;
    float range = 100.0f;
    float _span = 5f;
    Ray shotRay;
    RaycastHit shotHit;
    ParticleSystem beamParticle;
    LineRenderer lineRenderer;
    [SerializeField] ParticleSystem Beam_long;
    // Use this for initialization
    void Awake()
    {
        beamParticle = GetComponent<ParticleSystem>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetButtonDown("Beam"))
        {
            if (_timer > 2f)
            {
                shot();
            }

        }
        if (_timer >= effectDisplayTime)
        {
            disableEffect();
        }
    }

    IEnumerable shot()
    {
        beamParticle.Stop();
        Beam_long.Play();
        yield return new WaitForSeconds(_span);
        disableEffect();

    }
    //private void shot1()
    //{
    //    _timer = 0f;
    //    beamParticle.Stop();
    //    beamParticle.Play();
    //    lineRenderer.enabled = true;
    //    lineRenderer.SetPosition(0, transform.position);
    //    shotRay.origin = transform.position;
    //    shotRay.direction = transform.forward;

    //    int layerMask = 0;
    //    if (Physics.Raycast(shotRay, out shotHit, range, layerMask))
    //    {
    //        // hit 
    //    }
    //    lineRenderer.SetPosition(1, shotRay.origin + shotRay.direction * range);


    //}

    private void disableEffect()
    {
        beamParticle.Stop();
        Beam_long.Stop();
        lineRenderer.enabled = false;
    }
}

