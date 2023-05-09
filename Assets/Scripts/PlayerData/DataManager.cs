using System;
using System.IO;
using UnityEngine;

public class DataManager
{
    private Data gameData;
    private static string dataFilePath = Path.Combine(Application.persistentDataPath, "GameData.json");

    public DataManager(int level = 0, int profile = 0, int score = 0, int profileNum = 0, int prevLevelScore = 0)
    {
        gameData = new Data();
        gameData.currentLevel = level;
        gameData.currentProfile = profile;
        gameData.score = score;
        gameData.profileNum = profileNum;
        gameData.levelsComplete = new bool[Constants.MaxProfiles][];
        gameData.prevLevelScore = prevLevelScore;
        // gameData.lastScores = new int[Constants.MaxProfiles, Constants.MaxLevels];
        gameData.totalDeaths = new int[Constants.MaxProfiles];
        gameData.totalFruitAte = new int[Constants.MaxProfiles];
        gameData.totalLevelsComplete = new int[Constants.MaxProfiles];
    }

    // Here we set our level with some sort of GameManager
    public void SetCurrentLevel(int level)
    {
        if (gameData == null)
        {
            gameData = new Data();
            gameData.lastScores = new int[Constants.MaxProfiles, Constants.MaxLevels];
        }

        gameData.currentLevel = level;
    }

    public void SetCurrentProfile(int profile)
    {
        if (gameData == null)
        {
            gameData = new Data();
            gameData.lastScores = new int[Constants.MaxProfiles, Constants.MaxLevels];
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
        gameData.levelsComplete = new bool[Constants.MaxProfiles][];
        gameData.prevLevelScore = 0;
        // gameData.lastScores = new int[Constants.MaxProfiles, Constants.MaxLevels];
        gameData.totalDeaths = new int[Constants.MaxProfiles];
        gameData.totalFruitAte = new int[Constants.MaxProfiles];
        gameData.totalLevelsComplete = new int[Constants.MaxProfiles];
        Debug.Log("Game data reset");
    }

   public int GetTotalDeaths(int profile)
{
    if (gameData == null)
    {
        gameData = new Data();
        gameData.totalDeaths = new int[Constants.MaxProfiles];
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
            gameData.totalDeaths = new int[Constants.MaxProfiles];
        }

        gameData.totalDeaths[profile] = deaths;
        return gameData.totalDeaths[profile];
    }

    public int GetNumOfFruitAte(int profile){
    if (gameData == null)
    {
        gameData = new Data();
        gameData.totalFruitAte = new int[Constants.MaxProfiles];
    }
    else if (gameData.totalFruitAte == null || profile >= gameData.totalFruitAte.Length)
    {
        gameData.totalFruitAte = new int[Constants.MaxProfiles];
    }

    return gameData.totalFruitAte[profile];
}

public int SetNumOfFruitAte(int fruitAte, int profile){
    if (gameData == null)
    {
        gameData = new Data();
        gameData.totalFruitAte = new int[Constants.MaxProfiles];
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
        gameData.totalLevelsComplete = new int[Constants.MaxProfiles];
    }
    else if (gameData.totalLevelsComplete == null || profile >= gameData.totalLevelsComplete.Length)
    {
        gameData.totalLevelsComplete = new int[Constants.MaxProfiles];
    }

    return gameData.totalLevelsComplete[profile];
}

public int SetNumOfLevelsComplete(int levelsComplete, int profile)
{
    if (gameData == null)
    {
        gameData = new Data();
        gameData.totalLevelsComplete = new int[Constants.MaxProfiles];
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

public bool[] GetLevelsComplete(int profile)
{
    if (gameData == null)
    {
        Debug.Log("gameData is null");
        gameData = new Data();
        gameData.levelsComplete = new bool[Constants.MaxProfiles][];
    }
    if (gameData.levelsComplete[profile] == null)
    {
        gameData.levelsComplete[profile] = new bool[Constants.NumOfLevels];
    }
    
    if (gameData.levelsComplete[profile].Length != Constants.NumOfLevels)
    {
        Debug.Log("Resizing levelsComplete array");
        Array.Resize(ref gameData.levelsComplete[profile], Constants.NumOfLevels);
    }
    return gameData.levelsComplete[profile];
}
public void SetLevelsComplete(bool[] levelsComplete, int profile)
{
    if (gameData == null)
    {
        Debug.Log("gameData is null");
        gameData = new Data();
        gameData.levelsComplete = new bool[Constants.MaxProfiles][];
    }
    if (gameData.levelsComplete[profile] == null)
    {
        gameData.levelsComplete[profile] = new bool[Constants.NumOfLevels];
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
        public int[,] lastScores = new int[Constants.MaxProfiles, Constants.MaxLevels];

        public int[] totalDeaths = new int[Constants.MaxProfiles];
        public int[] totalFruitAte = new int[Constants.MaxProfiles];

        public bool[][] levelsComplete = new bool[Constants.MaxProfiles][];

        public int[] totalLevelsComplete = new int[Constants.MaxProfiles];
    }

    public static class Constants
    {
        public const int MaxProfiles = 5;
        public const int MaxLevels = 10;

        public const int NumOfLevels = 5;
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

