using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveWithForce : MonoBehaviour
{
    public float speed = 500f;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Everytime we want to use the physics engine, it should be in fixed update
    void FixedUpdate()
    {

        rb.AddForce(Vector3.right * speed * Time.deltaTime);

        //rb.AddForce(Vector3.right * speed * Time.deltaTime, ForceMode.Impulse);
    }
}

// Delta time
//   How much time has passed since the last frame.
//
//               DeltaTime         Update()         - Over 1 second
//   1 FPS     -   1 second     -  20 * 1   = 20    - 20 * 1 = 20 units  
//   2 FPS     -  0.5 second    -  20 * 0.5 = 10    - 10 * 2 = 21 units















