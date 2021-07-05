using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerShopScene : MonoBehaviour
{
    public Animator anim;
    public string sceneName;
    public float transitionTime = 1f;
    private void OnTriggerEnter2D(Collider2D collider) //Cuando entro al shop, cambio a la escena elegida y pongo la transicion
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            anim.SetTrigger("Start");
            SceneManager.LoadScene(sceneName);
        }
    }
}
