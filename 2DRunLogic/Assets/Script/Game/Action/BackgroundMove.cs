using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    Vector3 pos = new Vector3(40, 0.2f, 2);

    void Update()
    {
        if(transform.position.x < -20)
        {
            this.transform.position = pos;
        }
    }
}
