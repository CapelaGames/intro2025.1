using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveWithCharacterController : MonoBehaviour
{
    CharacterController character;
    public float speed = 5f;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        character.Move(Vector3.forward * speed * Time.deltaTime);
    }
}
