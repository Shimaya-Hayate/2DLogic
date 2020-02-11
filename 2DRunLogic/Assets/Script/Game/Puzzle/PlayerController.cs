using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float v = 0.1f; //速度
    [System.NonSerialized]
    public float vX, vZ; //方向
    [System.NonSerialized]
    public float posX, posZ; //Z座標
    [System.NonSerialized]
    public bool stop = true;
    [System.NonSerialized]
    public Vector3 pos;
    Vector3 initialPosition;
    [System.NonSerialized]
    public bool jamp = false;

    [System.NonSerialized]
    public bool reset = false;

    Vector3 rot = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform.position;
        rot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        pos = myTransform.position;

        //静止中なら
        if(stop)
        {
            if(vZ != 0)
            {
                vX = 0;
                stop = false;
                posZ = pos.z; //座標を保存
            }

            if (vX != 0)
            {
                vZ = 0;
                stop = false;
                posX = pos.x; //座標を保存
            }
        }
        //移動中なら
        else
        {
            if (vZ != 0)
            {
                pos.z += vZ * v * Time.timeScale;

                if ((posZ + vZ) * vZ <= pos.z * vZ)
                {
                    pos.z = posZ + vZ;
                    stop = true;
                    vZ = 0;

                    jamp = false;
                }
            }

            if (vX != 0)
            {
                pos.x += vX * v * Time.timeScale;

                if ((posX + vX) * vX <= pos.x * vX)
                {
                    pos.x = posX + vX;
                    stop = true;
                    vX = 0;

                    jamp = false;
                }
            }
        }
        //ジャンプ中なら
        if (jamp)
        {
            pos.y = initialPosition.y + 1f;
        }

        myTransform.position = pos; //座標の更新

        //向きの変更
        if(vZ > 0)
        {
            rot.y = 0;
        }
        else if(vX > 0)
        {
            rot.y = 90;
        }
        else if(vZ < 0)
        {
            rot.y = 180;
        }
        else if(vX < 0)
        {
            rot.y = 270;
        }
        myTransform.eulerAngles = rot; //角度の変更
    }

    public void PlayerReset()
    {
        reset = true;
        stop = true;
        this.transform.position = initialPosition;
        vZ = 0;
        vX = 0;
    }
}
