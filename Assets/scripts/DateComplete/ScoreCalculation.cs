using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculation : MonoBehaviour
{
    private GameObject gm;
    private GameManager gms;
    private Image rankImg;
    private Image rankImg_1;
    private Image rankImg_2;
    private int score;

    [Header("Ranking sprites")]
    [SerializeField] private Sprite[] spr_array;
    [SerializeField] private Sprite[] spr_array1;
    [SerializeField] private Sprite[] spr_array2;


    [Header("Ranking Objects")]
    public GameObject rank_1;
    public GameObject rank_2;
    public GameObject rank;



    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager");
        gms = gm.GetComponent<GameManager>();
        score = gms.MadiScore;
        rankImg = rank.GetComponent<Image>();
        rankImg_1 = rank_1.GetComponent<Image>();
        rankImg_2 = rank_2.GetComponent<Image>();

    }

    public void DisplayRank()
    {
        // C rank
        if (score < 50)
        {
            rankImg_1.sprite = spr_array1[0];
            rankImg_2.sprite = spr_array2[0];
            rankImg.sprite = spr_array[0]; 
        }
        // B rank
        else if (score > 50 && score < 100)
        {
            rankImg_1.sprite = spr_array1[1];
            rankImg_2.sprite = spr_array2[1];
            rankImg.sprite = spr_array[1]; 
        }
        // A rank
        else if (score > 100 && score < 150)
        {
            rankImg_1.sprite = spr_array1[2];
            rankImg_2.sprite = spr_array2[2];
            rankImg.sprite = spr_array[2];
        }
        // S rank
        else
        {
            rankImg_1.sprite = spr_array1[3];
            rankImg_2.sprite = spr_array2[3];
            rankImg.sprite = spr_array[3]; 
        }
    }
}
