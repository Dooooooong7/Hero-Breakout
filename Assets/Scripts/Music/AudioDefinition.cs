using System;
using Unity.VisualScripting;
using UnityEngine;

public class AudioDefinition : MonoBehaviour
{
    public PlayAudioEventSO playAudioEventSO;

    public AudioClip clip;

    public bool playOnEnable;

    public bool playOnStart;

    private void OnEnable()
    {
        if (playOnEnable)
        {
            PlayAudio();
        }
    }

    private void Start()
    {
        if (playOnStart)
        {
            PlayAudio();
        }
    }

    public void PlayAudio()
    {
        // Debug.Log(playAudioEventSO.name);
        playAudioEventSO.RaiseEvent(clip);
    }
}