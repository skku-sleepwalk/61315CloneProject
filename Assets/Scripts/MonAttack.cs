using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonAttack : MonoBehaviour
{
    private Animator animator;
    private GameObject MainCharacter;
    private moveRight script;
    private bool flag;
    private void Awake()
        {
            animator = GetComponent<Animator>();
            MainCharacter = GameObject.FindWithTag("MainCharacter");
            script=GetComponent<moveRight>();
            flag = true;
        }
    void Update()
    {
        if(MainCharacter.transform.position.y <gameObject.transform.position.y+1&& MainCharacter.transform.position.y > gameObject.transform.position.y - 1&&flag)
        {
            //animator.SetTrigger("cigaretteRun");
            //여기 들어갈 것은 빨라지는 것
            script.changeVelocity(4);
            flag=false;
        }
        else if (!(MainCharacter.transform.position.y < gameObject.transform.position.y + 1 && MainCharacter.transform.position.y > gameObject.transform.position.y - 1)&&!flag)
        {
            script.changeVelocity(-4);
            flag = true;
        }
    }
}
