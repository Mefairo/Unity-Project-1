using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    [SerializeField] private PauseManager _pauseMenu;

    public void RestartGame()
    {
        Time.timeScale = 0f;
        _pauseMenu.gameObject.SetActive(true);
    }
}
