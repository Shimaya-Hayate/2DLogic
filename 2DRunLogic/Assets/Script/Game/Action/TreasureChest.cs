﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public int move;
    public int move2;
    public int jump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当たり判定に触れた時
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //タグがPlayerなら
        {
            TreasureOpen();
        }

        Debug.Log("TC");
    }

    void TreasureOpen()
    {
        Debug.Log("TO");
    }
}