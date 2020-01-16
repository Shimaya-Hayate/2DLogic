using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float v = 0.1f; //速度
    float x;
    Vector3 pos;

    //ジャンプ処理用
    public float jampPower = 10;                 //ジャンプ力
    float y;                         //スペースキーon(+1)、off(0)
    float currentDropSpeed = 0;      //現在の落下速度
    public int maxJampCount = 1;
    int jampCount = 0;               //ジャンプの回数

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        pos = myTransform.position;

        //移動処理
        x = 0;

        if (Input.GetKey("d"))
            x = 1;

        if (Input.GetKey("a"))
            x = -1;

        pos.x += x * v * Time.timeScale;

        //ジャンプ処理
        if (Time.timeScale != 0)//停止状態でなく
        {
            if (jampCount < maxJampCount)//ジャンプの回数が上限を超えていないなら
            {
                if (Input.GetKeyDown(KeyCode.Space))// スペースキーが押されたら
                {
                    y = 1;
                    jampCount += 1;
                }
            }
        }

        myTransform.position = pos; //座標の更新
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(0, y * jampPower * 50, 0); //[-50]は重力
        y = 0;
    }

    //地面と触れたらジャンプ回数をリセット
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground") //地面なら
        {
            Debug.Log("a");
            jampCount = 0;
        }
    }
}
