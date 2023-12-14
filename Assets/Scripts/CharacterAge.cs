using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterAge : MonoBehaviour
{
    public AudioClip chapter;
    private int student;
    private Animator animator;
    private int[] ageTable = { 15, 30, 38 };
    private int index = 0;
    private string[] names = { "Student", "Doctor", "Elder","Return" };//가운데 값 변경하면서 조절
    private int returnNum = -1;
    private void Awake()
    {
        student = 15;

        returnNum = -1;
        animator = GetComponent<Animator>();
        
    }
    
    private void Update()
    {
        if (Score.getScore()%100 > student && (Score.getScore() / 100 > returnNum))
        {
            Debug.Log(student);
            if (student == 98)
            {
                student = 15;
                returnNum++;
                for(int i=0;i<3;i++)
                animator.SetBool(names[i], false);
                animator.SetBool(names[3], true);
                index = 0;
                AudioSource ChapterChanged = GetComponent<AudioSource>();
                ChapterChanged.PlayOneShot(chapter);
            }
            else
            {
                student += ageTable[index];
                if(index==2) animator.SetBool(names[index+1], false);
                animator.SetBool(names[index++], true);
                AudioSource ChapterChanged = GetComponent<AudioSource>();
                ChapterChanged.PlayOneShot(chapter);
            }
            



            // 이거 옮겨야
        }
    }
}
