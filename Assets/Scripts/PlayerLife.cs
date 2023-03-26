using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 6){
            Die();
            
        }
    }

    private void Die(){
        anim.SetTrigger("death");
        Debug.Log("Player died animation");
    }

}
