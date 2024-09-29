using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public SOs_AudioData audioData;
    public AudioSource musicSource;

    private void Start()
    {
        CurrentScene();
        SetMasterVolume(audioData.audioVolume);
    }
    private void CurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Game")
        {
            PlayAudio(1);
        }
        else if (currentScene == "Menu")
        {
            PlayAudio(0);
        }
    }
    public void PlayAudio(int index)
    {
        if(index >= 0 && index < audioData.musicClip.Length)
        {
            musicSource.PlayOneShot(audioData.musicClip[index]);
        }
    }
    public void StopAudio()
    {
        musicSource.Stop();
    }
    public void SetMasterVolume(float volume)
    {
        audioData.audioVolume = volume; 
        if (audioData.audioMixer != null)
        {
            audioData.audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20); 
        }
        else
        {
            Debug.LogWarning("No hay AudioMixer asignado");
        }
    }
    public void SetMusicVolume(float volume)
    {
        audioData.audioVolume = volume;
        musicSource.volume = volume;
        if (audioData.audioMixer != null)
        {
            audioData.audioMixer.SetFloat("SfxVolume", Mathf.Log10(volume) * 20);
        }
        else
        {
            Console.WriteLine("No hay AudioMixer asignado");
        }
    }
}
