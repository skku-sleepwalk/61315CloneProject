using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class shader : MonoBehaviour
{




    private int age;
    private int[] ageTable = { 15, 30, 39 , 16 };
    int index = 0;
    private void Awake()
    {
        age = 15;
        index = 0;
        chapter = 1;
    }
    private void Update()
    {

        if (Score.getScore() > age)
        {
            age += ageTable[index % 4];
            index++;
            chapter++;
            if (chapter > 4) chapter = 1;
            UpdateChapterText();

        }


    }

    public TextMeshProUGUI displayText; // Assign this in the inspector
    public TMP_FontAsset pixelNESFont; // Assign this in the inspector
    public int chapter; // 현재 챕터 번호

    void Start()
    {
        displayText=GetComponent<TextMeshProUGUI>();
        // Set font and initial setup
        displayText.font = pixelNESFont;
        displayText.enableVertexGradient = true; // Enable gradient for outline effect
        displayText.colorGradient = new VertexGradient(Color.black, Color.black, Color.black, Color.black);
        UpdateChapterText();
    }

 

    void UpdateChapterText()
    {
        switch (chapter)
        {
            case 1:
                displayText.text = "Chapter 1";
                break;
            case 2:
                displayText.text = "Chapter 2";
                break;
            case 3:
                displayText.text = "Chapter 3";
                break;
            case 4:
                displayText.text = "Chapter 4";
                break;
            default:
                displayText.text = "";
                break;
        }

        // Set black outline
        displayText.outlineWidth = 0.1f; // Set the outline width as needed
        displayText.outlineColor = Color.black;

        // Enable shadow by modifying material properties
        Material material = displayText.fontMaterial; // Get the material from the font
        material.EnableKeyword("OUTLINE_ON"); // Enable the outline keyword
        material.SetColor("_OutlineColor", Color.black); // Set the outline color
        material.SetFloat("_OutlineWidth", 0.2f); // Set the outline width
    }

}
