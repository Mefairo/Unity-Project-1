using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private ShootSystem _shootSystem;

    private void OnEnable()
    {
        _shootSystem.DoShot += PlaySoundShot;
    }

    private void OnDisable()
    {
        _shootSystem.DoShot -= PlaySoundShot;
    }

    private void PlaySoundShot()
    {
        _shotSound.Play();
    }
}
