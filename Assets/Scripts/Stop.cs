using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop: MonoBehaviour
{
    public GameObject Camera;
    public GameObject btn;

    public void StopFunction()
    {   GameObject tmp=Instantiate(btn);
        tmp.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, 0);
        Time.timeScale = 0f;
        CameraMove.isMoving = false;

    }
}
