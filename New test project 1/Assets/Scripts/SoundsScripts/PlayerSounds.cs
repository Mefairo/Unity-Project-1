using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private PlayerShoot _playerShoot;

    private void OnEnable()
    {
        _playerShoot.DoShot += PlaySoundShot;
    }

    private void OnDisable()
    {
        _playerShoot.DoShot -= PlaySoundShot;
    }

    private void PlaySoundShot()
    {
        Debug.Log("sound");
        _shotSound.Play();
    }
}
