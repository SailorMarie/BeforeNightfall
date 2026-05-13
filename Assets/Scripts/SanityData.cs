using UnityEngine;

[CreateAssetMenu(fileName = "SanityData", menuName = "Scriptable Objects/SanityData")]
public class SanityData : ScriptableObject
{
    [field: SerializeField] public bool normalSanity { get; set; }

}
