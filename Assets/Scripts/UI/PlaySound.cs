using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource sound;
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }

    public void PlayAudioSource(AudioClip clip)
    {
        sound.PlayOneShot(clip);
    }
}
