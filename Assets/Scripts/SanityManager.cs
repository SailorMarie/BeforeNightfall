using System;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SanityManager : MonoBehaviour
{
    [SerializeField]
    private Volume m_globalVolume;
    [SerializeField]
    private float m_sanityLostRate = 0.25f; // same value as m_fadeSpeed
    [SerializeField]
    private float m_fadeSpeed = 0.25f; // same value as m_sanityLostRate

    private Vignette m_vignette;
    private ChromaticAberration m_chromatic;
    private int m_division = 100;
    private float m_sanity = 100;
    private float m_maxSanity = 100;
    private bool m_firstTimeOnLostSanity = true;
    
    
    
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
    
    private void OnTriggerEnter(Collider other)
    {
        OnLostSanity();
    }

    private void OnLostSanity()
    {
        if(m_firstTimeOnLostSanity)
        {
            //SceneManager.LoadScene(SECOND_SCENE);
            //pop up de ui qui explique sanity
            m_firstTimeOnLostSanity = false;
        }
        m_sanity -= m_sanityLostRate * Time.deltaTime;
        m_vignette.intensity.value += m_fadeSpeed * Time.deltaTime / m_division;
        m_chromatic.intensity.value += m_fadeSpeed * Time.deltaTime / m_division;
       
        if(m_sanityLostRate <= 0)
        {
            //screen tout noire, reload de la scene
            m_sanity = 0;
            
        }
        Debug.Log(m_sanity);
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
