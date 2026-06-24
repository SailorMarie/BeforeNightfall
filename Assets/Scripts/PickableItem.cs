using System;
using Unity.VisualScripting;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] public Items m_item;
    private Renderer[] m_renderer;

    private void Start()
    {
        m_renderer = GetComponentsInChildren<Renderer>();
    }
    public void Interact()
    {
        PlayerManager.Instance.AddItem(m_item);
        Destroy(gameObject);
    }

    public void UnHighlight()
    {
        foreach(Renderer renderer in m_renderer)
        {
            if (renderer.materials.Length > 1)
            {
                renderer.materials = new Material[] { renderer.materials[0] };
            }

        }
    }

    public void Highlight(Material m_objectHightlightMaterial)
    {
        foreach (Renderer renderer in m_renderer)
        {
            renderer.materials = new Material[] { renderer.materials[0], m_objectHightlightMaterial };
        }
    }
}
