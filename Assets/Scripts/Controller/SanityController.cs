using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SanityController : MonoBehaviour
{
    
    [SerializeField] public float m_sanityLostRate = 0.25f; // same value as m_fadeSpeed
    [SerializeField] private List<Shadow> shadows;
    [SerializeField] private Window m_sanitySliderWindow;
    [SerializeField] private AudioData m_murmur;
    [SerializeField] private SanityData m_firstTimeOnLostSanity;
    private float m_firstTimeSanityLostRate = 25f;
    private SanitySliderWindow m_currentSanitySliderWindow;
    private float m_sanity = 100;
    private float m_maxSanity = 100;
    private CameraEffectController m_cameraEffectController;
    
    public Action OnSanityLostStart;
    public Action OnSanityLostStop;
    public Action vignetteChanged;
    public Action chromChanged;

    private Coroutine m_lostSanityCoroutine = null;

    private const string GAME_SCENE = "Game";
    
    
    void Start()
    {
        
    }

    public void SetDependencies(GameController gameController)
    {
        m_cameraEffectController = gameController.cameraEffectController;
    }

    public void Init()
    {
        OnSanityLostStart += LostSanityStart;
        OnSanityLostStop += LostSanityStop;
        
        foreach(Shadow shadow in shadows)
        {
            shadow.Init(this);
        }
        if (m_firstTimeOnLostSanity.normalSanity)
        {
            m_sanityLostRate = 0.25f;
            m_currentSanitySliderWindow = (SanitySliderWindow)UIManager.Instance.OpenWindow(m_sanitySliderWindow);
        }
        else
        {
            m_sanityLostRate = m_firstTimeSanityLostRate;
        }
    }

    public void LostSanityStart()
    {
        vignetteChanged?.Invoke();
        chromChanged?.Invoke();
        m_lostSanityCoroutine = StartCoroutine(LostSanityCoroutine());
        AudioManager.Instance.PlayAudio(AudioManager.AudioType.SFX, m_murmur);
    }

    private IEnumerator LostSanityCoroutine()
    {   
        while (m_sanity > 0)
        {
            m_sanity -= m_sanityLostRate * Time.deltaTime;

            if (m_currentSanitySliderWindow != null)
            {
                m_currentSanitySliderWindow.SetSanity(m_sanity / m_maxSanity);
            }
            yield return null;
        }
        if (m_sanity <= 0)
        {
            //screen tout noire, reload de la scene
            m_sanity = 0;
            m_sanityLostRate = 0.25f;
            SceneLoaderManager.Instance.LoadScene(GAME_SCENE);

        }
    }

    public void LostSanityStop()
    {
        if (m_lostSanityCoroutine != null)
        {
            StopCoroutine(m_lostSanityCoroutine);
            AudioManager.Instance.StopAudio(AudioManager.AudioType.SFX, m_murmur);
            m_lostSanityCoroutine = null;
        }
    }

    //private void OnGainSanity()
    //{
    //    m_sanity += m_sanityLostRate * Time.deltaTime;
    //    if(m_sanity >= m_maxSanity)
    //    {
    //        m_sanity = m_maxSanity;
    //    }
    //    Debug.Log(m_sanity);
    //}
}
