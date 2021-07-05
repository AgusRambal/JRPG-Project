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
    private void OnTriggerEnter2D(Collider2D collider) //Si entro en la zona del Shop, abro las puertas y pongo un sonido
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            house.SetActive(true);
            audioSrc.PlayOneShot(doorSound);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //Si salgo de la zona del shop cierro las puertas y pongo otro sonido
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            house.SetActive(false);
            audioSrc.PlayOneShot(doorClose);
        }
    }
}
