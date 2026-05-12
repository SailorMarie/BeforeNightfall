using System;
using UnityEngine;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public enum AudioType
    {
        SFX,
        Music
    }

    public static AudioManager Instance;
    [SerializeField] private AudioData m_sfxAudioData;
    [SerializeField] private AudioData m_musicAudioData;

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
    public void PlayAudio(AudioType audioType, string audioName)
    {
        switch (audioType)
        {
            case AudioType.SFX:
                PlaySFX(audioName);
                break;
            case AudioType.Music:
                PlayMusic(audioName);
                break;
        }
    }

    private void PlayMusic(string audioName)
    {
        AudioData.audioDataHelper audioDataHelper = Array.Find(m_musicAudioData.audioClips, x => x._audioName == audioName);

        if (audioDataHelper.IsUnityNull())
        {
            Debug.LogError($"Music not found : {audioName}");
        }
        else if (audioDataHelper._audioClip == null)
        {
            Debug.LogError($"Music clip missing : {audioName}");
        }
        else
        {
            m_musicAudioSource.clip = audioDataHelper._audioClip;
            m_musicAudioSource.Play();
        }
    }

    private void PlaySFX(string audioName)
    {
        AudioData.audioDataHelper audioDataHelper = Array.Find(m_sfxAudioData.audioClips, x => x._audioName == audioName);

        if (audioDataHelper.IsUnityNull())
        {
            Debug.Log($"SFX not found : {audioName}");
        }
        else if (audioDataHelper._audioClip == null)
        {
            Debug.LogError($"SFX clip missing : {audioName}");
        }
        else
        {
            m_sfxAudioSource.PlayOneShot(audioDataHelper._audioClip);
        }
    }

    public void SetVolume(AudioType audioType, float volume)
    {
        switch (audioType)
        {
            case AudioType.SFX:
                SetSFXVolume(volume);
                break;
            case AudioType.Music:
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
