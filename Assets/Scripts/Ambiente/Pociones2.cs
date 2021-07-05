using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pociones2 : MonoBehaviour
{
    public GameObject fotoObjeto2;
    public int havePowerUp2;
    protected Stats _stats;
    public bool battle2 = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider) //Si compro esto, cambia stats
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            havePowerUp2 = 2;
            fotoObjeto2.SetActive(true);
            battle2 = false;
        }
        else
        {
            havePowerUp2 = 0;
        }
    }
}
