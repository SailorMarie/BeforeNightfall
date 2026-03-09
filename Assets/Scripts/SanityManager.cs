using System;
using UnityEngine;
using UnityEngine.Events;

public class SanityManager : MonoBehaviour
{

    private Action Sanity;
    private float m_sanity = 100;
    private float m_maxSanity = 100;
    private float m_sanityLostRate = 0.25f;

    
    void Update()
    {
        Sanity?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        Sanity += OnLostSanity;
        Sanity -= OnGainSanity;
    }

    private void OnTriggerExit(Collider other)
    {
        Sanity -= OnLostSanity;
        Sanity += OnGainSanity;
    }

    private void OnLostSanity()
    {
        m_sanity -= m_sanityLostRate * Time.deltaTime;
        if(m_sanityLostRate <= 0)
        {
            m_sanity = 0;
            //die
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
