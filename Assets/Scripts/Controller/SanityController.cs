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
    [SerializeField] private List<Shadow> shadows;


    private Vignette m_vignette;
    private ChromaticAberration m_chromatic;
    private int m_division = 100;
    private float m_sanity = 100;
    private float m_maxSanity = 100;
    private bool m_firstTimeOnLostSanity = true;
    
    public Action OnSanityLostStart;
    public Action OnSanityLostStop;

    private Coroutine m_lostSanityCoroutine = null;
    
    
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
    }

    public void LostSanityStart()
    {
        m_lostSanityCoroutine = StartCoroutine(LostSanityCoroutine());
    }

    private IEnumerator LostSanityCoroutine()
    {   
        while (m_sanity > 0)
        {
            m_sanity -= m_sanityLostRate * Time.deltaTime;
            m_vignette.intensity.value += m_fadeSpeed * Time.deltaTime / m_division;
            m_chromatic.intensity.value += m_fadeSpeed * Time.deltaTime / m_division;
            Debug.Log(m_sanity);
            yield return null;
        }
        if (m_sanityLostRate <= 0)
        {
            //screen tout noire, reload de la scene
            m_sanity = 0;

        }
    }

    public void LostSanityStop()
    {
        if (m_lostSanityCoroutine != null)
        {
            StopCoroutine(m_lostSanityCoroutine);
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
