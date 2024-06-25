using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SoundUIManager : MonoBehaviour
{
    public Slider  Master, BG, VFX;
    public AudioMixer mainAudioMixer;

    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("MasterSound", Master.value);
    }
    public void ChangeBGVolume()
    {
        mainAudioMixer.SetFloat("BGMusic", BG.value);
    }
    public void ChangeVFXVolume()
    {
        mainAudioMixer.SetFloat("VFXMusic", VFX.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
