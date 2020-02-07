using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPosition = new Vector3(0, 0, 0);//Playerの座標

    public GameObject[] item;
    int itemType = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("l"))
            switch (itemType)
            {
                case 0:
                    Shot(item[0]);
                    break;
                case 1:
                    Shot(item[1]);
                    break;
            }
    }

    //弾を撃つ
    public void Shot(GameObject bullet)
    {
        Debug.Log(bullet);

        //Playerの座標取得
        playerPosition = player.transform.position;

        //弾を生成
        Instantiate(bullet, playerPosition, Quaternion.identity);
    }
}
