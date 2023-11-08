using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options_display : MonoBehaviour
{

    public GameObject objectToDisplayInCanvas1;
    public GameObject objectToDisplayInCanvas2;
    // Start is called before the first frame update
   
    // Update is called once per frame
    public void OptionTrigger()
    {
        objectToDisplayInCanvas1.SetActive(false);
        objectToDisplayInCanvas2.SetActive(false);
    }
}
