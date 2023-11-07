using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attaches to the object and allows a new dialog to be triggered

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;


    public void TriggerDialogue() {

        FindObjectOfType<DialogueManger>().StartDialogue(dialogue);
    }
}
