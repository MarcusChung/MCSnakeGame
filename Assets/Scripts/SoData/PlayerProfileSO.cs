using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PlayerProfileSO : ScriptableObject
{
    [SerializeField] private int _NumOfLevelsComplete;
    [SerializeField] private bool[] _LevelsComplete;
    [SerializeField] private int _HighScore;
    [SerializeField] private Level _currentLevel;
    [SerializeField] private int _currentProfile;
    public int NumOfLevelsComplete
    {
        get { return _NumOfLevelsComplete; }
        set { _NumOfLevelsComplete = value; }
    }

    public bool[] LevelsComplete
    {
        get { return _LevelsComplete; }
        set { _LevelsComplete = value; }
    }

    public int HighScore
    {
        get { return _HighScore; }
        set { _HighScore = value; }
    }

    public int CurrentProfile {
        get { return _currentProfile; }
        set { _currentProfile = value; }
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
        _NumOfLevelsComplete = 0;
        _HighScore = 0;
    }
}
