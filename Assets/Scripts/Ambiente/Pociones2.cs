using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pociones2 : MonoBehaviour
{
    public static Pociones2 instance2;
   
    public GameObject fotoObjeto2;
    public int havePowerUp2; //int para saber que agarre y actuar en el player controller y en el player heroe en base a eso
    protected Stats _stats;

    private void Awake() //Singletone creado para acceder desde el player controller y que no haya bugs
    {
        if (Pociones2.instance2 == null)
        {
            Pociones2.instance2 = this;
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
            havePowerUp2 = 2; 
            fotoObjeto2.SetActive(true); //Activo la foto en el inventario
        }
        else
        {
            havePowerUp2 = 0;
        }
    }
}
