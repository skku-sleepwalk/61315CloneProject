using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRight : MonoBehaviour
{
    public int velocity;
    public void changeVelocity(int v)
    {
        this.velocity += v;
    }
    
    void Update()
    {
        transform.position -= transform.right * Time.deltaTime * velocity / 10;

    }
}
