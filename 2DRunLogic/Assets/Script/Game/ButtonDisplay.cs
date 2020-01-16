using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDisplay : MonoBehaviour
{
    public GameObject[] displayObject; //表示させるオブジェクト

    public void Display(int x)
    {
        if (displayObject[x].activeSelf)//アクティブなら
        {
            displayObject[x].SetActive(false);
        }
        else
        {
            nonDisplay();
            displayObject[x].SetActive(true);           
        }
    }

    //すべて非表示
    void nonDisplay()
    {
        for (int i = 0; i < displayObject.Length; i++)
        {
            displayObject[i].SetActive(false);
        }
    }
}
