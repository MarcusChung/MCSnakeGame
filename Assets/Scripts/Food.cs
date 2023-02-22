using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Food : MonoBehaviour
{
    
    private RandomScriptBehaviour randomFoodGenerator;
    // Start is called before the first frame update
    void Start()
    {
        randomPosition();
    }

    private void randomPosition(){
        int x = Random.Range(-17, 20);
        int y = Random.Range(-7, 8);
        transform.position = new Vector2(x, y);
        //prevent food from spawning on snake
        foreach (Transform child in transform.parent){
            if (child.position == transform.position){
                randomPosition();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        randomPosition();
        randomFoodGenerator = FindObjectOfType<RandomScriptBehaviour>();
        randomFoodGenerator.randomSprite();
    }

     //if position of traps is the same as food, move food
    private void OnTriggerStay2D(Collider2D other) {
        randomPosition();
    }
}
