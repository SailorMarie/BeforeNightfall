using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Dictionary< EnumWindows.WindowLayers, Window> m_windowToLayer = new();
    private Dictionary<EnumWindows.WindowLayers, Transform> m_transformToLayer = new();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        InstantiateLayer();
    }

    private void InstantiateLayer()
    {
        System.Collections.IList list = System.Enum.GetValues(typeof(EnumWindows.WindowLayers));
        for (int i = 0; i < list.Count; i++)
        {
            EnumWindows.WindowLayers layer = (EnumWindows.WindowLayers)list[i];
            GameObject gameObject = new GameObject(layer.ToString());
            WindowLayer windowLayer = gameObject.AddComponent<WindowLayer>();
            gameObject.transform.parent = transform;
            windowLayer.SetLayer(layer);
            m_transformToLayer.Add(layer, gameObject.transform);

        }
    }

    public Window OpenWindow(Window window)
    {
        EnumWindows.WindowLayers windowType = window.m_layer.Layer;
        if (m_windowToLayer.ContainsKey(windowType))
        {

            CloseWindow(m_windowToLayer[windowType]);
        }
        if (m_transformToLayer.TryGetValue(windowType, out Transform layerTransform))
        {
            Window newWindow = Instantiate(window, layerTransform);
            m_windowToLayer.TryAdd(windowType, newWindow);
            return newWindow;
        }

        return null;
    }

    public void CloseWindow(Window window)
    {
        EnumWindows.WindowLayers windowType = window.m_layer.Layer;
        if (m_windowToLayer.ContainsKey(windowType) && m_windowToLayer[windowType] == window)
        {
            m_windowToLayer.Remove(windowType);
            Destroy(window.gameObject);
        }
        else
        {
            Debug.LogWarning($"Attempted to close a window of type {windowType} that is not currently open.");
        }
    }




}
