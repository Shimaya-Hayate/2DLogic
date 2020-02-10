using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float v = 0.1f; //速度
    float x = 0;
    Vector3 pos;

    //ジャンプ処理用
    public float jampPower = 10;                 //ジャンプ力
    float y;                         //スペースキーon(+1)、off(0)
    public int maxJampCount = 1;
    int jampCount = 0;               //ジャンプの回数

    //画面スクロールモードに変更する座標
    float stayPos = 5f;

    [System.NonSerialized]
    public bool stageMove = false;

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
        //x = 0;

        stageMove = false;

        if (Input.GetKey("d"))
            Move(1);

        if (Input.GetKey("a"))
            Move(-1);

        if ((Input.GetKeyUp("a")) || (Input.GetKeyUp("d")))
            Move(0);

        if (x == 1)
        {
            if (pos.x >= stayPos)
            {
                stageMove = true;
            }
        }

        if (stageMove == false)
        {
            pos.x += x * v * Time.timeScale;
            myTransform.position = pos; //座標の更新
        }
    }

    public void Move(int n)
    {
        x = n;
    }

    public void Jump()
    {
        //ジャンプ処理
        if (Time.timeScale != 0)//停止状態でなく
        {
            if (jampCount < maxJampCount)//ジャンプの回数が上限を超えていないなら
            {
                 y = 1;
                 jampCount += 1;
            }
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(0, y * jampPower * 50, 0); //[-50]は重力
        y = 0;
    }

    
    void OnTriggerEnter(Collider other)
    {
        //地面と触れたらジャンプ回数をリセット
        if (other.gameObject.tag == "Ground") //地面なら
        {
            jampCount = 0;
        }
    }

    
}
