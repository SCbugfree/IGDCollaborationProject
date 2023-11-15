using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attaches to the object and allows a new dialog to be triggered

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogues;//add[],change to dialogues

    //public GameObject objectToDisplayInCanvas;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManger>().StartDialogue(dialogues);
        //objectToDisplayInCanvas.SetActive(false);
    }
    //public void TriggerDialogue//(string state)//add string state
    // {

    //foreach (Dialogue dialogue in dialogues)//new
    //  {
    //  if (dialogue.dialogueState == state)//new
    //  {

    //  FindObjectOfType<DialogueManger>().StartDialogue(dialogue);


    //     objectToDisplayInCanvas.SetActive(false);


    // break;//new

    // }

    //  }


}
