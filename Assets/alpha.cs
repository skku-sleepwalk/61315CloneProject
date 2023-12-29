using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class alpha : MonoBehaviour
{
    
    void Start()
    {
        // StartCoroutine �Լ��� ����Ͽ� �ڷ�ƾ�� �����մϴ�.
        Image imageComponent = gameObject.GetComponent<Image>();
        if (imageComponent != null)
        {
            StartCoroutine(RunEverySecond(imageComponent));
        }
    }

    IEnumerator RunEverySecond(Image imageComponent)
    {
        while (true) // ���� ������ ��� ����
        {
            imageComponent.color=new Color(1f, 1f, 1f,1f);

            // 1�� ���
            yield return new WaitForSeconds(0.5f);
            imageComponent.color = new Color(1f, 1f, 1f,0f);
            yield return new WaitForSeconds(0.5f);

        }
    }
}
