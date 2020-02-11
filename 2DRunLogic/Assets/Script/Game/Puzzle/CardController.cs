﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public GameObject[] card; //カードのオリジナル
    public Vector3 defoultPosition = new Vector3(450, 1100, 0); //生成場所
    public GameObject mainPanel; //親指定（フォルダ指定）

    [System.NonSerialized]
    public GameObject[] cardClone = new GameObject[100]; //クローンを保存
    int[] type = new int[100]; //ブロックの種類を保存
    int i = 0;
    int j = 0;

    bool full = false; //フルかどうか

    //Run()
    [System.NonSerialized]
    public int num;
    float wateTime = 1.0f;
    bool run = false;

    public GameObject player;
    PlayerController playerCon;

    //カード枚数管理用
    string key = "KEY";
    [System.NonSerialized]
    public int[] cardCount = new int[100];
    public Text[] cardCountText = new Text[100];

    void Start()
    {
        playerCon = player.GetComponent<PlayerController>();
        CardCountRoad();
    }
    
    void CardCountRoad()
    {
        for (int i = 0; i < cardCountText.Length; i++)
        {
            key = "KEY" + i;
            cardCount[i] = PlayerPrefs.GetInt(key, 3);//ロード
            cardCountText[i].text = "x" + cardCount[i];//表示
        }
    }

    //ブロック生成
    public void BlockCreate(int n)
    {
        Vector3 position = defoultPosition;

        //5列3行になるよう配置
        if (i < 5)
        {
            position.x += 70 * i;
        }
        /*else if (i < 10)
        {
            position.x += 70 * (i - 5);
            position.y -= 70;
        }
        else if (i < 15)
        {
            position.x += 70 * (i - 10);
            position.y -= 140;
        }*/
        else
        {
            full = true;
        }

        //フルでなければ生成
        if (full == false)
        {
            if (cardCount[n/4] > 0)
            {
                cardClone[i] = Instantiate(card[n], position, Quaternion.identity, mainPanel.transform);
                type[i] = n; //ブロックの種類を保存
                i++;
                cardCount[n/4]--; //カードの枚数を減らす
                cardCountText[n/4].text = "x" + cardCount[n/4];//表示
            }
        }
    }

    //ブロック削除(新しいやつから)
    public void BlockDelete()
    {
        j = i - 1;

        if (0 <= j)
        {
            Destroy(cardClone[j].gameObject);
            i--;
            full = false;

            cardCount[type[j]/4]++; //カードの枚数を増やす
            cardCountText[type[j]/4].text = "x" + cardCount[type[j]/4];//表示
        }
    }

    //Run()を呼ぶ
    public void RunCall()
    {
        Time.timeScale = 1;

        //実行中でなければ
        if (run == false)
        {
            run = true;

            //リセットされていたら
            if (num == 0)
            {
                Run();
            }
        }
    }

    //プログラム実行
    void Run()
    {
        if (num < i)
        {
            //動作の種類別にパターン分け
            switch (type[num])
            {
                case 0:
                    playerCon.vZ = 1;
                    break;
                case 1:
                    playerCon.vX = 1;
                    break;
                case 2:
                    playerCon.vX = -1;
                    break;
                case 3:
                    playerCon.vZ = -1;
                    break;
                case 4:
                    playerCon.vZ = 2;
                    break;
                case 5:
                    playerCon.vX = 2;
                    break;
                case 6:
                    playerCon.vX = -2;
                    break;
                case 7:
                    playerCon.vZ = -2;
                    break;
                case 8:
                    playerCon.vZ = 1;
                    playerCon.jamp = true;
                    break;
                case 9:
                    playerCon.vX = 1;
                    playerCon.jamp = true;
                    break;
                case 10:
                    playerCon.vX = -1;
                    playerCon.jamp = true;
                    break;
                case 11:
                    playerCon.vZ = -1;
                    playerCon.jamp = true;
                    break;
            }
            if (run)
            {
                Invoke("Run", wateTime); //wateTimeの間隔で動作
                num++;
            }
        }
        //すべての動作が終了したら
        else
        {
            run = false;
        }  
    }

    public void Stop()
    {
        Time.timeScale = 0;
        run = false;
    }

    //リセット
    public void Reset()
    {
        Time.timeScale = 1;
        //実行中でなければ
        if (run == false)
        {
            CancelInvoke(); //Invoke処理を取り消す
            num = 0; //実行順序リセット
            playerCon.PlayerReset(); //座標と速度リセット
        }
        else
        {
            Stop();
            Reset();
        }

    }
}
