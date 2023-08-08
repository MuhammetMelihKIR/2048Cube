using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager instance;

    [Header("Sounds")]
    [SerializeField] AudioSource _musicAudioSource;
    public AudioSource _touchAudioSource;
    [SerializeField] AudioSource _frictionAudioSource;
    

    private void Awake()
    {
        instance = this;
        
    }
    public void FrictionPlay()
    {
        _frictionAudioSource.Play();
    }
    public void CubesTouchPlay()
    {
        _touchAudioSource.Play();
        _touchAudioSource.pitch += 0.1f;
        if (_touchAudioSource.pitch >= 2)
        {
            _touchAudioSource.pitch =1;
        }
    }

    public void SoundOff()
    {
        _touchAudioSource.volume= 0;
        _frictionAudioSource.volume = 0;
    }

    public void SoundOn()
    {
        _touchAudioSource.volume = 1;
        _frictionAudioSource.volume = 1;
    }

    public void MusicOff()
    {
        _musicAudioSource.volume= 0;
    }
    public void MusicOn()
    {
        _musicAudioSource.volume= 1;
    }
}
