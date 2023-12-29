using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class reviveBtn : MonoBehaviour
{
    void OnMouseDown()
    {
        revive.reviveFunction();
        Destroy(gameObject);
    }
   
}
