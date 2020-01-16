using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public GameObject flashBlock;
    public GameObject cardController;
    CardController cardCon;
    
    void Start()
    {
        cardCon = cardController.GetComponent<CardController>();
    }

    void Update()
    {
        if (cardCon.num % 2 == 1)
        {
            flashBlock.SetActive(true);
        }
        else
        {
            flashBlock.SetActive(false);
        }

        if(cardCon.num == 0)
        {
            flashBlock.SetActive(true);
        }

    }
}
