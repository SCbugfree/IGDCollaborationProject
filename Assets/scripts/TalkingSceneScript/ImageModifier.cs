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


    [Header("NPC")]

    [SerializeField] private Image npcImage;
    [SerializeField] private Color npc_color;
    [SerializeField] private GameObject gm;
    [SerializeField] private GameManager gmScript;

    [Header("Choices record")]

    [SerializeField] public bool Mscore_added = false;
    [SerializeField] public bool Jscore_added = false;

    private string tagCheck; //check if tag of this gameObject matches the speaker tag from DialogueManagerScript
    private char sprMod; //get the sprite modifier extracted from DialogueManagerScript

    void Start()
    {
        npcImage = GetComponent<Image>();
        npcImage.enabled = false;
    }

    private void Update()
    {
        
        if (npcImage != null)
        {
            npcImage.SetNativeSize();
        }

        gm = GameObject.FindWithTag("GameManager");
        gmScript = gm.GetComponent<GameManager>();


        sprMod = dms.sprModifier;
        tagCheck = dms.TagName;

        Debug.Log("sprMod is" + sprMod);

        if (npcImage.tag.Equals(tagCheck)) // if the speaker is this npc
        {
            npcImage.enabled = true;
            Mscore_added = false;
            Jscore_added = false;
            npcImage.sprite = SwitchImage(sprMod);
        }
    }

    // Change the corresponding portrait according to the first char in a line
    public Sprite SwitchImage(char sprMod)
    {
        if (gm != null)
        {
            switch (sprMod)
            {
                // Neutral(deafult) 
                case '%':
                    return npc_sprites[0];

                // Happy
                case '$':
                    if (tagCheck == "Madi" && !Mscore_added)
                    {
                        gmScript.RecordMadiChoice(10);
                        Mscore_added = true;
                    }
                    else if (tagCheck == "Jade" && !Jscore_added)
                    {
                        gmScript.RecordJadeChoice(10);
                        Jscore_added = true;
                    }
                    else
                    {

                    }
                    return npc_sprites[1];

                // Uspset
                case '¥':
                    if (tagCheck == "Madi" && !Mscore_added)
                    {
                        gmScript.RecordMadiChoice(10);
                        Mscore_added = true;
                    }
                    else if (tagCheck == "Jade" && !Jscore_added)
                    {
                        gmScript.RecordJadeChoice(10);
                        Jscore_added = true;
                    }
                    else
                    {

                    }
                    return npc_sprites[2];

                //Shy
                case '&':
                    return npc_sprites[3];

                // No sprite
                default:
                    return npc_sprites[0];
            }
        }
        else
        {
            return null;
        }
    }

}

