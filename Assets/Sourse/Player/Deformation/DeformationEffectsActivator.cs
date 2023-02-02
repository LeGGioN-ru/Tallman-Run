using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformationEffectsActivator : MonoBehaviour
{
    [SerializeField] private PlayerDeformation _playerDeformation;
    [SerializeField] private AudioSource _growSound;
    [SerializeField] private AudioSource _downSound;
    [SerializeField] private ParticleSystem _growParticle;
    [SerializeField] private ParticleSystem _downParticle;

    private void OnEnable()
    {
        _playerDeformation.Deformated += OnDeformated;
    }

    private void OnDisable()
    {
        _playerDeformation.Deformated -= OnDeformated;
    }

    private void OnDeformated(int value)
    {
        Execute(value > 0);
    }

    private void Execute(bool isGrow)
    {
        if (isGrow)
        {
            _growParticle.Play();
            _growSound.Play();
        }
        else
        {
            _downParticle.Play();
            _downSound.Play();
        }
    }
}
