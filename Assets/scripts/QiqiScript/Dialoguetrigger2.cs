using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialoguetrigger2 : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField]
    private TextAsset InkJSON;

    private void Update()
    {
        if (!Dialoguemanager2.GetInstance().dialogueIsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Dialoguemanager2.GetInstance().EnterDialogueMode(InkJSON);
            }
        }
    }
}
