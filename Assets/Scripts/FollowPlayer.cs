using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UNUSED SCRIPT
public class FollowPlayer : MonoBehaviour
{
   public Transform player;
    // Update is called once per frame
    private void Update () {
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
}