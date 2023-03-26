using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(SpriteRenderer))]
public class BadFood : Food
{
    private int _poisonAccumulation = 0;

    public int PoisonAccumulation 
    {
        get { return _poisonAccumulation; }
        private set { _poisonAccumulation = value; }
    }

    private void Start()
    {
       SpawnObject();
    }

    public void AccumulatePoison()
    {
        _poisonAccumulation++;
        if (_poisonAccumulation == 5) {
            FindObjectOfType<GameManager>().GameOver(true);
        }
    }

}
