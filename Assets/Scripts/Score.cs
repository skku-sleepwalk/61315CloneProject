using System.Collections;
using System.Collections.Generic;
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
        score = -((int)Character.transform.position.y - 2);
        //���ΰ��� ��ġ�� ������ ���
        Debug.Log(score);
    }
//���������� ���� �ִϸ��̼��� true true true --> false false false true�� �ȴ�.
}
