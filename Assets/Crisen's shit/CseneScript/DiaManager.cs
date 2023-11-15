using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DiaManager : MonoBehaviour
{

    [SerializeField]
    private TMP_Text dialogues;

    private static bool inDialogues = false;

    private Linesmanage speaking;


    // Update is called once per frame
    void Update()
    {
        if (inDialogues)
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        if (Input.GetMouseButton(0))
        {
            ProgressDialogues();
        }

    }

    private void ProgressDialogues()
    {
        dialogues.text = speaking.UpdateDialogues();
    }
}
