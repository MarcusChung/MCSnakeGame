using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager
{
    private Data gameData;
    private static DataManager instance;
    private static string dataFilePath = Path.Combine(Application.persistentDataPath, "GameData.json");
    
    private static string achievementFilePath = Path.Combine(Application.persistentDataPath, "AchievementData.json");

  public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("DataManager is null");
            }
            return instance;
        }
    }

    public DataManager(int level = 0, int profile = 0, int score = 0, int profileNum = 0, int prevLevelScore = 0)
    {
        gameData = new Data();
        gameData.currentLevel = level;
        gameData.currentProfile = profile;
        gameData.score = score;
        gameData.profileNum = profileNum;
        gameData.levelsComplete = new bool[Constants.MAX_PROFILES][];
        gameData.prevLevelScore = prevLevelScore;
        // gameData.lastScores = new int[Constants.MaxProfiles, Constants.MaxLevels];
        gameData.totalDeaths = new int[Constants.MAX_PROFILES];
        gameData.totalFruitAte = new int[Constants.MAX_PROFILES];
        gameData.totalLevelsComplete = new int[Constants.MAX_PROFILES];
        gameData.achievementUnlocked = new bool[Constants.MAX_PROFILES];
    }

    // Here we set our level with some sort of GameManager
    public void SetCurrentLevel(int level)
    {
        if (gameData == null)
        {
            gameData = new Data();
            gameData.lastScores = new int[Constants.MAX_PROFILES, Constants.MAX_LEVELS];
        }

        gameData.currentLevel = level;
    }

    public void SetCurrentProfile(int profile)
    {
        if (gameData == null)
        {
            gameData = new Data();
            gameData.lastScores = new int[Constants.MAX_PROFILES, Constants.MAX_LEVELS];
        }

        gameData.currentProfile = profile;
    }

    // The method to return the loaded game data when needed
    public Data GetGameData()
    {
        return gameData;
    }

    //reset game data
    public void ResetGameData()
    {
        gameData = new Data();
        gameData.currentLevel = 0;
        gameData.currentProfile = 0;
        gameData.score = 0;
        gameData.profileNum = 0;
        gameData.levelsComplete = new bool[Constants.MAX_PROFILES][];
        gameData.prevLevelScore = 0;
        // gameData.lastScores = new int[Constants.MaxProfiles, Constants.MaxLevels];
        gameData.totalDeaths = new int[Constants.MAX_PROFILES];
        gameData.totalFruitAte = new int[Constants.MAX_PROFILES];
        gameData.totalLevelsComplete = new int[Constants.MAX_PROFILES];
        gameData.achievementUnlocked = new bool[Constants.ACHIEVEMENT_COUNT];
        Debug.Log("Game data reset");
    }

    public void ResetSpecificProfileData(int profile)
    {
        if (gameData == null)
        {
            gameData = new Data();
            gameData.lastScores = new int[Constants.MAX_PROFILES, Constants.MAX_LEVELS];
        }

        gameData.totalDeaths[profile] = 0;
        gameData.totalFruitAte[profile] = 0;
        gameData.totalLevelsComplete[profile] = 0;
        gameData.levelsComplete[profile] = new bool[Constants.NUM_OF_LEVELS];
        Debug.Log("profile " + profile + " reset");
    }

   public int GetTotalDeaths(int profile)
{
    if (gameData == null)
    {
        gameData = new Data();
        gameData.totalDeaths = new int[Constants.MAX_PROFILES];
    }

    if (profile < 0 || profile >= gameData.totalDeaths.Length)
    {
        Debug.LogError("Invalid profile index: " + profile);
        SetNumOfDeaths(0, profile);
        return 0; // or some other default value
    }

    return gameData.totalDeaths[profile];
}

    public int SetNumOfDeaths(int deaths, int profile)
    {
        if (gameData == null)
        {
            gameData = new Data();
            gameData.totalDeaths = new int[Constants.MAX_PROFILES];
        }

        gameData.totalDeaths[profile] = deaths;
        return gameData.totalDeaths[profile];
    }

    public int GetNumOfFruitAte(int profile){
    if (gameData == null)
    {
        gameData = new Data();
        gameData.totalFruitAte = new int[Constants.MAX_PROFILES];
    }
    else if (gameData.totalFruitAte == null || profile >= gameData.totalFruitAte.Length)
    {
        gameData.totalFruitAte = new int[Constants.MAX_PROFILES];
    }

    return gameData.totalFruitAte[profile];
}

public int SetNumOfFruitAte(int fruitAte, int profile){
    if (gameData == null)
    {
        gameData = new Data();
        gameData.totalFruitAte = new int[Constants.MAX_PROFILES];
    }
    else if (gameData.totalFruitAte == null || profile >= gameData.totalFruitAte.Length)
    {
        int[] newArray = new int[profile + 1];
        Array.Copy(gameData.totalFruitAte, newArray, gameData.totalFruitAte.Length);
        gameData.totalFruitAte = newArray;
    }

    gameData.totalFruitAte[profile] = fruitAte;
    return gameData.totalFruitAte[profile];
}

public int GetNumOfLevelsComplete(int profile)
{
    if (gameData == null)
    {
        gameData = new Data();
        gameData.totalLevelsComplete = new int[Constants.MAX_PROFILES];
    }
    else if (gameData.totalLevelsComplete == null || profile >= gameData.totalLevelsComplete.Length)
    {
        gameData.totalLevelsComplete = new int[Constants.MAX_PROFILES];
    }

    return gameData.totalLevelsComplete[profile];
}

public int SetNumOfLevelsComplete(int levelsComplete, int profile)
{
    if (gameData == null)
    {
        gameData = new Data();
        gameData.totalLevelsComplete = new int[Constants.MAX_PROFILES];
    }
    else if (gameData.totalLevelsComplete == null || profile >= gameData.totalLevelsComplete.Length)
    {
        int[] newArray = new int[profile + 1];
        Array.Copy(gameData.totalLevelsComplete, newArray, gameData.totalLevelsComplete.Length);
        gameData.totalLevelsComplete = newArray;
    }

    gameData.totalLevelsComplete[profile] = levelsComplete;
    return gameData.totalLevelsComplete[profile];
}

// public bool GetAchievementStatus(int achievementNum)
// {
//     if (gameData == null)
//     {
//         gameData = new Data();
//         gameData.achievementUnlocked = new bool[Constants.ACHIEVEMENT_COUNT];
//     }
//     else if (gameData.achievementUnlocked == null)
//     {
//         gameData.achievementUnlocked = new bool[Constants.ACHIEVEMENT_COUNT];
//     }

//     return gameData.achievementUnlocked[achievementNum];
// }

// public void SetAchievementStatus(bool unlocked, int achievementNum)
// {
//     if (gameData == null)
//     {
//         gameData = new Data();
//         gameData.achievementUnlocked = new bool[Constants.ACHIEVEMENT_COUNT];
//     }
//     else if (gameData.achievementUnlocked == null)
//     {
//         gameData.achievementUnlocked = new bool[Constants.ACHIEVEMENT_COUNT];
//     }

//     gameData.achievementUnlocked[achievementNum] = unlocked;
// }

public void SaveAchievement(string achievementName)
{
    // Load the saved achievements
    Dictionary<string, bool> savedAchievements = LoadAchievements();

    // Add or update the achievement
    // savedAchievements[achievementName] = unlocked;

    // Convert the dictionary to JSON and save it to disk
    string dataToWrite = JsonUtility.ToJson(savedAchievements);
    using (StreamWriter writer = new StreamWriter(achievementFilePath))
    {
        writer.Write(dataToWrite);
    }
}

public Dictionary<string, bool> LoadAchievements()
{
    if (!File.Exists(achievementFilePath))
    {
        return null;
    }

    using (StreamReader reader = new StreamReader(achievementFilePath))
    {
        string dataToLoad = reader.ReadToEnd();
        return JsonUtility.FromJson<Dictionary<string, bool>>(dataToLoad);
    }
}

public bool[] GetLevelsComplete(int profile)
{
    if (gameData == null)
    {
        Debug.Log("gameData is null");
        gameData = new Data();
        gameData.levelsComplete = new bool[Constants.MAX_PROFILES][];
    }
    if (gameData.levelsComplete[profile] == null)
    {
        gameData.levelsComplete[profile] = new bool[Constants.NUM_OF_LEVELS];
    }
    
    if (gameData.levelsComplete[profile].Length != Constants.NUM_OF_LEVELS)
    {
        Debug.Log("Resizing levelsComplete array");
        Array.Resize(ref gameData.levelsComplete[profile], Constants.NUM_OF_LEVELS);
    }
    return gameData.levelsComplete[profile];
}
public void SetLevelsComplete(bool[] levelsComplete, int profile)
{
    if (gameData == null)
    {
        Debug.Log("gameData is null");
        gameData = new Data();
        gameData.levelsComplete = new bool[Constants.MAX_PROFILES][];
    }
    if (gameData.levelsComplete[profile] == null)
    {
        gameData.levelsComplete[profile] = new bool[Constants.NUM_OF_LEVELS];
    }

    for (int i = 0; i < levelsComplete.Length; i++)
    {
        gameData.levelsComplete[profile][i] = levelsComplete[i];
        Debug.Log("SetLevelsComplete "+ i + " profile:" + profile + " " + gameData.levelsComplete[profile][i]);
    }
    Save();
    // gameData.levelsComplete[profile] = levelsComplete;
}

    public void Save()
    {
        // This creates a new StreamWriter to write to a specific file path
        using (StreamWriter writer = new StreamWriter(dataFilePath))
        {
            // This will convert our Data object into a string of JSON
            string dataToWrite = JsonUtility.ToJson(gameData);

            // This is where we actually write to the file
            writer.Write(dataToWrite);
            writer.Close();
        }
        
    }

    public void Load()
    {
        // This creates a StreamReader, which allows us to read the data from the specified file path
        using (StreamReader reader = new StreamReader(dataFilePath))
        {
            // We read in the file as a string
            string dataToLoad = reader.ReadToEnd();

            // Here we convert the JSON formatted string into an actual Object in memory
            gameData = JsonUtility.FromJson<Data>(dataToLoad);
            reader.Close();
        }
    }

    [System.Serializable]
    public class Data
    {
        public int currentLevel = 0;
        public int currentProfile = 0;
        public int score = 0;
        public int profileNum = 0;
        public int prevLevelScore = 0;
        public int[,] lastScores = new int[Constants.MAX_PROFILES, Constants.MAX_LEVELS];

        public int[] totalDeaths = new int[Constants.MAX_PROFILES];
        public int[] totalFruitAte = new int[Constants.MAX_PROFILES];

        public bool[][] levelsComplete = new bool[Constants.MAX_PROFILES][];

        public int[] totalLevelsComplete = new int[Constants.MAX_PROFILES];

        public bool[] achievementUnlocked = new bool[Constants.ACHIEVEMENT_COUNT];
    }

    public static class Constants
    {
        public const int MAX_PROFILES = 5;
        public const int MAX_LEVELS = 10;

        public const int NUM_OF_LEVELS = 5;

        public const int ACHIEVEMENT_COUNT = 5;
    }

    // public void SetLastScore(int score, int profile, int level)
    // {
    //     if (gameData == null)
    //     {
    //         gameData = new Data();
    //         gameData.lastScores = new int[Constants.MaxProfiles, Constants.MaxLevels];
    //     }
    //     if (gameData.lastScores == null)
    //     {
    //         Debug.Log("(set)lastScores is null, creating new array");
    //         gameData.lastScores = new int[Constants.MaxProfiles, Constants.MaxLevels];
    //     }

    //     gameData.lastScores[profile, level] = score;
    // }

    // public int GetLastScore(int profile, int level)
    // {
    //     if (gameData == null)
    //     {
    //         gameData = new Data();
    //         gameData.lastScores = new int[Constants.MaxProfiles, Constants.MaxLevels];
    //     }
    //     if (gameData.lastScores == null)
    //     {
    //         Debug.Log("(get)lastScores is null, creating new array");
    //         gameData.lastScores = new int[Constants.MaxProfiles, Constants.MaxLevels];
    //     }

    //     return gameData.lastScores[profile, level];
    // }
}

