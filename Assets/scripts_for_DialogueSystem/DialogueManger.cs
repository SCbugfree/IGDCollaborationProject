using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManger : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    //public Text nameText;
    //public Text dialogueText;

    public float textSpeed;
    //private int index;

    private Queue<string> sentences;// queue for storing dialog sentences




    void Start()
    {
        dialogueText.text = string.Empty;
      
         sentences = new Queue<string>();// initializing the dialogue sentence queue
        //dialogueText.text = " "; 
    }
    public void StartDialogue(Dialogue dialogue)
    {
      // index = 0;
        //Debug.Log("Starting conversation with" + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        //sentence by sentence from the dialog into the queue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) 
        {
            EndDialogue();//if the dialog sentence queue is empty, end the dialog
            return;
        }

        string sentence = sentences.Dequeue();//take the next line of dialog from the queue

        //dialogueText.text = sentence;
        //  Debug.Log(sentence);
        //  StopAllCoroutines(); 
        StartCoroutine(TypeSentence(sentence)); // begin verbatim display of dialogues
    }

    IEnumerator TypeSentence(string sentence)
    {
        

        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter; // add characters to the dialog text one by one
            Debug.Log(dialogueText.text); 
            yield return new WaitForSeconds(textSpeed); // wait for one frame and then continue to display the next character
        }


    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");
    }


}
