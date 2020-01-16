using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChanger : MonoBehaviour
{
    public GameObject anotherButton;

    public void ButtonChange()
    {
        this.gameObject.SetActive(false);
        anotherButton.SetActive(true);
    }
}
