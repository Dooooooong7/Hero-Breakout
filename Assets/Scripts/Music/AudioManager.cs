using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public PlayAudioEventSO BGMEvent;
    public PlayAudioEventSO FXEvent;
    public PlayAudioEventSO EnemyDeadEvent;
    
    public AudioSource BGM;
    public AudioSource FX;
    public AudioSource EnemyAudioSource;

    public void OnEnable()
    {
        FXEvent.onEventRaised += OnFXEvent;
        BGMEvent.onEventRaised += OnBGMEvent;
        EnemyDeadEvent.onEventRaised += OnEnemyAudioEvent;
    }

    public void OnDisable()
    {
        FXEvent.onEventRaised -= OnFXEvent;
        BGMEvent.onEventRaised -= OnBGMEvent;
        EnemyDeadEvent.onEventRaised += OnEnemyAudioEvent;
    }

    private void OnFXEvent(AudioClip clip)
    {
        FX.clip = clip;
        FX.Play();
    }

    private void OnBGMEvent(AudioClip clip)
    {
        BGM.clip = clip;
        BGM.Play();
    }

    private void OnEnemyAudioEvent(AudioClip clip)
    {
        EnemyAudioSource.clip = clip;
        EnemyAudioSource.Play();
    }
}
