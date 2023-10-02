using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class HandleSlider : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider VolumeSlider;

    private void Start()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }

    public void SetVolume(float sliderValue)
    {
        Mixer.SetFloat("MusicVolume", (float)Math.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
    
}
