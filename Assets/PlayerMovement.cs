using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // public Rigidbody2D rb;
    // private Vector3Int gridPos;
    
    public float moveSpeed = 5f;
    public Transform movePoint;
    private void Start()
    {
        movePoint.parent = null;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position,movePoint.position) <= .05f){
        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            } else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) 
            {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
        }
      
        // if (Input.GetKey("d"))
        // {
        //    //rb.velocity = new Vector2(5, 0);
        //     //change the position of the player
        //     gridPos.x += 1;
        //     transform.position =gridPos;
        // }
        // if (Input.GetKey("a"))
        // {
        //     //rb.velocity = new Vector2(-5, 0);
        //     gridPos.x -= 1;
        //     transform.position =gridPos;
        // }
        // if (Input.GetKey("s")){
        //     //rb.velocity = new Vector2(0, -5);
        //     gridPos.y -= 1;
        //     transform.position =gridPos;
        // }
        //  if (Input.GetKey("w"))
        // {
        //    //rb.velocity = new Vector2(0, 5);
        //     gridPos.y += 1;
        //     transform.position =gridPos;
        // }
        //  if (Input.GetKey("space"))
        // {
        //     GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7);
        // }

    }
}
