using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameInput : MonoBehaviour
{
    public GameObject canvas;
    public TMP_Text firstNameInputText;
    public TMP_Text lastNameInputText;
    public string firstName;
    public string lastName;

    // Start is called before the first frame update
    void Start()
    {
        firstNameInputText = canvas.transform.Find("FirstName").GetComponent<TMP_Text>();
        lastNameInputText = canvas.transform.Find("LastName").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    public void InputName()
    {
        firstName = firstNameInputText.text;
        lastName = lastNameInputText.text;
    }
}
