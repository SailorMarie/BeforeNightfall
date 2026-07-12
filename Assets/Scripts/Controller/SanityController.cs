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

    private float m_maxSanity = 100;
    private CameraEffectController m_cameraEffectController;
    
    public Action OnSanityLostStart;
    public Action OnSanityLostStop;
  
    

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
            m_currentSanitySliderWindow.SetSanity(PlayerManager.Instance.GetSanaity() / m_maxSanity);
        }
        else
        {
            m_sanityLostRate = m_firstTimeSanityLostRate;
        }
    }

    public void LostSanityStart()
    {
        
        m_lostSanityCoroutine = StartCoroutine(LostSanityCoroutine());
        AudioManager.Instance.PlayAudio(AudioManager.AudioType.SFX, m_murmur);
    }

    private IEnumerator LostSanityCoroutine()
    {   
        while (PlayerManager.Instance.GetSanaity() > 0)
        {
            PlayerManager.Instance.RemoveSanity(m_sanityLostRate * Time.deltaTime);

            if (m_currentSanitySliderWindow != null)
            {
                Debug.Log(PlayerManager.Instance.GetSanaity());
                m_currentSanitySliderWindow.SetSanity(PlayerManager.Instance.GetSanaity() / m_maxSanity);
            }
            yield return null;
        }
        if (PlayerManager.Instance.GetSanaity() <= 0)
        {
            //screen tout noire, reload de la scene
            PlayerManager.Instance.SetSanity(0);
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
