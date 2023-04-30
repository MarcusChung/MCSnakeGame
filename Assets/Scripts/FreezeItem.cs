using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FreezeItem : Food
{
    private float slowDuration = 0.5f;
    private float slowFactor = 0.1f;
    // Start is called before the first frame update
    private void Start()
    {
        SpawnObject();
    }

    public void SlowSnake()
    {
        Debug.Log("Slow Snake");
        Time.timeScale = slowFactor;
        // Wait for the slow duration
        StartCoroutine(ResetTimeScale());
    }

    private IEnumerator ResetTimeScale()
    {
    yield return new WaitForSeconds(slowDuration);
    FindObjectOfType<Snake>().Unslow(0.2f);
    }

    

}

