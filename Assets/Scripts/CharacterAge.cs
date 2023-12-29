using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class CharacterAge : MonoBehaviour
{
    public RuntimeAnimatorController controller;//1회차
    public RuntimeAnimatorController controller2;//2회차
    public RuntimeAnimatorController controller3;//3회차
    public GameObject effect;
    RuntimeAnimatorController[] controllers;
    public AudioClip chapter;
    private int student;
    private Animator animator;
    private int[] ageTable = { 15, 30, 39 };
    private int index = 0;
    private string[] names = { "Student", "Doctor", "Elder", "Return" };//가운데 값 변경하면서 조절
    private string[] job = { "Doctor", "Nurse", "Pharmacist" };
    private string[][] jobs = { new string[] { "Doctor", "Nurse", "Pharmacist" }, new string[] { "Youtuber", "Athelete", "Singer" }, new string[] { "Teacher", "Politician", "Judge" } };
    private int returnNum = -1;
    int rand;
    Animator anim;
    private void Awake()
    {
        anim = effect.GetComponent<Animator>();
        student = 15;
        job = jobs[0];
        rand = Random.Range(0, 3);
        names[1] = job[rand];
        returnNum = 0;

        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = controller;
        controllers = new RuntimeAnimatorController[3];
        controllers[0] = controller;
        controllers[1] = controller2;
        controllers[2] = controller3;

    }

    private void Update()
    {
        if (Score.getScore() % 100 > student || (Score.getScore() / 100 > returnNum))
        {

            if (student == 99) { 
                
               
                    student = 15;
                    returnNum++;
                    animator.runtimeAnimatorController = controllers[(returnNum)%3];
                    job = jobs[(returnNum)%3];
                    rand = Random.Range(0, 3);
                    names[1] = job[rand];
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

           anim.SetTrigger("Effect");


            // 이거 옮겨야
        }
    }
}
