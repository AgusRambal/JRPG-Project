using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour
{
    public Animator anim;
    public string sceneName;
    public float transitionTime = 1f;

    public void cambioBTN()
    {
        StartCoroutine(LoadScene());
        Time.timeScale = 1f;
    }

    IEnumerator LoadScene()
    {
        anim.SetTrigger("Start");
        yield return null;
        SceneManager.LoadScene(sceneName);
    }

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
