using UnityEngine;

public class SceneAudioData : MonoBehaviour
{
    [SerializeField] private AudioData m_musicName;
    [SerializeField] private AudioData m_SFXName;

    void Start()
    {
        if(m_musicName != null)
        {
            AudioManager.Instance.PlayAudio(AudioManager.AudioType.MUSIC, m_musicName);
        }
        if(m_SFXName != null)
        {
            AudioManager.Instance.PlayAudio(AudioManager.AudioType.SFX, m_SFXName);
        }
    }

    
}
