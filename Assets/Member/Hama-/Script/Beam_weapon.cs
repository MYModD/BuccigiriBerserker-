using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_weapon : MonoBehaviour
{
    private float _timer;
    private ParticleSystem longparticleSystem;
    private bool isParticlesActive = false;
    private float particleDuration = 5f; 
    private CapsuleCollider beamCol;
    void Start()
    {
        beamCol = GetComponent<CapsuleCollider>();
        longparticleSystem = GetComponent<ParticleSystem>();
        longparticleSystem.Stop(); 
        _timer = 0f;

    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 2f)
        {
            
            if (Input.GetKeyDown(KeyCode.Space) && !isParticlesActive)
            {
                isParticlesActive = true;
                longparticleSystem.Play();
                beamCol.enabled = true;
                
                Invoke("StopParticles", particleDuration);
            }
        }

    }

    void StopParticles()
    {//nullでない
        if (longparticleSystem != null)
        {
            beamCol.enabled = false;
            longparticleSystem.Stop();
            isParticlesActive = false;
            _timer = 0f;
        }

    }
}



