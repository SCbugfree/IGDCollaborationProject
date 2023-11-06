using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    private TMP_Text dialogueText; //Get TMP_Text dialogue as dialogueText here
    private string textContent; //store content that is going to be written
    private float typeTime; //store time of typing each character
    private int charIndex; //track the index of character in a string
    private float timer;
   

    public void TypingText(TMP_Text dialogueText, string textContent, float typeTime)
    {
        this.dialogueText = dialogueText;
        this.textContent = textContent;
        this.typeTime = typeTime;
        charIndex = 0;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueText != null) //if there is a dialogue text object
        {
            timer -= Time.deltaTime;

            if (timer <= 0f) //time to display next character (typing)
            {
                timer += typeTime; //reset timer
                charIndex++;
                dialogueText.text = textContent.Substring(0, charIndex); //extract character of the text

                if (charIndex >= textContent.Length) //if entire string has been displayed
                {
                    dialogueText = null;

                    return;
                }
            }

        }
    }
}
