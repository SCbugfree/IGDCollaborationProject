using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
//using UnityEngine.Windows;

public class Dialoguemanager2 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.1f;

    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private GameObject continueicon;

    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI diaplayNameText;

    [SerializeField] private Animator portraitAnimator;
    [SerializeField] private Animator npcportraitAnimator;

    [Header("Choices UI")]

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;


    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private bool canContinueToNextLine = false;

    private Coroutine displayLineCoroutine;

    private static Dialoguemanager2 instance;

    private const string SPEAKER_TAG = "speaker";

    private const string PORTRAIT_TAG = "portrait";

    //private const string LAYOUT_TAG = "layout";

    //Added by Sally
    //Temporary
    [SerializeField]
    private GameObject buttonTemp;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manger in the scene");
        }

        instance = this;
    }

    public static Dialoguemanager2 GetInstance()
    {
        return instance;

    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //get all of the choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        //return right away if dialogue isn't playing
        if (!dialogueIsPlaying)
        {
            return;
        }

        //handle continuing to the next line in the dialogue when pressed space key

        if (canContinueToNextLine
            &&currentStory.currentChoices.Count == 0
            &&Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        //Added by Sally
        //Temporary
        ShowTempButton(dialogueIsPlaying);
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)

        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }

            //set text for the current dialogue line
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
           // dialogueText.text = currentStory.Continue();
            //display choices, if any, for this dialogue
           // DisplayChoices();

            //handle tags;
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        //empty the dialogue text
        dialogueText.text = "";
        //hide items while text is typing
        continueicon.SetActive(false);
        HideChoices();

        canContinueToNextLine = false;

        // display each letter one at a time
        foreach (char letter in line.ToCharArray())
        {
            //if the submit button is pressed, finish up diaplaying the line right away

            if (Input.GetMouseButtonDown(0))
            //if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Mouse Left Clicked!");
                dialogueText.text = line;
                break;
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueicon.SetActive(true);
        DisplayChoices();

        canContinueToNextLine = true;
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        //loop through each tag and handle it accordingly
        foreach (string tag in currentTags)
        {     //parse the tag
            string[] splitTag = tag.Split(':');
        if (splitTag.Length != 2)
        {
            Debug.LogError("Tag could not be appropriately parsed:" + tag);
        }
        
        string tagKey = splitTag[0].Trim();
        string tagValue = splitTag[1].Trim();

            //handle the tag

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    diaplayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    Debug.Log("Playing animation: " + tagValue);
                    portraitAnimator.Play(tagValue);
                    npcportraitAnimator.Play(tagValue);
                    break;
                //case LAYOUT_TAG:
                //    break;

                default:
                    Debug.LogWarning("Tag came in but us not currently being handled:" + tag);
                    break;

            }
        }

    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        //defensive check to make sure our UI can support the number of choices coming in 
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the Ui can Support. Number of choices given:"
                + currentChoices.Count);
        }

        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue

        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        //go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }
 
    private IEnumerator SelectFirstChoice()
    {
        //event system requires we clear it first, then wait for at least one
        //frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0]);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {

            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
    }

    //Added by Sally
    //Temporary usage
    private void ShowTempButton(bool dialogueIsPlaying)
    {
        buttonTemp.SetActive(!dialogueIsPlaying);
    }

}
