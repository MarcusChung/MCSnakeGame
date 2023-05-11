using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PlayerProfileSO : ScriptableObject
{
    [SerializeField] private int _NumOfDeaths;
    [SerializeField] private bool[] _LevelsComplete;
    [SerializeField] private string _HighScore;
    [SerializeField] private Level _currentLevel;
    [SerializeField] private int _currentProfile;
    [SerializeField] private int _fruitAte;
    [SerializeField] private string[] _unlockedAchievements = new string[MAX_ACHIEVEMENTS];
    private const int MAX_ACHIEVEMENTS = 100;

    public string[] UnlockedAchievements
    {
        get { return _unlockedAchievements; }
        set { _unlockedAchievements = value; }
    }
    public int NumOfDeaths
    {
        get { return _NumOfDeaths; }
        set { _NumOfDeaths = value; }
    }

    public bool[] LevelsComplete
    {
        get { return _LevelsComplete; }
        set { _LevelsComplete = value; }
    }

    public string HighScore
    {
        get { return _HighScore; }
        set { _HighScore = value; }
    }

    public int CurrentProfile {
        get { return _currentProfile; }
        set { _currentProfile = value; }
    }

    public int FruitAte
    {
        get { return _fruitAte; }
        set { _fruitAte = value; }
    }

    public enum Level
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

    public Level CurrentLevel
    {
        get { return _currentLevel; }
        set { _currentLevel = value; }
    }

    private void Awake()
    {
        _LevelsComplete = new bool[Enum.GetNames(typeof(Level)).Length];
        _currentProfile = 0;
        _NumOfDeaths = 0;
        _HighScore = "0";
        _fruitAte = 0;
        _unlockedAchievements = new string[MAX_ACHIEVEMENTS];
    }
}
