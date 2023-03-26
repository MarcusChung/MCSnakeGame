using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private GameObject segment;
    [SerializeField] private List<GameObject> segments = new List<GameObject>();
    [SerializeField] private GameObject snakeHead;
    private RandomScriptBehaviour randomFoodGenerator;
    private List<Vector2> segmentPositions = new List<Vector2>();

    private void Start()
    {
        ResetSegments();
        segmentPositions.Add(transform.position);
    }
    
 
    private void ResetSegments(){
        for (int i= 1; i<segments.Count; i++){
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(gameObject);
        for (int i= 1; i<3; i++){
            Grow();
        }
    }

     

    private void Grow() 
    {
        GameObject newSegment = Instantiate(segment);
        newSegment.transform.position = segments[segments.Count-1].transform.position;
        segments.Add(newSegment);
        segmentPositions.Add(newSegment.transform.position);
    }
    private void Shrink() 
    {
        if (segments.Count > 3){
            Destroy(segments[segments.Count-1].gameObject);
            segments.RemoveAt(segments.Count-1);
        }
    }

    public void FreezeSnake(){
        Time.timeScale = 0;
    }

    public void SlowSnake(float slowFactor){
        Time.timeScale = slowFactor;
    }

    public void Unslow(float unslowFactor){
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
        for (int i= segments.Count-1; i>0; i--){
            segments[i].transform.position = segments[i-1].transform.position;
        }
    }

    [Tooltip("layer 6 -> obstacle, layer 7 -> food, layer 8 -> poisonFood, layer 9 -> freeze item")]
    private void OnTriggerEnter2D(Collider2D other)
    {
    //collision checks
    if (other.gameObject.layer == 6){
        HideSnakeHead();
        FindObjectOfType<GameManager>().GameOver(true);
    } else if(other.gameObject.layer == 7) {
        Grow();
        //when snake eats food it will change the sprite
        randomFoodGenerator = FindObjectOfType<RandomScriptBehaviour>();
        randomFoodGenerator.randomSprite();
    } else if(other.gameObject.layer == 8) {
        Shrink();
        FindObjectOfType<BadFood>().AccumulatePoison();
    } else if(other.gameObject.layer == 9) {
        FindObjectOfType<FreezeItem>().SlowSnake();
    }

    /** less efficient as the snake grows
     for (int i= 1; i<segments.Count; i++){
                 if (segments[i].transform.position == transform.position){
                     HideSnake();
                     FindObjectOfType<GameManager>().GameOver(true);
                 }
             }
    **/

    // Check for collisions with body segments (more efficient)
    Vector2 headPosition = transform.position;
    for (int i = 1; i < segmentPositions.Count; i++) {
        if (headPosition == segmentPositions[i]) {
            HideSnakeHead();
            FindObjectOfType<GameManager>().GameOver(true);
        }
    }


    FindObjectOfType<GameManager>().CheckScore();

    
    }

    public void HideSnakeHead()
    {
       snakeHead.SetActive(false);
    }
}
