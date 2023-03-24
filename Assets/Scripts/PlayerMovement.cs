using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour, IEntity
{
    private Vector3Int gridPos;
    private Vector2 direction;
    private bool undoActive;
    private bool playerInput;

    [SerializeField] private CommandProcessor _commandProcessor;

        private void Awake()
        {
        // _commandProcessor = GetComponent<CommandProcessor>();
        // Debug.Log(_commandProcessor);
        }

        private void Start()
        {
            undoActive = false;
            playerInput = false;
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
        
        //prevent snake from going backwards
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
            // buttonW.Execute();
            direction = Vector2.up;
            transform.rotation = Quaternion.Euler (0, 0, 0);
            playerInput = true;
           // _commandProcessor.ExecuteCommand(new MoveCommand(this, direction, transform));
        } else if (Input.GetKeyDown(KeyCode.S)) {
            direction = Vector2.down;
            transform.rotation = Quaternion.Euler (0, 0, 180);
            playerInput = true;
           // _commandProcessor.ExecuteCommand(new MoveCommand(this, direction, transform));
        } else if (Input.GetKeyDown(KeyCode.A)) {
            direction = Vector2.left;
            transform.rotation = Quaternion.Euler (0, 0, 90);
            playerInput = true;
            //_commandProcessor.ExecuteCommand(new MoveCommand(this, direction, transform));
        } else if (Input.GetKeyDown(KeyCode.D)) {
            direction = Vector2.right;
            transform.rotation = Quaternion.Euler (0, 0, -90);
            playerInput = true;
            //_commandProcessor.ExecuteCommand(new MoveCommand(this, direction, transform));
        } else if (Input.GetKeyDown(KeyCode.R)) {
            // Reset()
            undoActive = true;
        }
    }

    private void Update()
    {   
        if (undoActive){
            if (_commandProcessor != null){
            _commandProcessor.UndoCommand();
            undoActive = false;
            }
            undoActive = false;
        }
        else if (playerInput){
            // Debug.Log("moving");
            _commandProcessor.ExecuteCommand(new MoveCommand(this, direction, transform));
            playerInput = false;
        }
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
