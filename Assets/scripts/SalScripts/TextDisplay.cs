using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] private TextControl textControl;

    private TMP_Text dialogue;

    void Awake()
    {
        dialogue = GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //dialogue.text = "HellooooooooWorlddddddddd";
        textControl.TypingText(dialogue,"Hellooooooooooooooooooooooooooo World", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
