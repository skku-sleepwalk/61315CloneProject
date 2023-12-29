using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OverScore : MonoBehaviour
{
    // Start is called before the first frame update
 TextMeshProUGUI displayText;

    private void Start()
    {
          displayText= GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        displayText.text = Score.getScore().ToString();
        GetComponent<RectTransform>().anchoredPosition = new Vector3(104-(13* Score.getScore().ToString().Length),197,0);
    }
}
