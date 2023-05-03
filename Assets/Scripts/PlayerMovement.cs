using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour, IEntity
{
    private Vector2 direction;
    private Vector2 gridPos;
    private bool undoActive;
    private bool playerKeyPressed;
    private bool collidedFood;
    private FreezeItem freezeItem;
    private Snake snake;
    [SerializeField] private CommandProcessor _commandProcessor;

    private void Start()
    {
        snake = FindObjectOfType<Snake>();
        freezeItem = FindObjectOfType<FreezeItem>();
        Reset();
    }

    private void Reset()
    {
        transform.position = new Vector2(0, 0);
        transform.rotation = Quaternion.Euler(0, 0, -90);
        direction = Vector2.right;
        Time.timeScale = 0.2f;
        undoActive = false;
        playerKeyPressed = false;
    }

    private void GetUserInput()
    {
             
        //prevent more than two key presses per frame
        if (playerKeyPressed) return;
        //   prevent snake from going backwards
        if (direction == Vector2.up)
        {
            if (Input.GetKeyDown(KeyCode.S)) return;
        }
        if (direction == Vector2.down)
        {
            if (Input.GetKeyDown(KeyCode.W)) return;
        }
        if (direction == Vector2.right)
        {
            if (Input.GetKeyDown(KeyCode.A)) return;
        }
        if (direction == Vector2.left)
        {
            if (Input.GetKeyDown(KeyCode.D)) return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerKeyPressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
            transform.rotation = Quaternion.Euler(0, 0, 180);
            playerKeyPressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
            transform.rotation = Quaternion.Euler(0, 0, 90);
            playerKeyPressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
            transform.rotation = Quaternion.Euler(0, 0, -90);
            playerKeyPressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            undoActive = true;
            freezeItem.SlowSnake();
        }
    }
    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public Vector2 GetDirection()
    {
        return direction;
    }

    public void RemoveSegment()
    {
        snake.Shrink();
    }

    
    private void Update()
    {
        if (undoActive)
        {
            if (_commandProcessor != null)
            {
                _commandProcessor.UndoCommand();
                undoActive = false;
                snake.TempImmunity();
            }
        }
        else
        {
            GetUserInput();
        }
    }
    private void FixedUpdate()
    {
        if (playerKeyPressed)
        {
            // Debug.Log("Executing command");
            _commandProcessor.ExecuteCommand(new MoveCommand(this, direction, transform, transform.position, snake.segments.Count));
            playerKeyPressed = false;
        }
        else
        {
            moveSnake();
        }
   
    }


    public int prevSnakeSegments()
    {
        return snake.prevSnakeSegmentsCount;
    }

    private void moveSnake()
    {
        float x = transform.position.x + direction.x;
        float y = transform.position.y + direction.y;
        transform.position = new Vector2(x, y);
        gridPos = transform.position;
    }

}