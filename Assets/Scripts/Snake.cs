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
        ResetSegments();
      
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
    }
    private void Shrink() 
    {
        if (segments.Count > 3){
            Destroy(segments[segments.Count-1].gameObject);
            segments.RemoveAt(segments.Count-1);
        }
    }

    public int GetScore()
    {
        //score
        int score = segments.Count - 3;
        return score;
    }

    // public int GetScore => segments.Count -3;

    private void FixedUpdate()
    {
        MoveSegments();
        // moveSnake();
    }

    private void MoveSegments()
    {
        //put on top of the one in the front
        for (int i= segments.Count-1; i>0; i--){
            segments[i].transform.position = segments[i-1].transform.position;
        }
    }

    [Tooltip("layer 6 -> obstacle, layer 7 -> food, layer 8 -> poisonFood")]
    private void OnTriggerEnter2D(Collider2D other)
    {
    //collision checks
    if (other.gameObject.layer == 6){
        HideSnake();
        FindObjectOfType<GameManager>().GameOver(true);
    } else if(other.gameObject.layer == 7) {
        Grow();
    } else if(other.gameObject.layer == 8) {
        Shrink();
    }

    //less efficient as the snake grows
    for (int i= 1; i<segments.Count; i++){
                if (segments[i].transform.position == transform.position){
                    HideSnake();
                    FindObjectOfType<GameManager>().GameOver(true);
                }
                // Debug.Log(segments[i].gameObject.layer);
            }
    }

    private void HideSnake()
    {
       snakeHead.SetActive(false);
    }
}
