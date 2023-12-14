using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agingIssue : MonoBehaviour
{
    private Animator animator;
    public RuntimeAnimatorController init;
    public RuntimeAnimatorController[] cigarette=new RuntimeAnimatorController[11];//3.4.4
    private int returnNum = -1;
    private int age;
    private int[] ageTable = { 15, 30, 38 };
        private int index = 0;
   private void Awake()
    {
        age = 15;
        returnNum = -1;
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController=init;
        while ((Score.getScore() % 100 > age)&&(Score.getScore() / 100 >returnNum))
        {
            if (Score.getScore() % 100 > age && (Score.getScore() / 100 > returnNum))
            {
                if (age == 98)
                {
                    age = 15;
                    returnNum++;
                    
                    animator.runtimeAnimatorController = cigarette[index % 11];
                    index++;

                }
                else
                {
                    age += ageTable[index];
                    animator.runtimeAnimatorController = cigarette[index%11];
                    index++;
                }
                
                // ��ü �ϳ� ���� �� ������ �۵�, 3ȸ�� �̻��� ��� ū ��� �߻� ����
            }
            //��
        }

    }
    private void Update()
    {
        while ((Score.getScore() % 100 > age) && (Score.getScore()  / 100 > returnNum))
        {
            if (Score.getScore() % 100 > age && (Score.getScore() / 100 > returnNum))
            {
                if (age == 98)
                {
                    age = 15;
                    returnNum++;
                    animator.runtimeAnimatorController = cigarette[index % 11];
                    index++;

                }
                else
                {
                    age += ageTable[index];
                    animator.runtimeAnimatorController = cigarette[index % 11];
                    index++;
                }

                // ��ü �ϳ� ���� �� ������ �۵�, 3ȸ�� �̻��� ��� ū ��� �߻� ����
            }
            //��
        }


    }
}
