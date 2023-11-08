using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] private TextControl textControl;

    private TMP_Text dialogue;
    private int dialogueCounter = 3; //records the iteration of dialogue (in this case 3)
    private string Question1 = "On a Friday Night you are most likely to:";
    private string Question2 = "What are your turn-on's?";
    private string Question3 = "What do you never leave home without?";
  

    void Awake()
    {
        dialogue = GetComponent<TMP_Text>();
    }

    void Start()
    {
        //controlling the text being typed
        textControl.TypingText(dialogue,Question1, 0.2f);
    }

    void Update()
    {
        //if state1, call typing text
        //if state2, call options 
    }
}
