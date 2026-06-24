using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance { private set; get; }
    private Dictionary<string, int> numberOfTimeLevelLoaded = new Dictionary<string, int>();
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
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
}
