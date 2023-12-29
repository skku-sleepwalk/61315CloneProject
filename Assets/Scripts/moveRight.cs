using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class moveRight : MonoBehaviour
{
    public float velocity;
    public void changeVelocity(int v)
    {
        this.velocity += v;
    }
    private void Awake()
    {
        this.velocity = 3;
        int score = Score.getScore();
        while(score > 100) {
            this.velocity += 2f;

            score -= 100;
        }
        
    }

    void Update()
    {
        transform.position -= transform.right * Time.deltaTime * velocity / 10;

    }
}
