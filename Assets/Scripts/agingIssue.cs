using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agingIssue : MonoBehaviour
{
    private Animator animator;

    public RuntimeAnimatorController[] cigarette=new RuntimeAnimatorController[12];//3.4.4

    private int age;
    private int[] ageTable = { 15, 30, 38,17};
        private int index = 0;
   private void Awake()
    {
        age = 15;

        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = cigarette[0];
        while ((Score.getScore() > age))
        {
            if (Score.getScore() > age )
            {
               
               
                    age += ageTable[index%4];
                    index++;
                    animator.runtimeAnimatorController = cigarette[index%12];
                   
                
                
                // 객체 하나 생성 시 끝까지 작동, 3회차 이상일 경우 큰 비용 발생 가능
            }
            //뒤
        }

    }
    private void Update()
    {

        if (Score.getScore() > age)
        {


            age += ageTable[index % 4];
            index++;
            animator.runtimeAnimatorController = cigarette[index % 12];
        }


    }
}
