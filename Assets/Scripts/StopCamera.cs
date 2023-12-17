using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCamera : MonoBehaviour
{
    public GameObject btn;
    public void StopFunction()
    {   GameObject tmp=Instantiate(btn);
        tmp.transform.position = gameObject.transform.position;
        Time.timeScale = 0;
        
        Debug.Log("work..?");
    }
}
