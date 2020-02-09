using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMove : MonoBehaviour
{
    public GameObject playerAction;
    PlayerAction pA;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pA = playerAction.GetComponent<PlayerAction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pA.stageMove)
        {
            Transform myTransform = this.transform;
            pos = myTransform.position;

            pos.x += -pA.v * Time.timeScale;

            myTransform.position = pos; //座標の更新
        }
    }
}
