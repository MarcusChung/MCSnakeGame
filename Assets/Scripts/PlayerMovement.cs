using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3Int gridPos;
    private Vector2 direction;

        private void Start()
        {
            Reset();
        }
       private void Reset()
        {
        // pos, rot, dir, time
            transform.position = new Vector2(0,0);
            transform.rotation = Quaternion.Euler(0,0, -90);
            direction = Vector2.right;
            Time.timeScale = 0.2f;
        }
      private void GetUserInput()
      {

        // prevent snake from going backwards
        if(direction == Vector2.up){
            if (Input.GetKeyDown(KeyCode.S)) return;
        }
         if(direction == Vector2.down){
            if (Input.GetKeyDown(KeyCode.W)) return;
        }
         if(direction == Vector2.right){
            if (Input.GetKeyDown(KeyCode.A)) return;
        }
         if(direction == Vector2.left){
            if (Input.GetKeyDown(KeyCode.D)) return;
        }

        // get input
        if (Input.GetKeyDown(KeyCode.W)) {
            direction = Vector2.up;
            transform.rotation = Quaternion.Euler (0, 0, 0);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            direction = Vector2.down;
            transform.rotation = Quaternion.Euler (0, 0, 180);
        } else if (Input.GetKeyDown(KeyCode.A)) {
            direction = Vector2.left;
            transform.rotation = Quaternion.Euler (0, 0, 90);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            direction = Vector2.right;
            transform.rotation = Quaternion.Euler (0, 0, -90);
        } else if (Input.GetKeyDown(KeyCode.R)) {
            Reset();
        }
    }

    private void Update()
    {
        GetUserInput();
    }
    private void FixedUpdate()
    {
        moveSnake();
    }

    private void moveSnake()
    {
        float x = transform.position.x + direction.x;
        float y = transform.position.y + direction.y;
        transform.position = new Vector2(x, y);
    }
}
