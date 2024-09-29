using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioData", menuName = "ScriptableObjects/AudioData", order = 4)]

public class SOs_AudioData : ScriptableObject
{
    public AudioClip[] musicClip;
    public float audioVolume = 1f;
    public AudioMixer audioMixer;
}
