using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private Coroutine m_CameraEffectCoroutine;
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
        m_sanityController.OnSanityLostStart += DoEffect;
        m_sanityController.OnSanityLostStop += StopEffect;



        m_fadeSpeed = m_sanityController.m_sanityLostRate;
            

    }

    public void OnDestroy()
    {
        m_sanityController.OnSanityLostStart -= DoEffect;
        m_sanityController.OnSanityLostStop -= StopEffect;
    }

    private void DoEffect()
    {
      m_CameraEffectCoroutine = StartCoroutine(DoEffectCoroutine());
    }
    private IEnumerator DoEffectCoroutine()
    {
        while(true)
        {
            yield return null;
            m_vignette.intensity.value += m_fadeSpeed * Time.deltaTime / m_division;
            m_chromatic.intensity.value += m_fadeSpeed * Time.deltaTime / m_division;
            
        }
    }
    private void StopEffect()
    {
        if(m_CameraEffectCoroutine != null)
        {
            StopCoroutine(m_CameraEffectCoroutine);
        }

    }

}