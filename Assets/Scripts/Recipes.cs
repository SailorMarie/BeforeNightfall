using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipes", menuName = "Scriptable Objects/Recipes")]
public class Recipes : ScriptableObject
{
    [field: SerializeField] private List<Items> m_ingredients;
    [field: SerializeField] private GameObject m_result;
    
}
