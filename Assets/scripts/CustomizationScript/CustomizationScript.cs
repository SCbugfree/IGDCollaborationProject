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


    [SerializeField] private Image m_body;

    [SerializeField] private Image m_head;

    [SerializeField] private Image m_eyes;

    [SerializeField] private Image m_brows;

    [SerializeField] private Image m_nose;

    [SerializeField] private Image m_hair;

    [SerializeField] private Image m_mouth;

    [SerializeField] private Image m_clothing;



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


    [SerializeField] private Color buttonColor; // store color of selected button

    [SerializeField] private Color chosenColor; // store color that will be applied

    [SerializeField] private GameObject buttonComponent; // store the choice button selected

    [SerializeField] private Image targetMommyComponent;

    [SerializeField] private int buttonIndex; // store the index of the button selected

    [SerializeField] private int sprIndex; // store the index in the sprite array

    [SerializeField] private Sprite[] currentArray; // store the current array from which choices are made

    [SerializeField] private Sprite[] hairTemp; // index of head determines array hairTemp

    [SerializeField] private Sprite[] clothingTemp; // index of body determines array clothingTemp

    [SerializeField] private int cHair_index = 0; // store current sprite index of hair sprite in hair array

    [SerializeField] private int cClothing_index = 0; // store current sprite index of clothing sprite in clothing array

    [SerializeField] GameObject mommyInstance;

    [SerializeField] Image[] mommyComponents;

    public GameManager gmScript;




    void Start()
    {
        FindMommyInstance();
        currentArray = body_sprites;
        targetMommyComponent = m_body;
    }


    void Update()
    {
        MatchSprites();
    }


    // Reference Mummy Instance
    private void FindMommyInstance()
    {
        mommyInstance = GameObject.FindWithTag("MommyClone");
        mommyComponents = mommyInstance.GetComponentsInChildren<Image>();

        if (mommyComponents.Length > 0)
        {
            foreach (Image image in mommyComponents)
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
        mommyComponents = mommyInstance.GetComponentsInChildren<Image>();

        // Fetch the corresponding component in Mummy Instance
        foreach (Image current_image in mommyComponents)
        {
            if (buttonComponent.tag == current_image.tag)
            {
                targetMommyComponent = current_image;
            }
        }

        // Reference the target sprite array by current MummyComponent
        switch (targetMommyComponent.tag)
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

        targetMommyComponent.sprite = currentArray[buttonIndex];

        // Record current hair and clothing index for MatchSprites()
        switch (targetMommyComponent.tag)
        {
            case "hair":
                cHair_index = buttonIndex;
                break;

            case "clothing":
                cClothing_index = buttonIndex;
                break;
        }
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


    // Match sprites automatically
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

                case 4:
                    hairTemp = h5_hair_sprites;
                    break;
            }

            m_hair.sprite = hairTemp[cHair_index];
            Debug.Log("hair sprite is" + m_hair.sprite.name);

        }

        // If body and clothing sprites are shown
        if (m_body.sprite != null && m_clothing.sprite != null)
        {
            int body_index = Array.IndexOf(body_sprites, m_body.sprite);

            switch (body_index)
            {
                case 0:
                    clothingTemp = b1_clothing_sprites;
                    break;

                case 1:
                    clothingTemp = b2_clothing_sprites;
                    break;

                case 2:
                    clothingTemp = b3_clothing_sprites;
                    break;

                case 3:
                    clothingTemp = b4_clothing_sprites;
                    break;
            }

            m_clothing.sprite = clothingTemp[cClothing_index];
            Debug.Log("clothing sprite is" + m_clothing.sprite.name);
        }

        //m_clothing.sprite = clothingTemp[cClothing_index];
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

    // Pass parameters to GameManager to store Mommy Profile choices
    public void SendBuiltMommyInfo()
    {
        Sprite[] MommyInfo = {m_body.sprite, m_head.sprite, m_eyes.sprite, m_nose.sprite,
                              m_brows.sprite, m_mouth.sprite, m_hair.sprite, m_clothing.sprite};


        gmScript.GetComponent<GameManager>().GetPlayerBuiltMommy(MommyInfo);
        gmScript.GetComponent<GameManager>().GetPlayerColor(m_hair.color, m_body.color);
    }
}
