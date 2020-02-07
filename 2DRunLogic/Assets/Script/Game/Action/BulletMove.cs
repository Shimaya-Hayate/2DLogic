using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    //ScoreCount scoreCount;

    void Start()
    {
        //ScoreCountのスクリプト取得
        //scoreCount = GameObject.Find("ScoreCounter").GetComponent<ScoreCount>();
    }

    void Update()
    {
        //移動
        this.transform.Translate(0.5f, 0, 0);
    }

    //当たり判定に触れた時
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target") //タグがTargetなら
        {
            Destroy(other.gameObject);//Targetを削除
            //scoreCount.score += 1;
        }

        if(other.gameObject.tag == "Enemy") //タグがEnemyなら
        {
            Destroy(other.gameObject);//Enemyを削除
            //scoreCount.score += 5;
        }

        if (other.gameObject.tag != "Player")//Player以外なら
        {
            Destroy(this.gameObject);//自身を削除
        }
        Debug.Log("AAA");
    }
}
