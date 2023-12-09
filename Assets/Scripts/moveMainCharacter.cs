using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMainCharacter : MonoBehaviour
{
    public float velocity;
    void Update()
    {
         transform.Translate(Vector3.left * Time.deltaTime*velocity);
    }
}
