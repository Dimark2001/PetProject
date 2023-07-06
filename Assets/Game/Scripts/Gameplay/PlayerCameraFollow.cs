using Cinemachine;
using UnityEngine;

public class PlayerCameraFollow : Singleton<PlayerCameraFollow>
{
    [SerializeField] private float amplitudeGain = 0.5f;
    [SerializeField] private float frequencyGain = 0.5f;

    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void FollowPlayer(Transform rootTransform)
    {
        if (cinemachineVirtualCamera == null) return;

        cinemachineVirtualCamera.Follow = rootTransform;

        var perlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = amplitudeGain;
        perlin.m_FrequencyGain = frequencyGain;
    }
}