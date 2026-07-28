using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance { private set; get; }
    private Dictionary<string, int> numberOfTimeLevelLoaded = new Dictionary<string, int>();
    private List<string> m_pickedUpItem = new List<string>();
    private int m_cabinState = -1;

    public Action OnGameEnd;
    public int M_cabinState => m_cabinState;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddLevel(string levelName)
    {
        if (numberOfTimeLevelLoaded.ContainsKey(levelName))
        {
            numberOfTimeLevelLoaded[levelName]++;
        }
        else
        {
            numberOfTimeLevelLoaded.Add(levelName, 1);
       
        }
    }

    public bool IsFirstTimeLevelLoaded(string levelName)
    {
        if (numberOfTimeLevelLoaded.ContainsKey(levelName))
        {
            return numberOfTimeLevelLoaded[levelName] == 1;
        }
        else
        {
            return true;
        }
    }

    public void AddPickedUpItem(string itemGUID)
    {
        m_pickedUpItem.Add(itemGUID);
    }

    public List<string> GetPickedUpItem()
    {
        return m_pickedUpItem;
    }

    public void IncreaseCabinState()
    {
        m_cabinState++;
    }

    public void Reset()
    {
        numberOfTimeLevelLoaded.Clear();
        m_pickedUpItem.Clear();
        m_cabinState = -1;
        OnGameEnd?.Invoke();
    }
}
