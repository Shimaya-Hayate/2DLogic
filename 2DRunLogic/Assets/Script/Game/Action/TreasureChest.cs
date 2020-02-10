using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public int[] card = new int[100];

    [System.NonSerialized]
    public bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当たり判定に触れた時
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //タグがPlayerなら
        {
            TreasureOpen();
        }

        
    }

    void TreasureOpen()
    {
        Destroy(this.gameObject);//自身を削除
        hit = true;
    }
}
