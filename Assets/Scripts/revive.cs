using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revive : MonoBehaviour
{
    public static void reviveFunction()
    {
        Time.timeScale = 1f;
        CameraMove.isMoving = true;
    }
}