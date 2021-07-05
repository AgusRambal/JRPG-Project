using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    private void Awake() //Al arrancar la escena saco la pausa
    {
        Resume();
    }

    void Update() //Si aprieto escape pongo pausa y si vuelvo a apretar la saco
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume() //Pongo el tiempo en 1 y saco la pausa
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause() //Pongo el tiempo en 0 y pongo la pausa (Este es el problema que solucione en el SceneSelection)
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
