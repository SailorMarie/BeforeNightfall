using UnityEngine;

public class Window : MonoBehaviour
{
    [field: SerializeField] public EnumWindows m_layer { get; private set; }

    public virtual void Close()
    {
        UIManager.Instance.CloseWindow(this);
    }


}
