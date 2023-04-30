using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Snake : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private GameObject segment;
    [SerializeField] public List<GameObject> segments = new List<GameObject>();
    [SerializeField] private GameObject snakeHead;
    private RandomScriptBehaviour randomFoodGenerator;
    private List<Vector2> segmentPositions = new List<Vector2>();
    private GameManager gameManager;

    private FreezeItem freezeItem;
    private BadFood badFood;

    private const int SNAKE_BODY_LAYER = 10;
    private const int SNAKE_HEAD_LAYER = 11;
    private void Start()
    {
        freezeItem = FindObjectOfType<FreezeItem>();
        badFood = FindObjectOfType<BadFood>();
        ResetSegments();
        segmentPositions.Add(transform.position);
        gameManager = FindObjectOfType<GameManager>();

        snakeHead.layer = SNAKE_HEAD_LAYER;
        StartCoroutine(ResetSnakeHeadLayer());
    }

    private IEnumerator ResetSnakeHeadLayer()
    {
        yield return new WaitForSeconds(0.5f); // wait for 0.5 seconds
        snakeHead.layer = 0;
    }


    private void ResetSegments()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(gameObject);
        for (int i = 1; i < 3; i++)
        {
            Grow();
        }
    }



    private void Grow()
    {
        GameObject newSegment = Instantiate(segment);
        newSegment.transform.position = segments[segments.Count - 1].transform.position;
        segmentPositions.Insert(segments.Count - 1, newSegment.transform.position); // add the new segment position to the list
        //gives the new segment the layer "SnakeBody"
        newSegment.layer = SNAKE_BODY_LAYER;
        segments.Add(newSegment);
    }
    private void Shrink()
    {
        if (segments.Count > 3)
        {
            Destroy(segments[segments.Count - 1].gameObject);
            segments.RemoveAt(segments.Count - 1);
        }
    }


    // public void SlowSnake(float slowFactor)
    // {
    //     Time.timeScale = slowFactor;
    // }

    public void Unslow(float unslowFactor)
    {
        Time.timeScale = unslowFactor;
    }

    public int GetScore()
    {
        return segments.Count - 3;
    }

    private void FixedUpdate()
    {
        MoveSegments();
    }

    private void MoveSegments()
    {
        //put on top of the one in the front
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].transform.position = segments[i - 1].transform.position;
        }
    }

    [Tooltip("layer 3 -> snakeBody, layer 6 -> obstacle, layer 7 -> food, layer 8 -> poisonFood, layer 9 -> freeze item")]
    private void OnTriggerEnter2D(Collider2D other)
    {
        //collision checks
        if (other.gameObject.layer == 6)
        {
            HideSnakeHead();
            gameManager.GameOver(true);
        }
        else if (other.gameObject.layer == 7)
        {
            Grow();
            segmentPositions.Add(segments[segments.Count - 2].transform.position); // add the old position of the last segment to the list
            //when snake eats food it will change the sprite
            randomFoodGenerator = FindObjectOfType<RandomScriptBehaviour>();
            randomFoodGenerator.randomSprite();
        }
        else if (other.gameObject.layer == 8)
        {
            Shrink();
            badFood.AccumulatePoison();
        }
        else if (other.gameObject.layer == 9)
        {
            freezeItem.SlowSnake();
        }
        else if (other.gameObject.layer == SNAKE_BODY_LAYER)
        {
            if (snakeHead.layer == SNAKE_HEAD_LAYER)
            {
                // ignore collision if the snake head layer not reset yet
                return;
            }
            HideSnakeHead();
            gameManager.GameOver(true);
        }
        gameManager.CheckScore();
    }

    public void HideSnakeHead()
    {
        snakeHead.SetActive(false);
    }



}
