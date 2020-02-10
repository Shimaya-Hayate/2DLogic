using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //自分の情報を入れる
    public int enemyType = 0;
    public bool redType = false;
    public bool blueType = false;

    public GameObject treasureController;
    TreasureController treasureCon;

    bool hit = false;//当たったらtrueに

    // Start is called before the first frame update
    void Start()
    {
        treasureCon = treasureController.GetComponent<TreasureController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当たり判定に触れた時
    void OnTriggerEnter(Collider other)
    {
        if (hit == false)
        {
            if (other.gameObject.tag == "RedBullet") //赤リンゴが当たる
            {
                if (redType)//自分が赤タイプなら
                {
                    Hit(1);//良い宝
                }
                else
                {
                    Hit(0);//悪い宝
                }
            }

            if (other.gameObject.tag == "BlueBullet") //青リンゴが当たる
            {
                if (blueType)//自分が青タイプなら
                {
                    Hit(1);//良い宝
                }
                else
                {
                    Hit(0);//悪い宝
                }
            }
        }
    }

    void Hit(int n)
    {
        hit = true;
        treasureCon.treasureType = enemyType;
        treasureCon.goodType = n;
        treasureCon.enemyPosition = this.transform.position;
        treasureCon.CreateTreasureChest();
        Destroy(this.gameObject);//自身を削除
    }
}
