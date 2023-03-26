using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(SpriteRenderer))]
public class Food : MonoBehaviour
{
   
    
    private RandomScriptBehaviour randomFoodGenerator;
    [SerializeField] private GameObject badFoodPrefab;
    [SerializeField] private int numFoodObjects = 10;
    private void Start()
    {
        randomPosition();
    }

    // private void randomPosition(){
        
    //     int x = Random.Range(-17, 20);
    //     int y = Random.Range(-7, 8);

    // //prevent food from spawning on traps
    // Tilemap trapsTilemap = GameObject.Find("Traps").GetComponent<Tilemap>();
    // Vector3Int cellPosition = trapsTilemap.WorldToCell(new Vector3(x, y, 0));
    // if (trapsTilemap.HasTile(cellPosition)) {
    //     randomPosition();
    //     return;
    // }

    //     transform.position = new Vector2(x, y);
    //     //if food spawns on snake, then generate new position
    //     if (transform.parent != null) {
    //         foreach (Transform child in transform.parent){
    //             if (child.position == transform.position){
    //                 randomPosition();
    //             }
    //         }
    //     }
    // }
    [Tooltip("layer 8 = poisonFood layer, layer 7 = food layer, layer 9 = freeze item")]
    private void randomPosition()
    {
    int x, y;
    Tilemap trapsTilemap = GameObject.Find("Traps").GetComponent<Tilemap>();
    Vector3Int cellPosition;
    do
    {
        x = Random.Range(-17, 20);
        y = Random.Range(-7, 8);

        // Check if the new position is on a trap tile
        cellPosition = trapsTilemap.WorldToCell(new Vector3(x, y, 0));
        if (trapsTilemap.HasTile(cellPosition))
        {
            continue;
        }
        // Check if the new position is already occupied by an existing object
        bool occupied = false;
        foreach (GameObject segment in GameObject.FindObjectsOfType<GameObject>())
        {
            if (segment.layer == 8 && segment.transform.position == new Vector3(x,y,0))
            {
                occupied = true;
                break;
            } else if(segment.layer == 7 && segment.transform.position == new Vector3(x,y,0))
            {
                occupied = true;
                break;
            } else if(segment.layer == 8 && segment.transform.position == new Vector3(x,y,0))
            {
                occupied = true;
                break;
            }
        }
        if (occupied)
        {
            continue;
        }
        // The new position is valid, so break out of the loop
        break;

    } while (true);

    transform.position = new Vector2(x, y);
    }

    public void SpawnObject() 
    {
    for (int i = 0; i < numFoodObjects; i++) {
        // Instantiate the food object
        GameObject foodObject = Instantiate(badFoodPrefab);

        // Set the position of the food object
        int x = Random.Range(-17, 20);
        int y = Random.Range(-7, 8);
        foodObject.transform.position = new Vector2(x, y);
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        randomPosition();
    }

     
}
