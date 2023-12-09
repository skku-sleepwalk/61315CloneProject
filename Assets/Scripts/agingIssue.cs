using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agingIssue : MonoBehaviour
{
    private Animator animator;
    public RuntimeAnimatorController init;
    public RuntimeAnimatorController[] cigarette=new RuntimeAnimatorController[3];
    
    private int age;
    private int[] ageTable = { 15, 30, 40 };
        private int index = 0;
   private void Awake()
    {
        age = 5;
        
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController=init;
        while ((Score.getScore() > age))
        {
            if (Score.getScore() > age)
            {
                age += ageTable[index];
                animator.runtimeAnimatorController = cigarette[index++];
                // ��ü �ϳ� ���� �� ������ �۵�, 3ȸ�� �̻��� ��� ū ��� �߻� ����
            }
            //��
        }

    }
    private void Update()
    {
        while((Score.getScore() > age))
        {
            if (Score.getScore() > age)
            {
                age += ageTable[index];
                animator.runtimeAnimatorController = cigarette[index++];
                // ��ü �ϳ� ���� �� ������ �۵�, 3ȸ�� �̻��� ��� ū ��� �߻� ����
            }
            //��
        }
 
        
    }
}
