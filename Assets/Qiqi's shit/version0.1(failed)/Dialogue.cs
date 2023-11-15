using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Whenever we want to start a new dialog, we can pass it to the dialog manager
//This class is used to host all the information we need for a single conversation

[System.Serializable]

public class Dialogue
{

    public string characterName;

    //public string dialogueState;//new
    
    [TextArea(3,10)]//minimum and maximum number of lines used for text


    public string[] sentences;
}
