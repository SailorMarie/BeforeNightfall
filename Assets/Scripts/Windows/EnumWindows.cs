using UnityEngine;

[CreateAssetMenu(fileName = "EnumWindows", menuName = "Scriptable Objects/EnumWindows")]
public class EnumWindows : ScriptableObject
{
    public enum WindowLayers
    {
        Hud,
        Inventory,
        PauseMenu,
    }

    [field: SerializeField] public WindowLayers Layer;
}
