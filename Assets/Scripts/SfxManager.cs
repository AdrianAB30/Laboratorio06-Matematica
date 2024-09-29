using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public SOs_SfxData sfxData;
    public AudioSource sfxSource;

    private void Start()
    {
        SetSfxVolume(sfxData.sfxVolume);
    }
    public void PlaySfx(int index)
    {
        if (index >= 0 && index < sfxData.soundEffects.Length)
        {
            sfxSource.PlayOneShot(sfxData.soundEffects[index]);
        }
    }

    public void SetSfxVolume(float volume)
    {
        sfxData.sfxVolume = volume;
        sfxSource.volume = volume;
        if (sfxData.audioMixer != null)
        {
            sfxData.audioMixer.SetFloat("SfxVolume", Mathf.Log10(volume) * 20);
        }
        else
        {
            Console.WriteLine("No hay AudioMixer asignado");
        }
    }
}

