using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    public string sceneName;
    public Animator anim;
    public float transitionTime = 1f;

    private void OnTriggerEnter2D(Collider2D collider) //Al entrar en el dialogo, espero 10 segundos y cambio a la escena final
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene() //Cambio a la escena elegida y seteo la animacion de transicion
    {
        yield return new WaitForSeconds(10f);
        anim.SetTrigger("Start");
        SceneManager.LoadScene(sceneName);
    }

}
