using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D collider) //Al llegar a la zona salta el dialogo
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}