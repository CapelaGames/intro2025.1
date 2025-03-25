using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 10f;
    public float sensitivity = 100f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    //Late update is like update, but for cameras
    void LateUpdate()
    {
        //Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        //Apply mouse to rotation
        xRotation += mouseX;
        yRotation -= mouseY;

        //Calculate new positions
        Quaternion rotation = Quaternion.Euler(yRotation, xRotation, 0f);
        Vector3 offset = new Vector3(0f, 0f, -distance);
        Vector3 newPosition = target.position + rotation * offset;

        //Apply changes to the transform of the camera
        transform.position = newPosition;
        transform.LookAt(target);
    }
}
