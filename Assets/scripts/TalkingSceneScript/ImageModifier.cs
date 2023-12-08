using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageModifier : MonoBehaviour
{
    [SerializeField] private Sprite portrait1, portrait2;
    [SerializeField] DialogueManagerScript dms;
    private Image npcImage;
    private string tagCheck; //check if tag of this gameObject matches the speaker tag from DialogueManagerScript
    private char sprMod; //get the sprite modifier extracted from DialogueManagerScript

    void Start()
    {
        npcImage = GetComponent<Image>();
    }

    private void Update()
    {
        /*
        if (npcImage != null)
        {
            npcImage.SetNativeSize();
        }
        */

        sprMod = dms.sprModifier; //testing
        tagCheck = dms.TagName;

        Debug.Log("sprMod is" + sprMod);

        if (npcImage.tag.Equals(tagCheck)) //if the speaker is this npc
        {
            npcImage.sprite = SwitchImage(sprMod);
        }
    }

    //Change the corresponding portrait according to the first char in a line
    public Sprite SwitchImage(char sprMod)
    {

        switch (sprMod)
        {
            case '$':
                Debug.Log("Portrait1 on Display");
                return portrait1;
            //break;

            case '¥':
                Debug.Log("Portrait2 on Display");
                return portrait2;
           // break;

            default:
                Debug.Log("Portrait1 on Display");
                return portrait1;
            //break;
        }
    }
}

