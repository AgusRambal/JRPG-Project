using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pociones : MonoBehaviour
{
    public static Pociones instance;

    public GameObject fotoObjeto1;
    public int havePowerUp; //int para saber que agarre y actuar en el player controller y en el player heroe en base a eso
    protected Stats _stats;

    private void Awake() //Singletone creado para acceder desde el player controller y que no haya bugs
    {
        if (Pociones.instance == null)
        {
            Pociones.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) //Si compro esto, cambia stats
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            havePowerUp = 1;
            fotoObjeto1.SetActive(true); //Activo la foto en el inventario
        }
        else
        {
            havePowerUp = 0;
        }
    }
}
