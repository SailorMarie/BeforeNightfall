using System;
using UnityEngine;

public class BirdTrigger : MonoBehaviour
{
    private BirdController m_birdController;

    internal void init(BirdController birdController)
    {
        m_birdController = birdController;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            m_birdController.onBirdTrigger?.Invoke();
            Destroy(gameObject);
        }

    }
}
