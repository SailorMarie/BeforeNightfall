using System;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private AudioClip m_flyAwayClip;
    [SerializeField] private float m_birdSpeed = 10f;
    private BirdController m_birdController;
    private float m_flyUp;
    private float m_flyRange;

    private float m_elapsedTime = 0f;
    private float m_flyDuration = 5f;

    public void init(BirdController birdController)
    {
        m_birdController = birdController;
        m_birdController.onBirdTrigger += OnBirdTrigger;
        
    }

    private void OnBirdTrigger()
    {
        m_animator.SetBool("flying", true);
        AudioSource.PlayClipAtPoint(m_flyAwayClip, transform.position);

        m_flyUp = UnityEngine.Random.Range(-23f, -7f);
        m_flyRange = UnityEngine.Random.Range(12f, 167f);
        transform.Rotate(m_flyUp, m_flyRange, 0);
        
        StartCoroutine(Flying());
        
    }

    private IEnumerator Flying()
    {
        while(m_elapsedTime < m_flyDuration)
        {
            transform.Translate(Vector3.forward * m_birdSpeed * Time.deltaTime);
            m_elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
        m_elapsedTime = 0f;
    }
    
}
