using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SanityController : MonoBehaviour
{
    [SerializeField]
    private Volume m_globalVolume;
    [SerializeField]
    private float m_sanityLostRate = 0.25f; // same value as m_fadeSpeed
    [SerializeField]
    private float m_fadeSpeed = 0.25f; // same value as m_sanityLostRate
    private float m_firstTimeSanityLostRate = 25f;
    [SerializeField] private List<Shadow> shadows;
    [SerializeField] private Window m_sanitySliderWindow;
    private SanitySliderWindow m_currentSanitySliderWindow;
    [SerializeField] private AudioData m_murmur;

    private Vignette m_vignette;
    private ChromaticAberration m_chromatic;
    private int m_division = 100;
    private float m_sanity = 100;
    private float m_maxSanity = 100;
    private bool m_firstTimeOnLostSanity = false;
    
    public Action OnSanityLostStart;
    public Action OnSanityLostStop;

    private Coroutine m_lostSanityCoroutine = null;

    private const string GAME_SCENE = "Game";
    
    
    void Start()
    {
        if (m_globalVolume.profile.TryGet(out Vignette vignette))
        {
            m_vignette = vignette;
        }
        if (m_globalVolume.profile.TryGet(out ChromaticAberration chrom))
        {
            m_chromatic = chrom;
        }
    }

    public void SetDependencies(GameController gameController)
    {

    }

    public void Init()
    {
        OnSanityLostStart += LostSanityStart;
        OnSanityLostStop += LostSanityStop;
        foreach(Shadow shadow in shadows)
        {
            shadow.Init(this);
        }
        if (m_firstTimeOnLostSanity)
        {
            m_sanityLostRate = 0.25f;
            m_fadeSpeed = m_sanityLostRate;
            m_currentSanitySliderWindow = (SanitySliderWindow)UIManager.Instance.OpenWindow(m_sanitySliderWindow);
        }
        else
        {
            m_sanityLostRate = m_firstTimeSanityLostRate;
            m_fadeSpeed = m_firstTimeSanityLostRate;
        }
    }

    public void LostSanityStart()
    {
        m_lostSanityCoroutine = StartCoroutine(LostSanityCoroutine());
        AudioManager.Instance.PlayAudio(AudioManager.AudioType.SFX, m_murmur);
    }

    private IEnumerator LostSanityCoroutine()
    {   
        while (m_sanity > 0)
        {
            
            m_sanity -= m_sanityLostRate * Time.deltaTime;
            m_vignette.intensity.value += m_fadeSpeed * Time.deltaTime / m_division;
            m_chromatic.intensity.value += m_fadeSpeed * Time.deltaTime / m_division;
            if (m_currentSanitySliderWindow != null)
            {
                m_currentSanitySliderWindow.SetSanity(m_sanity / m_maxSanity);
            }
            Debug.Log(m_sanity);
            yield return null;
        }
        if (m_sanity <= 0)
        {
            //screen tout noire, reload de la scene
            m_sanity = 0;
            m_sanityLostRate = 0.25f;
            m_firstTimeOnLostSanity = true;
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

    private void OnGainSanity()
    {
        m_sanity += m_sanityLostRate * Time.deltaTime;
        if(m_sanity >= m_maxSanity)
        {
            m_sanity = m_maxSanity;
        }
        Debug.Log(m_sanity);
    }
}
