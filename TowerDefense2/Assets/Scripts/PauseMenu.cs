using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool _gamePaused = false;

    public GameObject pauseMenuUI;

    public bool GamePaused
    {
        get => _gamePaused; 
        set
        {
            if (_gamePaused == value)
                return;

            _gamePaused = value;
            pauseMenuUI.SetActive(value);
            Time.timeScale = Convert.ToInt32(!value);
        }
    }




    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            GamePaused = !GamePaused;
        }

    }
}
