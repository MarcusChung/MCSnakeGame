using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamIntegration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        try{
            Steamworks.SteamClient.Init(1650860);
        } catch (System.Exception e){
            Debug.Log(e);
        }
    }
}
