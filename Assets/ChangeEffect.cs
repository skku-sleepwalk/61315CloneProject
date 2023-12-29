using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEffect : MonoBehaviour
{
 public RuntimeAnimatorController controller;
    public RuntimeAnimatorController controller1;
    public RuntimeAnimatorController controller2;
  Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if (Score.getScore()%300 ==100)
        {
            animator.runtimeAnimatorController=controller1;
        }
        if (Score.getScore() % 300 == 200)
        {

            animator.runtimeAnimatorController = controller2;
        }
        if(Score.getScore() % 300 == 0)
        {

            animator.runtimeAnimatorController = controller;
        }
    }

}
