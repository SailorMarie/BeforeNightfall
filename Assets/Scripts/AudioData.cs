using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/AudioData")]
public class AudioData : ScriptableObject
{
    [Serializable]
    public struct audioDataHelper
    {
        public string _audioName;
        public AudioClip _audioClip;

    }
    [field: SerializeField] public audioDataHelper audioClip;
}
