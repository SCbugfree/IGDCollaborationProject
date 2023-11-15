using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPanelController : MonoBehaviour
{
    public void ShowOptions()
    {
        gameObject.SetActive(true); 
    }

    public void HideOptions()
    {
        gameObject.SetActive(false); 
    }
}
