using System;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public enum AudioType
    {
        SFX,
        MUSIC
    }

    public static AudioManager Instance;
    //[SerializeField] private AudioData[] m_sfxAudioData;
    //[SerializeField] private AudioData[] m_musicAudioData;

    [SerializeField] private AudioSource m_musicAudioSource;
    [SerializeField] private AudioSource m_sfxAudioSource;

    //[SerializeField] private AudioControlWindow m_audioControlWindow;
    public float defaultMusicVolume = 1;
    public float defaultSFXVolume = 1;

    //private AudioControlWindow _audioControlWidowInstance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume", defaultMusicVolume));
        SetSFXVolume(PlayerPrefs.GetFloat("SFXVolume", defaultSFXVolume));
        DontDestroyOnLoad(gameObject);
    }
    public void PlayAudio(AudioType audioType, AudioData audioData)
    {
        switch (audioType)
        {
            case AudioType.SFX:
                PlaySFX(audioData);
                break;
            case AudioType.MUSIC:
                PlayMusic(audioData);
                break;
        }
    }

    private void PlayMusic(AudioData audioData)
    {


        if (audioData.IsUnityNull())
        {
            Debug.LogError($"Music not found : {audioData.name}");
        }
        else if (audioData.audioClip._audioName == null)
        {
            Debug.LogError($"Music clip missing : {audioData.audioClip._audioName}");
        }
        else
        {
            m_musicAudioSource.clip = audioData.audioClip._audioClip;
            m_musicAudioSource.Play();
        }
    }

    private void PlaySFX(AudioData audioData)
    {
        

        if (audioData.IsUnityNull())
        {
            Debug.Log($"SFX not found : {audioData.name}");
        }
        else if (audioData.audioClip._audioClip == null)
        {
            Debug.LogError($"SFX clip missing : {audioData.name}");
        }
        else
        {
            m_sfxAudioSource.PlayOneShot(audioData.audioClip._audioClip);
        }
    }

    public void StopAudio(AudioType audioType, AudioData audioData)
    {
        switch (audioType)
        {
            case AudioType.SFX:
                StopSFX();
                break;
            case AudioType.MUSIC:
                StopMusic();
                break;
        }
    }

    private void StopMusic()
    {
        m_musicAudioSource.Stop();
    }

    private void StopSFX()
    {
        m_sfxAudioSource.Stop();
    }

    public void SetVolume(AudioType audioType, float volume)
    {
        switch (audioType)
        {
            case AudioType.SFX:
                SetSFXVolume(volume);
                break;
            case AudioType.MUSIC:
                SetMusicVolume(volume);
                break;
        }
    }

    private void SetMusicVolume(float volume)
    {
        m_musicAudioSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    private void SetSFXVolume(float volume)
    {
        m_sfxAudioSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);


    }

    //public void AudioWindowRequest()
    //{
    //    if (_audioControlWidowInstance != null)
    //    {
    //        UIManager.Instance.CloseWindow(_audioControlWidowInstance);
    //        _audioControlWidowInstance = null;
    //    }
    //    else
    //    {
    //        _audioControlWidowInstance = (AudioControlWindow)UIManager.Instance.OpenWindow(m_audioControlWindow);
    //        _audioControlWidowInstance.Initialize(PlayerPrefs.GetFloat("MusicVolume", defaultMusicVolume), PlayerPrefs.GetFloat("SFXVolume", defaultSFXVolume));
    //    }

    //}
}
