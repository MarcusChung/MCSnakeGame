using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(SpriteRenderer))]
public class BadFood : Food
{
    private int _poisonAccumulation = 0;
    [SerializeField] private HealthBar healthBar;
    public int PoisonAccumulation 
    {
        get { return _poisonAccumulation; }
        private set { _poisonAccumulation = value; }
    }

    private void Start()
    {
       SpawnObject();
       healthBar = FindObjectOfType<HealthBar>();
    }

    public void AccumulatePoison()
    {
        _poisonAccumulation++;
        healthBar.MinusHealth();
        if (_poisonAccumulation == 5) {
            GameManager.Instance.GameOver(true);
            FindObjectOfType<DeathScreen>().ShowScreen();
        }
    }

}
