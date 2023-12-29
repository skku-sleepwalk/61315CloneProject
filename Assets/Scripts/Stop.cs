using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop: MonoBehaviour
{
    public GameObject Camera;
    public GameObject btn;
    public static bool stoped;
    public GameObject targetObject;
    private void Awake()
    {
        stoped = false;
    }
    public void StopFunction()
    {   GameObject tmp=Instantiate(btn);
        //targetObject.SetActive(true);
        tmp.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, 0);
        Time.timeScale = 0f;
        CameraMove.isMoving = false;
        stoped=true;
    }
}
