using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class outDisplayBreak : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }
    GameObject character=null;
    private void Awake()
    {
       character =GameObject.FindWithTag("MainCharacter");
    }
    void Update(){
        //ebug.Log(character.transform.position.y);
        if (character)
        {
        if(transform.position.y-character.transform.position.y>5){
                //Pool.Release(this.gameObject);
                Destroy(gameObject);
                //PoolingManager.ReturnObject(gameObject);
            }
        if(transform.position.x-character.transform.position.x>5|| transform.position.x - character.transform.position.x < -5)
            {
                //Pool.Release(this.gameObject);
                Destroy(gameObject);
                //PoolingManager.ReturnObject(gameObject);
            }
        }
        
    }
}
