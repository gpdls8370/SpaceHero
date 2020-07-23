using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagement : MonoBehaviour
{
    public Slider masterVolume;
    private float vol = 1.0f;

    void Start()
    {
        masterVolume.value = vol;
    }

    void Update()
    {
        SoundSlider(); 
    }

    public void SoundSlider()
    {
        vol = masterVolume.value;
        AudioListener.volume = vol;
    }
}
