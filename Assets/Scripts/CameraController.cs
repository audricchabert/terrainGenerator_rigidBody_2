using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // ref: https://www.youtube.com/watch?v=_QajrabyTJc
    //from project : Brackeys_FPS_Movement_unity2020

    public float mouseSensitivity = 1200f;

    float xRotation = 0f;
    float xSensitivity = 0.5f;
    float ySensitivity = 0.5f;
    public Quaternion cameraRotation; 

    public Transform playerBody;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY * xSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.localRotation = cameraRotation;
        playerBody.Rotate(Vector3.up * mouseX * ySensitivity);

    }
}

