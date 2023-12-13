using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManagerScript : MonoBehaviour
{

    private DialogueManagerScript instance;

    [Header("Dialogue and Name Panels")]

    [SerializeField] private Image textPanel; // to later change the sprite of the panel
    [SerializeField] private GameObject namePanel; // the panel which displays the speaker name
    [SerializeField] private Sprite spr_Panel1;
    [SerializeField] private Sprite spr_Panel2;
    [SerializeField] private Sprite spr_Panel3;
    [SerializeField] private Sprite spr_ChoicePanel;
    //[SerializeField] private Sprite spr_namePanel1;
    //[SerializeField] private Sprite spr_namePanel2;
    //[SerializeField] private Sprite spr_namePanel3;
    [SerializeField] private GameObject arrow;


    [Header("Texts")]

    [SerializeField] private TextMeshProUGUI dialogueText; // visually display dialogue text
    [SerializeField] private TextMeshProUGUI speakerName; // visually display speaker name


    [Header("NPC and Player Images")]

    [SerializeField] private Image image_NPC1;
    //[SerializeField] private Image image_NPC2;
    [SerializeField] private Image image_Player; //get player


    [Header("Choices")]

    [SerializeField] private GameObject[] choiceArray;


    [Header("Panel Text length Indicator")]

    public float textL1 = 75;
    public float textL2 = 120;

    //[Header("Name Text Length Indicator")]

    //public float nameL1 = 6;
    //public float nameL2 = 10;


    public TextAsset INKJSON;

    public string TagName; // record the content of the tag

    public bool dialogueIsPlaying { get; private set; }

    public char sprModifier;


    private Story story;

    private TextMeshProUGUI[] choicesTexts;

    private Coroutine displayLineCoroutine; //?

    private GameObject speaker; // Track who is speaking

    private string line;

    private float typingSpeed = 0.02f;

    private float textLength;

    private Animator npcAnim;

    private bool NextSceneGo = false;

    //private float nameLength;

   
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 dialogue manager in this scene");
        }
        instance = this;

    }

    void Start()
    {
        
        dialogueIsPlaying = false;

        // set up chociesText as an array for TextMeshProUGUI that will contain all chocies
        choicesTexts = new TextMeshProUGUI[choiceArray.Length];
        int index = 0;

        // Initializing choice buttons
        foreach (GameObject choice in choiceArray) //choices can be changed in inspector
        {
            choicesTexts[index] = choice.GetComponentInChildren<TextMeshProUGUI>(); //assign texts to array chociesTexts
            index++;
        }

        BeginDialogue(INKJSON);
    }


    void Update()
    {
        if (story.canContinue)// check if we are in dialogue mode and move through story if we are in a dialogue mode
        {
            CheckInput();
            ArrowAnim(dialogueIsPlaying);
        }
        else
        {
            NextSceneGo = true;
            CheckInput();
        }
    }

    // Check Input
    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !dialogueIsPlaying) // only progress dialogue when dialogue is not playing
        {
            ProgressDialogue();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && NextSceneGo)
        {
           //Debug.Log("???");
           //AllSceneManager.LoadNewScene("2GothicGlam");
        }
        else
        {
            // disable input when dialogue is playing
        }
    }


    //  Dialogue

    // Begin dialogue and import JSON file
    private void BeginDialogue(TextAsset INKJSON)
    {
        story = new Story(INKJSON.text);
        ProgressDialogue();
    }

    // Load the JSON file into dialogues and check if the story can continue
    private void ProgressDialogue()
    {
        if (story.canContinue) // if not the end of text file
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine); // stop the displayLineCorroutine
            }

            line = story.Continue();

            displayLineCoroutine = StartCoroutine(DisplayText(line));

            //Debug.Log("Progress"+line.Substring(1)); // printing text in console

            HandleTags(story.currentTags);
        }
        else
        {
            Debug.Log("no story can coninue");
            AllSceneManager.LoadNewScene("2GothicGlam");
        }
    }


    // Display text and a text-typing effect
    private IEnumerator DisplayText(string line)
    {

        namePanel.SetActive(true);

        dialogueText.text = ""; // empty dialogue text

        dialogueIsPlaying = true; // stop receiving inputs when typing texts


        if (story.currentChoices.Count > 0) // if current choices not equal to null
        {
            DisplayChoices();
        }
        else // if there are no avaliable choices
        {
            textLength = line.Substring(1).Length;

            Debug.Log("text length is" + textLength);

            //Debug.Log("Display "+line.Substring(1)); // printing text in console

            SwitchPanel(textLength);

            HideChoices();

            this.line = "";
            this.line = line;

            foreach (char letter in line.Substring(1).ToCharArray()) // Typing out texts 1 char at typingSpeed
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

            sprModifier = char.Parse(line.Substring(0, 1)); // Get the first char of the line 

            dialogueIsPlaying = false;
        }

    }


    //  Panel

    // Switch panel sprites according to length of text chunk
    private void SwitchPanel(float textLength)
    {
        if (textLength < textL1)
        {
            textPanel.sprite = spr_Panel1;
        }
        else if ((textLength > textL1) && (textLength < textL2))
        {
            textPanel.sprite = spr_Panel2;
        }
        else
        {
            textPanel.sprite = spr_Panel3;
        }

        textPanel.SetNativeSize();
    }


    // Tags

    // Find speaker tag and the corresponding speaker GameObject
    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        { 
            TagName = tag;

            // Get speaker name
            if (TagName == "MommyClone") // if speaker is player
            {
                speaker = GameObject.FindWithTag("GameManager");

                GameManager gm_script = speaker.GetComponent<GameManager>();
                speakerName.text = gm_script.firstName;

                namePanel.SetActive(true);

                Debug.Log("first name is" + speakerName.text);

                //speakerName.text = PlayerPrefs.GetString("firstName");
                //Debug.Log("Player name is" + PlayerPrefs.GetString("firstName"));
            }
            else if (TagName == "Narrator") 
            {
                namePanel.SetActive(false); // Disable name panel when narrator is speaking
            }
            else 
            {
                speaker = GameObject.FindWithTag(tag); // speaker is NPC (tag and name are same string)
                namePanel.SetActive(true);
                speakerName.text = speaker.name;
                npcAnim = speaker.GetComponent<Animator>();

                Invoke("TalkStretchAnim", 0.01f);
            }
        }
    }


    // Choices

    // Display choices and hide texts
    private void DisplayChoices()
    {
        namePanel.SetActive(false);

        dialogueText.text = ""; //disable dialogue text

        textPanel.sprite = spr_ChoicePanel;
        textPanel.SetNativeSize();

        List<Choice> currentChoices = story.currentChoices; // currentChoices property is a list of <Choice>

        int index = 0;

        foreach (Choice choice in currentChoices) // enable and initialize the choices up to the amount of choices for this line of dialogue
        {
            choiceArray[index].gameObject.SetActive(true);
            choicesTexts[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choiceArray.Length; i++) // go through the remaining choices the UI supports + make sure they are hidden
        {
            choiceArray[i].gameObject.SetActive(false);
        }
    }


    // Hide choices and enable texts
    private void HideChoices()
    {
        foreach (GameObject choice in choiceArray)
        {
            choice.SetActive(false);
        }
    }

    // Directly triggered by clicking Choice buttons
    public void MakeChoice(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        ProgressDialogue(); // redirecting to ProgressDialogue after clicking
    }



    // Animations

    // Arrow Setter
    public void ArrowAnim(bool dialogueIsPlaying)
    {
        this.dialogueIsPlaying = dialogueIsPlaying;
        arrow.SetActive(!dialogueIsPlaying);
    }

    // Animation of Talking
    private void TalkStretchAnim()
    {
        npcAnim.SetTrigger("Talk");
    }

    /*
  private void SetMommyPortrait()
  {
      portraitImage.enabled = true; //Enabled Behaviours are Updated, disabled Behaviours are not
      portraitImage.sprite = portrait;
  }
*/


}

