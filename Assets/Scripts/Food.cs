using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(SpriteRenderer))]
public class Food : MonoBehaviour
{
    
    private RandomScriptBehaviour randomFoodGenerator;
    // Start is called before the first frame update
    private void Start()
    {
        randomPosition();
    }

    private void randomPosition(){
        
        int x = Random.Range(-17, 20);
        int y = Random.Range(-7, 8);

    //prevent food from spawning on traps
    Tilemap trapsTilemap = GameObject.Find("Traps").GetComponent<Tilemap>();
    Vector3Int cellPosition = trapsTilemap.WorldToCell(new Vector3(x, y, 0));
    if (trapsTilemap.HasTile(cellPosition)) {
        randomPosition();
        return;
    }

        transform.position = new Vector2(x, y);
        //prevent food from spawning on snake
        if (transform.parent != null) {
            foreach (Transform child in transform.parent){
                if (child.position == transform.position){
                    randomPosition();
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        randomPosition();
    }

     
}
