using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeScript : MonoBehaviour
{
    public AnimationCurve curve;
    public float timeShake = 5f;
    public bool start = false;
    public GameObject dialoguePanel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shaking());
    }

    // Screenshake function
    IEnumerator Shaking()
    {
        Vector3 startPos = dialoguePanel.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < timeShake)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / timeShake);
            dialoguePanel.transform.position = startPos + Random.insideUnitSphere * strength;
            yield return null;
        }

        dialoguePanel.transform.position = startPos;
    }   
}
