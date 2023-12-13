using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float forceMultiplier = 3f;
    public float jumpHeight = 1.0f; // copied from lab04/zdanie 4
    private Vector3 originalPosition;
    private float pressedValue = 0.1f;

    void Start()
    {
        originalPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector3(transform.position.x, originalPosition.y - pressedValue, transform.position.z);
            Debug.Log("Player entered Pressure Plate");

            MoveWithCharacterController playerController = other.GetComponent<MoveWithCharacterController>();
            if (playerController != null)
            {
                Debug.Log("applying force");
                float force = jumpHeight * forceMultiplier;
                playerController.ApplyExternalForce(force);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited Pressure Plate");
            transform.position = originalPosition;
        }
    }
}
