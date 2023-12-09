using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class collisionBreak : MonoBehaviour
{
    public GameObject targetObject;
    // 알파값을 설정하는 함수
    void SetObjectAlpha(GameObject obj, float alphaValue)
    {
        // Renderer 컴포넌트가 있는 경우에만 알파값을 설정
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            Color currentColor = renderer.material.color;
            currentColor.a = alphaValue;
            renderer.material.color = currentColor;
        }
    }

    // Box Collider를 비활성화하는 함수
    void DisableBoxCollider(GameObject obj)
    {
        // Collider 컴포넌트가 있는 경우에만 비활성화
        BoxCollider2D collider = obj.GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(0))   //마우스 좌측 버튼을 누름.
        {
           
            if (collision.gameObject.CompareTag("Main delete"))
            {
                if (BreakCoolTime.getCoolTime())
                {
                    if (targetObject == null)
                    {
                        targetObject = gameObject;
                    }
                    // 알파값을 0으로 설정
                    SetObjectAlpha(targetObject, 0f);

                    // Box Collider를 비활성화
                    DisableBoxCollider(targetObject);
                    Timer timer = new Timer(BreakCoolTime.setCoolTime, null, 100, Timeout.Infinite);
                }
            }
        }
    }

}
