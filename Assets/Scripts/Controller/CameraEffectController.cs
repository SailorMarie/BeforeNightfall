using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraEffectController : MonoBehaviour
{
    [SerializeField] private Volume m_globalVolume;
    [SerializeField] public float m_fadeSpeed = 0.25f; // same value as m_sanityLostRate
    private Vignette m_vignette;
    private ChromaticAberration m_chromatic;
    private int m_division = 100;
    private SanityController m_sanityController;

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
        m_sanityController = gameController.sanityController;
    }

    public void Init()
    {
        m_sanityController.vignetteChanged += DoEffect;
        m_sanityController.chromChanged += DoEffect;
        
        
        m_fadeSpeed = m_sanityController.m_sanityLostRate;
            

    }

    public void OnDestroy()
    {
        m_sanityController.vignetteChanged -= DoEffect;
        m_sanityController.chromChanged -= DoEffect;
    }

    private void DoEffect()
    {
        m_vignette.intensity.value += m_fadeSpeed * Time.deltaTime / m_division;
        m_chromatic.intensity.value += m_fadeSpeed * Time.deltaTime / m_division;
    }

    private void StopEffect()
    {
        

    }

}