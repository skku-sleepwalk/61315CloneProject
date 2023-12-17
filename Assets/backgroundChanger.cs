using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundChanger : MonoBehaviour
{
    // Start is called before the first frame update
    Image myImage;
    public Sprite blue;

    public Sprite pink;
    void Start()
    {
        myImage= GetComponent<Image>();
        myImage.sprite = blue;
    }

    // Update is called once per frame
    void Update()
    {

        if (Score.getScore() % 300 >= 99)
        {
            myImage.sprite = pink;
        }
        
    }
}
