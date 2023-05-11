using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PlayerProfileSO : ScriptableObject
{
    [SerializeField] private int _numOfDeaths;
    [SerializeField] private bool[] _levelsComplete;
    [SerializeField] private string _highScore;
    [SerializeField] private Level _currentLevel;
    [SerializeField] private int _currentProfile;
    [SerializeField] private int _fruitAte;
    [SerializeField] private string[] _unlockedAchievements = new string[MAX_ACHIEVEMENTS];

    [SerializeField] private int _hP; 
    private const int MAX_ACHIEVEMENTS = 100;

    public string[] UnlockedAchievements
    {
        get { return _unlockedAchievements; }
        set { _unlockedAchievements = value; }
    }
    public int NumOfDeaths
    {
        get { return _numOfDeaths; }
        set { _numOfDeaths = value; }
    }

    public bool[] LevelsComplete
    {
        get { return _levelsComplete; }
        set { _levelsComplete = value; }
    }

    public string HighScore
    {
        get { return _highScore; }
        set { _highScore = value; }
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

    public int HP
    {
        get { return _hP; }
        set { _hP = value; }
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
        _levelsComplete = new bool[Enum.GetNames(typeof(Level)).Length];
        _currentProfile = 0;
        _numOfDeaths = 0;
        _highScore = "0";
        _fruitAte = 0;
        _hP = 5;
        _unlockedAchievements = new string[MAX_ACHIEVEMENTS];
        
    }
}
