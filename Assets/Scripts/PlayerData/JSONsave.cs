using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONsave : MonoBehaviour
{
    private PlayerData playerData;

    private string path = "";
    private string persistentPath = "";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreatePlayerData()
    {
        playerData = new PlayerData("Player", 5, 1);
    }
    // path = Application.dataPath + "/playerData.json";
    // persistentPath = Application.persistentDataPath + "/playerData.json";
    private void SetPaths()
    {
        path = Application.dataPath;
    }
}
