using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSortingScript : MonoBehaviour
{
    GameObject mummy_instance;

    [SerializeField] GameObject frontPanel;
    [SerializeField] GameObject namePanel;
    [SerializeField] GameObject panel1;

    // Start is called before the first frame update
    void Start()
    {
        CheckOrder();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckOrder();
    }

    void CheckOrder()
    {
        mummy_instance = GameObject.FindWithTag("MummyClone");

        mummy_instance.transform.SetSiblingIndex(2);

        int m_index = mummy_instance.transform.GetSiblingIndex();

        frontPanel.transform.SetSiblingIndex(3);

        namePanel.transform.SetSiblingIndex(4);

        panel1.transform.SetSiblingIndex(1);
    } 
}
