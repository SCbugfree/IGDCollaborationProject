using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using System.Reflection;
using System;

public class CustomizationScript : MonoBehaviour
{
    [Header("Mummy Objects")]

    public Image m_body;
    public Image m_head;
    public Image m_eyes;
    public Image m_brows;
    public Image m_nose;
    public Image m_hair;
    public Image m_mouth;
    public Image m_clothing;

    [Header("Sprite Arrays")]

    [SerializeField]
    private Sprite[] body_sprites;

    [SerializeField]
    private Sprite[] head_sprites;

    [SerializeField]
    private Sprite[] eyes_sprites;

    [SerializeField]
    private Sprite[] brows_sprites;

    [SerializeField]
    private Sprite[] nose_sprites;

    [SerializeField]
    private Sprite[] mouth_sprites;

    [SerializeField]
    private Sprite[] h1_hair_sprites;

    [SerializeField]
    private Sprite[] h2_hair_sprites;

    [SerializeField]
    private Sprite[] h3_hair_sprites;

    [SerializeField]
    private Sprite[] h4_hair_sprites;

    [SerializeField]
    private Sprite[] h5_hair_sprites;

    [SerializeField]
    private Sprite[] b1_clothing_sprites;

    [SerializeField]
    private Sprite[] b2_clothing_sprites;

    [SerializeField]
    private Sprite[] b3_clothing_sprites;

    [SerializeField]
    private Sprite[] b4_clothing_sprites;


    [Header("Boards")]

    [SerializeField] private GameObject[] boards;


    [Header("Buttons")]

    [SerializeField] private GameObject colorButton; // store the button clicked to change color
    [SerializeField] private GameObject boardButton; // store the button show or hide a board
    [SerializeField] private GameObject chooseButton; // store the button clicked to change Mummy object components


    [Header("Temp data")]

    public Color buttonColor; // store color of selected button
    public Color chosenColor; // store color that will be applied
    public GameObject buttonComponent; // store the choice button selected
    public Image targetMummyComponent;
    public int buttonIndex; // store the index of the button selected
    public int sprIndex; // store the index in the sprite array
    public Sprite[] currentArray; // store the current array from which choices are made
    public Sprite[] hairTemp;
    public Sprite[] clothingTemp;

    [SerializeField] GameObject mummyInstance;
    [SerializeField] Image[] mummyComponents;

    public GameManager gmScript;


    void Start()
    {
        FindMummyInstance();
    }


    void Update()
    {
        MatchSprites();
    }


    // Reference Mummy Instance
    private void FindMummyInstance()
    {
        mummyInstance = GameObject.FindWithTag("MummyClone");
        mummyComponents = mummyInstance.GetComponentsInChildren<Image>();

        if (mummyComponents.Length > 0)
        {
            foreach (Image image in mummyComponents)
            {
                switch (image.tag)
                {
                    case "body":
                        m_body = image;
                        break;

                    case "head":
                        m_head = image;
                        break;

                    case "eyes":
                        m_eyes = image;
                        break;

                    case "brows":
                        m_brows = image;
                        break;

                    case "nose":
                        m_nose = image;
                        break;

                    case "mouth":
                        m_mouth = image;
                        break;

                    case "hair":
                        m_hair = image;
                        break;

                    case "clothing":
                        m_clothing = image;
                        break;
                }
            }
        }
    }


    // Change Mummy object sprites reference: public for button access
    public void ChangeSprites()
    {
        buttonComponent = EventSystem.current.currentSelectedGameObject;
        mummyComponents = mummyInstance.GetComponentsInChildren<Image>();

        // Fetch the corresponding component in Mummy Instance
        foreach (Image current_image in mummyComponents)
        {
            if (buttonComponent.tag == current_image.tag)
            {
                targetMummyComponent = current_image;
            }
        }

        // Reference the target sprite array by current MummyComponent
        switch (targetMummyComponent.tag)
        {
            case "body":
                currentArray = body_sprites;
                break;

            case "head":
                currentArray = head_sprites;
                break;

            case "eyes":
                currentArray = eyes_sprites;
                break;

            case "brows":
                currentArray = brows_sprites;
                break;

            case "nose":
                currentArray = nose_sprites;
                break;

            case "mouth":
                currentArray = mouth_sprites;
                break;

            case "hair":
                currentArray = hairTemp;
                break;

            case "clothing":
                currentArray = clothingTemp;
                break;
        }
    }


    // Transfer index to change Mummy Object sprites: public for button access
    public void PassIndex(int sprIndex)
    {
        buttonIndex = sprIndex;

        targetMummyComponent.sprite = currentArray[buttonIndex];
    }


    // Change hair color: public for button access
    public void HairColorPicker()
    {
        colorButton = EventSystem.current.currentSelectedGameObject;
        buttonColor = colorButton.GetComponent<Image>().color;
        chosenColor = buttonColor;
        m_hair.color = chosenColor;
        m_brows.color = chosenColor;
    }


    // Change skin color: public for button access
    public void SkinColorPicker()
    {
        colorButton = EventSystem.current.currentSelectedGameObject;
        buttonColor = colorButton.GetComponent<Image>().color;
        chosenColor = buttonColor;
        m_head.color = chosenColor;
        m_body.color = chosenColor;
    }


    // Match sprites
    public void MatchSprites()
    {
        // If head and hair sprites are shown
        if (m_head.sprite != null && m_hair.sprite != null)
        {
            int head_index = Array.IndexOf(head_sprites, m_head.sprite);

            //string arrayName = "h" + (index + 1) + "_hair_sprites";
            //hairTemp = FindArrayByName(arrayName);

            switch (head_index)
            {
                case 0:
                    hairTemp = h1_hair_sprites;
                    break;

                case 1:
                    hairTemp = h2_hair_sprites;
                    break;

                case 2:
                    hairTemp = h3_hair_sprites;
                    break;

                case 3:
                    hairTemp = h4_hair_sprites;
                    break;
            }


            //m_hair.sprite = hairTemp;

        }

        // If body and clothing sprites are shown
        if (m_body.sprite != null && m_clothing.sprite != null)
        {
            int index = Array.IndexOf(body_sprites, m_body.sprite);
            string arrayName = "b" + (index + 1) + "_clothing_sprites";
            clothingTemp = FindArrayByName(arrayName);
        }
    }


    // Find array using arrayName passed down
    public Sprite[] FindArrayByName(string arrayName)
    {
        // Traverse all the arrays
        Type type = GetType();
        FieldInfo[] fields = type.GetFields();
        Sprite[] tempArray = null;

        foreach (FieldInfo field in fields)
        {
            // Check if the field is an array
            if (field.FieldType.IsArray && field.FieldType.GetElementType() == typeof(Sprite))
            {
                Sprite[] spriteArray = (Sprite[])field.GetValue(this);

                // Find array by name
                if (nameof(spriteArray) == arrayName)
                {
                    spriteArray = tempArray;
                }
                else
                {
                    tempArray = null;
                }
            }
            else
            {
                tempArray = null;
            }
        }
        return tempArray;
    }

    // Pass parameters to GameManager to store Mummy Profile choices
    public void SendBuiltMummyInfo()
    {
        Sprite[] MummyInfo = {m_body.sprite, m_head.sprite, m_eyes.sprite, m_nose.sprite,
                              m_brows.sprite, m_mouth.sprite, m_hair.sprite, m_clothing.sprite};


        gmScript.GetComponent<GameManager>().GetPlayerBuiltMummy(MummyInfo);
        gmScript.GetComponent<GameManager>().GetPlayerColor(m_hair.color, m_body.color);
    }
}
