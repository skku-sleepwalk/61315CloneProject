using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class alpha : MonoBehaviour
{
    
    void Start()
    {
        // StartCoroutine 함수를 사용하여 코루틴을 시작합니다.
        Image imageComponent = gameObject.GetComponent<Image>();
        if (imageComponent != null)
        {
            StartCoroutine(RunEverySecond(imageComponent));
        }
    }

    IEnumerator RunEverySecond(Image imageComponent)
    {
        while (true) // 무한 루프로 계속 실행
        {
            imageComponent.color=new Color(1f, 1f, 1f,1f);

            // 1초 대기
            yield return new WaitForSeconds(0.5f);
            imageComponent.color = new Color(1f, 1f, 1f,0f);
            yield return new WaitForSeconds(0.5f);

        }
    }
}
