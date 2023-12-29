using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePrint : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text tmp;
    RectTransform rectTransform;
    void Start()
    {
      tmp = gameObject.GetComponent<TMP_Text>();
        rectTransform=gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = Score.getScore().ToString();
        rectTransform.anchoredPosition = new Vector3(284f - (9f * tmp.text.Length), -30f, 0f);
    }
}
