using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
           rb.velocity = new Vector2(5, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-5, 0);
        }
        if (Input.GetKey("s")){
            rb.velocity = new Vector2(0, -5);
        }
         if (Input.GetKey("w"))
        {
           rb.velocity = new Vector2(0, 5);
        }
         if (Input.GetKey("space"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7);
        }
    }
}
