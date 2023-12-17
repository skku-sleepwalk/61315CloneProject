using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class restartBtn : MonoBehaviour
{
    void OnMouseDown()
    {
        BroadcastMessage("restartFunction", SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
   
}
