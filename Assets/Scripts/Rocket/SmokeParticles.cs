using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeParticles : MonoBehaviour
{
    private ParticleSystem _smokeParticles;

    [SerializeField]
    private Gradient _colorGradient;


    private void Start()
    {
        _smokeParticles = GetComponent<ParticleSystem>();
    }


    
}
