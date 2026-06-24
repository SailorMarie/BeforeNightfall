using System;
using Unity.VisualScripting;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] public Items m_item;
    private Renderer m_renderer;

    private void Start()
    {
        m_renderer = GetComponent<Renderer>();
    }
    public void Interact()
    {
        PlayerManager.Instance.AddItem(m_item);
        Destroy(gameObject);
    }

    public void UnHighlight()
    {
        if (m_renderer.materials.Length > 1)
        {
            m_renderer.materials = new Material[] { m_renderer.materials[0] };
        }
    }

    public void Highlight(Material m_objectHightlightMaterial)
    {
        m_renderer.materials = new Material[] { m_renderer.materials[0], m_objectHightlightMaterial };
    }
}
