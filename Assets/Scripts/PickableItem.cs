using System;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class PickableItem : MonoBehaviour
{
#if UNITY_EDITOR
    [ContextMenu("CreateGUID")]
    public void CreateGUID()
    {
        m_guid = GUID.Generate().ToString();
    }
#endif
    [SerializeField] public Items m_item;
    private Renderer[] m_renderer;
    [SerializeField] public string m_guid;


    private void Start()
    {
        
        m_renderer = GetComponentsInChildren<Renderer>();
    }
    public virtual void Interact()
    {
        PlayerManager.Instance.AddItem(m_item);
        LevelManager.Instance.AddPickedUpItem(m_guid);
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
