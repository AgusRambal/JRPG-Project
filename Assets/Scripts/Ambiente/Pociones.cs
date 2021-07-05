using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pociones : MonoBehaviour
{
    public GameObject fotoObjeto1;
    public int havePowerUp;
    protected Stats _stats;
    public bool battle = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider) //Si compro esto, cambia stats
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            havePowerUp = 1;
            fotoObjeto1.SetActive(true);
            battle = false;
        }
        else
        {
            havePowerUp = 0;
        }
    }
}