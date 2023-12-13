using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameInput : MonoBehaviour
{
    public TMP_InputField _firstName;
    public TMP_InputField _lastName;


    // Start is called before the first frame update
    public void InputFieldFirstName()
    {
        PlayerPrefs.SetString("firstName", _firstName.text);

        GameObject gm = GameObject.FindWithTag("GameManager");
        GameManager gmScript = gm.GetComponent<GameManager>();
        gmScript.firstName = _firstName.text;

    }

    public void InputFieldLastName()
    {
        PlayerPrefs.SetString("lastName", _lastName.text);
    }
}
