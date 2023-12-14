using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionCheck2FallAnimation : MonoBehaviour
{
    private Animator animator;


    private void Awake()
    {
        
        animator = GetComponent<Animator>();
    }
  private void oppositeBool(string changeTrue, string changeFalse)
    {
        animator.SetBool(changeTrue, true);
        animator.SetBool(changeFalse, false);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Floor"))
        {
            oppositeBool("NotFall", "Fall");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        bool fallCheck = true;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        
        if (collision.gameObject.CompareTag("Floor"))
        {
            foreach (Collider2D collider in colliders)
        {
                if (collider.gameObject.tag == "Floor") fallCheck = false;
        }
            if(fallCheck)
            oppositeBool("Fall","NotFall");
        }
    }
   
}
