using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTroughScenes : MonoBehaviour
{
    AudioSource audioSource;
    public static AudioTroughScenes instance;
    private void Awake()
    {
        if (AudioTroughScenes.instance == null)
        {
            AudioTroughScenes.instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Pause()
    {
        instance.audioSource.Pause();
    }
    public static void UnPause()
    {
        instance.audioSource.UnPause();
    }
}
