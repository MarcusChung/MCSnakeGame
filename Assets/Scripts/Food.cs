using UnityEngine;

public class Food : MonoBehaviour
{
    public Transform startPoint;
    // Start is called before the first frame update
    void Start()
    {
        randomPosition();
    }

    private void randomPosition(){
        int x = Random.Range(-8, 8);
        int y = Random.Range(-8, 6);
        transform.position = new Vector2(x, y);
        transform.position = startPoint.position;
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        randomPosition();
    }
}
