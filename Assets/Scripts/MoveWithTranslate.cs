using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Monobehaviour is saying that this class will become a component on a gameoject
public class MoveWithTranslate : MonoBehaviour
{
    //Variables
    // Stores a value/ data
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
