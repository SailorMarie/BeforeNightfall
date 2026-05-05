using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Dictionary<Window, EnumWindows.WindowLayers> m_windowToLayer = new();
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
        //foreach (KeyValuePair<Window, EnumWindows.WindowLayers> m_window in m_windowToLayer)
        //{
        //    if (m_window.Value == window.m_layer.Layer)
        //    {
        //        CloseWindow(m_window.Key);
        //    }
        //}
        List<EnumWindows.WindowLayers> layers = m_windowToLayer.Values.ToList();
        List<Window> windows = m_windowToLayer.Keys.ToList();

        for (int i = m_windowToLayer.Count - 1; i >= 0; i--)
        {
            if (layers[i] == window.m_layer.Layer)
            {
                CloseWindow(windows[i]);
            }
        }

        if (m_transformToLayer.TryGetValue(window.m_layer.Layer, out Transform transform))
        {
            Window instanciatedWindow = Instantiate(window, transform);
            m_windowToLayer.TryAdd(instanciatedWindow, window.m_layer.Layer);
        }

        return window;
    }

    public void CloseWindow(Window window)
    {
        if (m_windowToLayer.Remove(window))
        {
            Destroy(window.gameObject);
        }
    }




}
