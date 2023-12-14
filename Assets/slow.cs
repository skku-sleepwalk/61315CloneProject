using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainCharacter"))
        {
            collision.gameObject.GetComponent<moveMainCharacter>().velocity -= 0.4f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainCharacter"))
        {
            collision.gameObject.GetComponent<moveMainCharacter>().velocity += 0.4f;
        }
    }
    // Update is called once per frame
   
}
