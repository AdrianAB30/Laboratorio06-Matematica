using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cameraShake;
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeMagnitude;
    private CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        noise = cameraShake.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = 0f;
    }
    public void ShakeCamera()
    {
        StartShake();
    }
    public void StartShake()
    {
        noise.m_AmplitudeGain = shakeMagnitude;
        Invoke("StopShake", shakeDuration);
    }
    private void StopShake()
    {
        noise.m_AmplitudeGain = 0f;
    }
}
