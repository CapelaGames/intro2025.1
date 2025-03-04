using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPowerup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(rb.velocity.normalized * 1000f);
        }
    }
}
