using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JasonAppears : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject jason;

    private void OnTriggerEnter2D(Collider2D collider) //Hago aparecer salir a Jason del campo de maiz al entrar en su campo de vision
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            jason.transform.position = teleportTarget.transform.position;
        }
    }
}
