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
    private LensDistortion m_lensDistortion;
    private int m_division = 100;
    private SanityController m_sanityController;

    public Action OnTeleportEffect;

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
        if (m_globalVolume.profile.TryGet(out LensDistortion lens))
        {
            m_lensDistortion = lens;
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
        OnTeleportEffect += Anomalies;


        m_fadeSpeed = m_sanityController.m_sanityLostRate;
            

    }

    public void OnDestroy()
    {
        m_sanityController.OnSanityLostStart -= DoEffect;
        m_sanityController.OnSanityLostStop -= StopEffect;
    }
    private void Anomalies()
    {
        StartCoroutine(AnomaliesCoroutine());
    }

    private IEnumerator AnomaliesCoroutine()
    {   
        float chromStartValue = m_chromatic.intensity.value;
        m_chromatic.intensity.value = 1;
        m_lensDistortion.intensity.value = 0.91f;
        yield return new WaitForSeconds(0.4f);
        m_chromatic.intensity.value = chromStartValue;
        m_lensDistortion.intensity.value = 0;
        
        
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