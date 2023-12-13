using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player;
    private float rotationX = 0f; // zapis aktualnej rotacji
    public float sensitivity = 200f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // esc to unhide
    }

    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // rotacja osi Y
        player.Rotate(Vector3.up * mouseXMove);

        // get rotacja osi X + sprawdü czy osiπga limit - if yes don't go over it
        rotationX -= mouseYMove;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}