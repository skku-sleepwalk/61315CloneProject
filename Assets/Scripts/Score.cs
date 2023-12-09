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
        //주인공의 위치를 나누어 계산
        Debug.Log(score);
    }
//성장정도에 대한 애니메이션은 true true true --> false false false true가 된다.
}
