using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyersAndJasonScenes : MonoBehaviour
{
    public Animator anim;
    public string sceneName;
    public float transitionTime = 1f;

    IEnumerator LoadScene()
    {
        anim.SetTrigger("Start");
        yield return null;
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D collider) //Cuando estoy enfrente de los personajes, cambio a la escena elegida y pongo la transicion
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(LoadScene());
        }
    }
}
