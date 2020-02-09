using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPosition = new Vector3(0, 0, 0);//Playerの座標

    public GameObject[] item;
    [System.NonSerialized]
    public int itemType = 0;

    //アイテム個数管理用
    string key = "Item";
    int[] itemCount = new int[100];
    public Text[] itemCountText = new Text[100];

    void Start()
    {
        ItemCountRoad();
    }

    void ItemCountRoad()
    {
        for (int i = 0; i < itemCountText.Length; i++)
        {
            key = key + i;
            itemCount[i] = PlayerPrefs.GetInt(key, 3);//ロード
            itemCountText[i].text = "x" + itemCount[i];//表示
        }
    }

    void Update()
    {
       // if (Input.GetKeyDown("l"))
            
    }

    public void ChangeItem(int n)
    {
        itemType = n;
    }

    public void UseItem()
    {
        switch (itemType)
        {
            case 0:
                Shot(0);
                break;
            case 1:
                Shot(1);
                break;
        }
    }

    //弾を撃つ
    void Shot(int type)
    {
        if (itemCount[type] > 0)//アイテム個数があれば
        {
            //Playerの座標取得
            playerPosition = player.transform.position;

            //弾を生成
            Instantiate(item[type], playerPosition, Quaternion.identity);

            itemCount[type]--; //カードの枚数を減らす
            itemCountText[type].text = "x" + itemCount[type];//表示
        }
    }
}
