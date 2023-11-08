using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManger : MonoBehaviour
{
    //public GameObject optionsPanel;
    public GameObject optionsPanel; 

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    //public Text nameText;
    //public Text dialogueText;

    public float textSpeed;
    //private int index;


    public Animator animator;

    private Queue<string> sentences;// queue for storing dialog sentences


   // private Dictionary<GameObject, bool> initialObjectStates = new Dictionary<GameObject, bool>();


    void Start()
    {


        optionsPanel.GetComponent<OptionsPanelController>().HideOptions(); 


        dialogueText.text = string.Empty;
      
        sentences = new Queue<string>();// initializing the dialogue sentence queue
        //dialogueText.text = " "; 
    }

    

    public void StartDialogue(Dialogue dialogue)
    {
        


        animator.SetBool("IsOpen",true);
      // index = 0;
        //Debug.Log("Starting conversation with" + dialogue.name);

        nameText.text = dialogue.characterName;

        sentences.Clear();

        //sentence by sentence from the dialog into the queue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

       // Debug.Log("there.");
        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) 
        {
          //  ShowOptions();

           // Debug.Log("here.");
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
         //   Debug.Log(dialogueText.text); 
            yield return new WaitForSeconds(textSpeed); // wait for one frame and then continue to display the next character
        }

    }



    void EndDialogue()
    {
        optionsPanel.GetComponent<OptionsPanelController>().ShowOptions(); // 显示选项


        Debug.Log("End of conversation.");
        animator.SetBool("IsOpen", false);
    }


}
