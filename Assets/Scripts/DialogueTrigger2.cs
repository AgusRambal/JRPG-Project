using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            FindObjectOfType<DialogueManager2>().StartDialogue(dialogue);
        }

    }
}
