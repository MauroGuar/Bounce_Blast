using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BKMusicControler : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip bkClip;
    [SerializeField] private VolumenBtn volumenBtn;
    private bool isMuted;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ToggleBkMusic()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.UnPause();
        }
        else
        {
            _audioSource.Pause();
        }
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        _audioSource.mute = isMuted;
        volumenBtn.ToggleSprite();
    }
}
