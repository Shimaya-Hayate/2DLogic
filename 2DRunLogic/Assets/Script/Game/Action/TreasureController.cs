﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    public GameObject[] treasure;
    public int treasureType;
    public int goodType;
    public Vector3 enemyPosition = new Vector3(0, 0, 0);//Enemyの座標

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateTreasureChest()
    {
        Vector3 pos = new Vector3(0, 0, 0);

        for (int i = 0; i <= goodType; i++)
        {
            Instantiate(treasure[treasureType], enemyPosition + pos, Quaternion.identity);
        }
    }
}
