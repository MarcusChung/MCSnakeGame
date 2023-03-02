using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private GameObject segment;
    [SerializeField] private List<GameObject> segments = new List<GameObject>();
    [SerializeField] private GameObject snakeHead;
    private void Start()
    {
        resetSegments();
      
    }
    
 
    private void resetSegments(){
        for (int i= 1; i<segments.Count; i++){
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(gameObject);
        for (int i= 1; i<3; i++){
            grow();
        }
    }

     

    private void grow() 
    {
        GameObject newSegment = Instantiate(segment);
        newSegment.transform.position = segments[segments.Count-1].transform.position;
        segments.Add(newSegment);
    }

    public int getScore()
    {
        //score
        int score = segments.Count - 3;
        return score;
    }

    private void FixedUpdate()
    {
        moveSegments();
        // moveSnake();
    }

    private void moveSegments()
    {
        //put on top of the one in the front
        for (int i= segments.Count-1; i>0; i--){
            segments[i].transform.position = segments[i-1].transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       //collision checks
        if (other.gameObject.tag == "Obstacle"){
            hideSnake();
            FindObjectOfType<GameManager>().GameOver();
        } else if(other.tag == "Food") {
            grow();
        }
        // if player collides with tail
            for (int i= 1; i<segments.Count; i++){
                if (segments[i].transform.position == transform.position){
                    hideSnake();
                    FindObjectOfType<GameManager>().GameOver();
                }
            }
    }

    private void hideSnake()
    {
       snakeHead.SetActive(false);
    }
}
