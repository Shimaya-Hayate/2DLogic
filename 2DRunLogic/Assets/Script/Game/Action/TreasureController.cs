using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    public GameObject[] treasure;
    [System.NonSerialized]
    public int treasureType = 0;
    [System.NonSerialized]
    public int goodType = 0;
    [System.NonSerialized]
    public Vector3 enemyPosition = new Vector3(0, 0, 0);//Enemyの座標
    public GameObject stage; //親指定（フォルダ指定）

    [System.NonSerialized]
    public GameObject[] treasureClone = new GameObject[5]; //クローンを保存

    TreasureChest[] treasureChest = new TreasureChest[5];
    bool treasureChestCreate = false;

    int j = 0;

    public GameObject cardController;
    CardController cardCon;

    // Start is called before the first frame update
    void Start()
    {
        cardCon = cardController.GetComponent<CardController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (treasureChestCreate)//宝箱が作られたなら
        {
            if (treasureChest[j].hit)//宝箱に触れたら
            {
                //カード追加
                AddCard();

                //宝箱を全部回収したら
                if (goodType == j)
                {
                    treasureChestCreate = false;
                }

                j++;                
            }
        }
    }
    
    public void CreateTreasureChest()
    {
        Vector3 pos = new Vector3(0, 0, 0);

        for (int i = 0; i <= goodType; i++)
        {
            pos.x += i;
            treasureClone[i] = Instantiate(treasure[treasureType], enemyPosition + pos, Quaternion.identity, stage.transform);
            treasureChest[i] = treasureClone[i].GetComponent<TreasureChest>();
            treasureChestCreate = true;
        }
    }

    //カードを追加
    void AddCard()
    {
        for (int i = 0; i < cardCon.cardCountText.Length; i++)
        {
            cardCon.cardCount[i] += treasureChest[j].card[i];//枚数更新
            cardCon.cardCountText[i].text = "x" + cardCon.cardCount[i];//表示
        }
    }
}
