using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    Vector2 direction;
    [SerializeField] private GameObject segment;
    [SerializeField] private List<GameObject> segments = new List<GameObject>();
    // Start is called before the first frame update
    private void Start()
    {
        reset();
    }
    private void reset(){
        // pos, rot, dir, time
        transform.position = new Vector2(0,0);
        transform.rotation = Quaternion.Euler(0,0, -90);
        direction = Vector2.right;
        Time.timeScale = 0.2f;
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

    private void grow() {
        GameObject newSegment = Instantiate(segment);
        newSegment.transform.position = segments[segments.Count-1].transform.position;
        segments.Add(newSegment);
    }

    // Update is called once per frame
    private void Update()
    {
        getUserInput();
    }

    private void getUserInput(){
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
            reset();
        }
    }

    private void FixedUpdate() {
        moveSegments();
        moveSnake();
    }

    private void moveSegments(){
        //put on top of the one in the front
        for (int i= segments.Count-1; i>0; i--){
            segments[i].transform.position = segments[i-1].transform.position;
        }
    }

    private void moveSnake(){
        float x = transform.position.x + direction.x;
        float y = transform.position.y + direction.y;
        transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
       //collision checks
        if (other.gameObject.tag == "Obstacle"){
            //Time.timeScale = 0;
            reset();
        } else if(other.tag == "Food") {
            grow();
        }
        // if player collides with tail
        for (int i= 1; i<segments.Count; i++){
            if (segments[i].transform.position == transform.position){
                //Time.timeScale = 0;
                reset();
            }
        }
    }
}
