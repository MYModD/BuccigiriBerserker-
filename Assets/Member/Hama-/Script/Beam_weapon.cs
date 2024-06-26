using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_weapon : MonoBehaviour
{
    private float _timer;
    private ParticleSystem longparticleSystem;
    public bool _isParticlesActive = false;
    private float beam_distance = 95f;
    private Collider beamCol;

    void Start()
    {
        beamCol = GetComponent<BoxCollider>();
        longparticleSystem = GetComponent<ParticleSystem>();
        longparticleSystem.Stop();
        _timer = 0f;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 5f)
        {
            if (Input.GetButtonDown("Beam") && !_isParticlesActive)
            {
                _isParticlesActive = true;

                longparticleSystem.Play();

                RaycastHit hit;
                Physics.BoxCast(transform.position, (Vector3.one * 0.5f), new Vector3(0, 0, 7), out hit, Quaternion.identity, 1);

                Gizmos.DrawRay(transform.position, transform.forward * hit.distance);

                beamCol.enabled = true;

                StartCoroutine(StopParticlesAfterDelay(beam_distance));
            }
        }
    }

    IEnumerator StopParticlesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (longparticleSystem != null)
        {
            beamCol.enabled = false;
            longparticleSystem.Stop();
            _isParticlesActive = false;
            _timer = 0f;
        }
    }
}



