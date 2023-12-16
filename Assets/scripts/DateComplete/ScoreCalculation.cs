using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculation : MonoBehaviour
{
    private GameObject gm;
    private GameManager gms;
    public GameObject rank;
    private Image rankImg;
    private int score;
    public Sprite[] spr_array;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager");
        gms = gm.GetComponent<GameManager>();
        score = gms.MadiScore;
        rankImg = rank.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayRank()
    {
        if (score < 50)
        {
            rankImg.sprite = spr_array[0];
        }
        else if (score > 50 && score < 100)
        {
            rankImg.sprite = spr_array[1];
        }
        else if (score > 100 && score < 150)
        {
            rankImg.sprite = spr_array[2];
        }
        else
        {
            rankImg.sprite = spr_array[3];
        }
    }
}
