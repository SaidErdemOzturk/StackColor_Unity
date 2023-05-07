using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] List<Scriptable> levels;
    private int levelCount;

    private void Start()
    {
        levelCount = PlayerPrefs.GetInt("Level", 0) % 4;
        Instantiate(levels[levelCount].level);
    }
}
