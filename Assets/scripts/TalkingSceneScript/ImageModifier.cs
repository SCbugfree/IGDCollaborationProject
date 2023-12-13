using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageModifier : MonoBehaviour
{
    [Header("NPC sprite(s)")]

    [SerializeField] private Sprite[] npc_sprites;


    [Header("Dialogue Manager")]

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
        
        if (npcImage != null)
        {
            npcImage.SetNativeSize();
        }
        

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
            // Neutral(deafult) 
            case '%':
                Debug.Log("Portrait1  on Display");
                return npc_sprites[0];

            // Happy
            case '$':
                Debug.Log("Portrait2 on Display");
                return npc_sprites[1];

            // Uspset
            case '¥':
                Debug.Log("Portrait3 on Display");
                return npc_sprites[1];

            //Shy
            case '&':
                Debug.Log("Portrait4 on Display");
                return npc_sprites[1];
            
            default:
                Debug.Log("Portrait1 on Display");
                return npc_sprites[0];
        }
    }
}

