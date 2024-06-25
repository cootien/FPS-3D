using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SoundUIManager : MonoBehaviour
{
    public Slider  MasterSlider, BGSlider, VFXSlider;
    public AudioMixer mainAudioMixer;

    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("Master", MasterSlider.value); 
    }
    public void ChangeBGVolume()
    {
        mainAudioMixer.SetFloat("BG", BGSlider.value);
    }
    public void ChangeVFXVolume()
    {
        mainAudioMixer.SetFloat("VFX", VFXSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
