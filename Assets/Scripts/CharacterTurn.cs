using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTurn : MonoBehaviour
{
    public GameObject character;
    private int direction=1;
    private void OnTriggerEnter2D(Collider2D collision)
       
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
 
            if (direction < 0)
            {
                character.transform.rotation = Quaternion.Euler(0, 0, 0); // 원래 방향
                direction = 1;
            }
            else if (direction > 0)
            {

                character.transform.rotation = Quaternion.Euler(0, 180, 0); // 좌우 반전
                direction = -1;
            }
        }
    }

   
}
