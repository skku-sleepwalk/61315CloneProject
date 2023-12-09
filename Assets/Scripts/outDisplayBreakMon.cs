using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outDisplayBreakMon : MonoBehaviour
{
     GameObject character=null;
    private void Awake()
    {
       character =GameObject.FindWithTag("MainCharacter");
    }
    void Update(){
        //ebug.Log(character.transform.position.y);
        if (character)
        {
        if(transform.position.y-character.transform.position.y>5|| transform.position.y - character.transform.position.y <-7)
        {
                 Destroy(gameObject);
                //PollingManager.ReturnObject(gameObject);
        }
        if(transform.position.x-character.transform.position.x>10|| transform.position.x - character.transform.position.x < -10)
            {
                Destroy(gameObject);
                //PollingManager.ReturnObject(gameObject);

            }
        }
        
    }
}
