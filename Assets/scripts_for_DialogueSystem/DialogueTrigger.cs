using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attaches to the object and allows a new dialog to be triggered

public class DialogueTrigger : MonoBehaviour
{
 //   public DialogueManager dialogueManager;



    public Dialogue dialogue;

    public GameObject objectToDisplayInCanvas;

   // public GameObject objectToDisplayInCanvas1;
    //public GameObject objectToDisplayInCanvas2;

    public void TriggerDialogue() {

        FindObjectOfType<DialogueManger>().StartDialogue(dialogue);

        objectToDisplayInCanvas.SetActive(false);

      //  objectToDisplayInCanvas1.SetActive(false);
       // objectToDisplayInCanvas2.SetActive(false);
    }



}
