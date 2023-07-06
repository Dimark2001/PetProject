using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ClientMusicPlayer : Singleton<ClientMusicPlayer>
{
    [SerializeField] private AudioClip _clip;

    private AudioSource _audioSource;
    public override void Awake()
    {
        base.Awake();
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        _audioSource.clip = _clip;
        _audioSource.Play();
    }
}
