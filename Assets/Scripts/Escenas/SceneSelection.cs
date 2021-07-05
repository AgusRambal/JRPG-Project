using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour
{
    public Animator anim;
    public string sceneName;
    public float transitionTime = 1f;

    public void cambioBTN() //Utilizo el boton para cambiar a la escena eleigiendo su nombre y pongo en 1 el tiempo del juego debido a un bug con la pausa
    {
        StartCoroutine(LoadScene());
        Time.timeScale = 1f;
    }

    IEnumerator LoadScene() //Cambio a la escena elegida y seteo la animacion de transicion
    {
        anim.SetTrigger("Start");
        yield return null;
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
