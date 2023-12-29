using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorChanger : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer myImage;
    public Sprite blue;

    public Sprite pink;
    public Sprite yellow;
    private Sprite usingImage;
    public static int imageNum=0;
    public static void imageNumChanger(int N)
    {
        imageNum= N;
    }
    void Awake()
    {
        
        myImage = GetComponent<SpriteRenderer>();
        if(imageNum==0)
        usingImage = blue;
        if (imageNum == 1)
            usingImage = pink;
        if (imageNum == 2)
            usingImage = yellow;
        else usingImage = blue;
        myImage.sprite = usingImage;
    }
    public void ColorChangeBlue()
    {
        if (blue != null)
        {
usingImage = blue;
        myImage.sprite = usingImage;
        }
        
    }
    public void ColorChangePink()
    {
        if (blue != null)
        {
            usingImage = pink;
            myImage.sprite = usingImage;
        }
    }
    public void ColorChangeYellow()
        {
        if (blue != null)
        {
            usingImage = yellow;
            myImage.sprite = usingImage;
        }
    }
    // Update is called once per frame
  
}
