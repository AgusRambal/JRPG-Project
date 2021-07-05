using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D collider) //Al llegar a la zona, salta el dialogo 2
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            FindObjectOfType<DialogueManager2>().StartDialogue(dialogue);
        }
    }
}
