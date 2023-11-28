using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerImageMod : MonoBehaviour
{
    [SerializeField] DialogueManagerScript dms; //referencing DialogueManagerScript
    [SerializeField] private Animator playerAnim;
    [SerializeField] private string tagName;
    [SerializeField] private string lastTagName;

    // Start is called before the first frame update
    void Start()
    {
        tagName = "";
        lastTagName = "";
        Debug.Log(this.tag);//tag is Player
    }

    void Update()
    {
        lastTagName = tagName;
        tagName = dms.TagName;
        Debug.Log("tag name is " + tagName);

        // Play enter animation
        if (tagName.Equals("Player")) //if player is now the speaker
        {
            //playerAnim.SetTrigger("InTrigger");
           playerAnim.SetBool("MoveIn",true);
           playerAnim.SetBool("MoveOut", false);
            Debug.Log("Player coming");
        }
        else
        {
            // Play exit animation
            if (lastTagName.Equals("Player")) //if player just finished sentence
            {
                //playerAnim.SetTrigger("OutTrigger");
                playerAnim.SetBool("MoveIn", false);
                playerAnim.SetBool("MoveOut", true);
                Debug.Log("Player going");
            }
            // Make Player out of canvas (camera view)
            else
            {
                playerAnim.SetBool("MoveIn", false);
                playerAnim.SetBool("MoveOut", false);
                Debug.Log("Player nothing");
            }
        }
    }
}

