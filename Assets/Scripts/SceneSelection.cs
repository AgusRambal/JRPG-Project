using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour
{
    public void levelToLoad(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitApp()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
