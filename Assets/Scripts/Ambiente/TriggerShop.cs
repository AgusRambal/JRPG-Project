using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShop : MonoBehaviour
{
    public GameObject house;
    static AudioSource audioSrc;
    public AudioClip doorSound, doorClose;

    private void Awake()
    {
        house.SetActive(false);
        audioSrc = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            house.SetActive(true);
            audioSrc.PlayOneShot(doorSound);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            house.SetActive(false);
            audioSrc.PlayOneShot(doorClose);
        }
    }
}
