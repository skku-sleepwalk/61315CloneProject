using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Target; 
    public float offsetX = 0.0f;
    public static bool isMoving;
    Vector3 TargetPos;
    public float fallingSpeed;
    private void Awake()
    {
        isMoving = true;
    }
    void LateUpdate()
    {
        if (isMoving)
        {


            if (Target.transform.position.y < transform.position.y)
            {
                TargetPos = new Vector3(
                Target.transform.position.x + offsetX,
                Target.transform.position.y,
                -10
                );
            }
            else
            {
                TargetPos = new Vector3(
                Target.transform.position.x + offsetX,//X
                transform.position.y - fallingSpeed,//Y
                -10//Z
                );
            }
            // 타겟의 x, y, z 좌표에 카메라의 좌표를 더하여 카메라의 위치를 결정
            transform.position = TargetPos;
        }
    }
}
