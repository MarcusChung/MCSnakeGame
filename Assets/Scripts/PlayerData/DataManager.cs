using System.IO;
using UnityEngine;

public class DataManager
{
    private Data gameData;
    private static string dataFilePath = Path.Combine(Application.persistentDataPath, "GameData.json");

    public DataManager(int level = 0, int profile = 0, int score = 0, int profileNum = 0, int numOfLevelsComplete = 0, int prevLevelScore = 0)
    {
        gameData = new Data();
        gameData.currentLevel = level;
        gameData.currentProfile = profile;
        gameData.score = score;
        gameData.profileNum = profileNum;
        gameData.numOfLevelsComplete = numOfLevelsComplete;
        gameData.prevLevelScore = prevLevelScore;
        // gameData.lastScores = new int[Constants.MaxProfiles, Constants.MaxLevels];
        gameData.totalDeaths = new int[Constants.MaxProfiles];
        gameData.totalFruitAte = new int[Constants.MaxProfiles];
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

    public int GetTotalDeaths(int profile)
    {
        if (gameData == null)
        {
            gameData = new Data();
            gameData.totalDeaths = new int[Constants.MaxProfiles];
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

        return gameData.totalFruitAte[profile];
    }

    public int SetNumOfFruitAte(int fruitAte, int profile){
        if (gameData == null)
        {
            gameData = new Data();
            gameData.totalFruitAte = new int[Constants.MaxProfiles];
        }

        gameData.totalFruitAte[profile] = fruitAte;
        return gameData.totalFruitAte[profile];
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
        }
    }

    [System.Serializable]
    public class Data
    {
        public int currentLevel;
        public int currentProfile;
        public int score;
        public int profileNum;
        public int numOfLevelsComplete;
        public int prevLevelScore;
        public int[,] lastScores;

        public int[] totalDeaths;
        public int[] totalFruitAte;
    }

    public static class Constants
    {
        public const int MaxProfiles = 4;
        public const int MaxLevels = 10;
    }
}
