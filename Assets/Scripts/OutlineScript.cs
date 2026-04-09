using System;
using UnityEngine;

public class OutlineScript : MonoBehaviour
{
    [SerializeField] private Material m_outlineMaterial;
    [SerializeField] private float m_outlineScaleFactor;
    [SerializeField] private Color m_outlineColor;
    private Renderer m_outlineRenderer;

    private void Start()
    {
        m_outlineRenderer = CreateOutline(m_outlineMaterial, m_outlineScaleFactor, m_outlineColor);
        m_outlineRenderer.enabled = true;
    }

    private Renderer CreateOutline(Material outlineMat, float scaleFactor, Color color)
    {
        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        Renderer renderer = outlineObject.GetComponent<Renderer>();

        renderer.material = outlineMat;
        renderer.material.SetColor("_OutlineColor", color);
        renderer.material.SetFloat("_Scale", scaleFactor);
        renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        outlineObject.GetComponent<OutlineScript>().enabled = false;
        outlineObject.GetComponent<Collider>().enabled = false;

        renderer.enabled = false;

        return renderer;
    }
}
