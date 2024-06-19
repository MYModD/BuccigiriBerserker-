using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_weapon : MonoBehaviour
{
    public ParticleSystem startWavePS;
    public ParticleSystem startParticles;
    public ParticleSystem smallMissiles;
    public int smallMissilesCount = 100;

    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            startWavePS.Emit(1);
            startParticles.Emit(smallMissilesCount);
        }

        if (Input.GetMouseButton(0))
        {
            var em = smallMissiles.emission;
            em.enabled = true;
        }
        else
        {
            var em = smallMissiles.emission;
            em.enabled = false;
        }
    }
}

