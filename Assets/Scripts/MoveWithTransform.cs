using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithTransform : MonoBehaviour
{
    public float speed = 5f;
    //C# is case sensitive
    void Update()
    {
        //Transform transExample;
        transform.position += Vector3.up * speed * Time.deltaTime;

        int x = 3;
        x = x + 1;
        x += 1;
        x++; //increment by 1
    }
}
