using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SfxData", menuName = "ScriptableObjects/SfxData", order = 3)]

public class SOs_SfxData : ScriptableObject
{
    public AudioClip[] soundEffects;
    public float sfxVolume = 1f;
    public AudioMixer audioMixer;
}
