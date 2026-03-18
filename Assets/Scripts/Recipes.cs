using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipes", menuName = "Scriptable Objects/Recipes")]
public class Recipes : ScriptableObject
{
    [field: SerializeField] public List<Items> m_ingredients;
    [field: SerializeField] public Items m_result;
    
}
