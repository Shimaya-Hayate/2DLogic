using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    Image buttonImage;
    public Sprite[] sprite;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = this.GetComponent<Image>();
    }

    public void ImageChange(int imageType)
    {
        buttonImage.sprite = sprite[imageType];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
