using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDisplay : MonoBehaviour
{
    public GameObject[] displayObject; //表示させるオブジェクト
    
    bool active = false;

    public void Display(int x)
    {
        if (active)
        {
            displayObject[x].SetActive(false);
            active = false;
        }
        else
        {
            nonDisplay();
            displayObject[x].SetActive(true);
            active = true;           
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
