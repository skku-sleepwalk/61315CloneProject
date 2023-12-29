using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static int score;
    public GameObject Character;
    void Awake()
    {
        score = 0;
    }
    public static int getScore()
    {
        return score;
    }
    
    void Update()
    {
        score = (Character.transform.position.y<0 ? -((int)Character.transform.position.y - 2) +1: - ((int)Character.transform.position.y - 2));
        //���ΰ��� ��ġ�� ������ ���
        //Debug.Log(score);
        if(score % 300 >= 200)
        {//���߿� ���� ������ ���ؼ� �ѹ���
            BroadcastMessage("ColorChangeYellow", SendMessageOptions.DontRequireReceiver);
   
            floorChanger.imageNumChanger(2);
        }
        else if (score % 300 >= 100)
        {
            BroadcastMessage("ColorChangePink", SendMessageOptions.DontRequireReceiver);
            floorChanger.imageNumChanger(1);
        }
        else
        {
            BroadcastMessage("ColorChangeBlue", SendMessageOptions.DontRequireReceiver);
            floorChanger.imageNumChanger(0);
        }
    }
//���������� ���� �ִϸ��̼��� true true true --> false false false true�� �ȴ�.
}
