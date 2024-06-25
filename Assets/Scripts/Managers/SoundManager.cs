using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class SoundManager : Singleton<SoundManager>
{
    //public GameObject[] BGSounds, VFXSounds;
    //public AudioSource BGSource, VFXSource; 

    //public void PlayBG(string name)
    //{
    //    GameObject bgSound = System.Array.Find(BGSounds, x => x.name == name);
    //    if (bgSound == null)
    //    {
    //        Debug.Log("Sound Not Found");
    //    }
    //    else
    //    {
    //        BGSource.clip = bgSound.GetComponent<AudioSource>().clip;
    //        BGSource.Play();
    //    }
    //}
    //public void PlayVFX(string name)
    //{
    //    GameObject vfxSound = System.Array.Find(VFXSounds, x => x.name == name);
    //    if (vfxSound == null)
    //    {
    //        Debug.Log("Sound Not Found");
    //    }
    //    else
    //    {
    //        VFXSource.clip = vfxSound.GetComponent<AudioSource>().clip;
    //        VFXSource.PlayDelayed(vfxSound.GetComponent<AudioSource>());
    //    }
    //}
    //private void Start()
    //{
    //    PlayBG("HorrorBackground");
    //}
}
