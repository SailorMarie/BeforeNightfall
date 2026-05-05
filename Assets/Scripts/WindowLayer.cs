using UnityEngine;

public class WindowLayer : MonoBehaviour
{
    public EnumWindows.WindowLayers m_layer { get; private set; }

    public void SetLayer(EnumWindows.WindowLayers layer)
    {
        m_layer = layer;
    }
}
