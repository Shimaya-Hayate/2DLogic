using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public GameObject flashBlock;
    public GameObject cardController;
    CardController cardCon;

    bool oddNum = false;//奇数：true・偶数：false
    
    void Start()
    {
        cardCon = cardController.GetComponent<CardController>();
    }

    void Update()
    {
        if (oddNum)//前回が奇数の時
        {
            if (cardCon.num % 2 == 0)//偶数なら
            {
                flashBlock.SetActive(false);
                oddNum = false;
            }
        }
        else
        {
            if (cardCon.num % 2 == 1)//奇数なら
            {
                flashBlock.SetActive(true);
                oddNum = true;
            }
        }

        if (cardCon.num == 0)
        {
            flashBlock.SetActive(true);
        }
    }
}
