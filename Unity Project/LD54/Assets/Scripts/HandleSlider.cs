using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class HandleSlider : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider VolumeSlider;
    public String ControllTarget;

    private void Start()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat(ControllTarget, 0.5f);
    }

    public void SetVolume(float sliderValue)
    {
        Mixer.SetFloat(ControllTarget, (float)Math.Log10(sliderValue) * 40);
        PlayerPrefs.SetFloat(ControllTarget, sliderValue);
    }

    
}
