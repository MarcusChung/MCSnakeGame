using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }
    public Data Load()
    {
         string fullPath = Path.Combine(dataDirPath, dataFileName);
         Data loadedData = null;
         if (File.Exists(fullPath))
         {
            try 
            {
                string dataToLoad = "";
                using(FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                //deserialise the data from json back into c# object
                loadedData = JsonUtility.FromJson<Data>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to load data from " + fullPath + " " + e);
            }
         }
         return loadedData;
    }
    
    public void Save(Data data)
    {
        //use Path.Combine to accouynt for different OS's having different path seperators.
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try 
        {
            //create dir if it doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serialise the C# game data object into Json
            string dataToStore = JsonUtility.ToJson(data, true);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to save data to " + fullPath + " " + e.Message);
        }
    }
}
