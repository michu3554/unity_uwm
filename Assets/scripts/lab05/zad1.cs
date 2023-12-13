using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float platformSpeed = 1.8f;
    private bool isMoving = false;
    private bool movingForward = true;
    private bool movingBackward = false;
    private float startPosition = 4f;
    private float endPosition = 10f;
    private bool playerOnPlatform = false;

    void Start()
    {
    }

    void Update()
    {
        if (movingForward && transform.position.x >= endPosition) //if going + and at endPosition = run back
        {
            isMoving = true;
            movingForward = false;
            movingBackward = true;
        }
        else if (movingBackward && transform.position.x <= startPosition) //if going - and at startPosition = stop running or start
        {
            movingBackward = false;
            //the platform will keep moving if the player is still on it:
            if (playerOnPlatform)
            {
                movingForward = true;
            }
            else
            {
                isMoving = false;
            }
        }

        if (isMoving)
        {
            Vector3 moveDirection = movingForward ? transform.right : -transform.right; // change direction +/-
            Vector3 move = moveDirection * platformSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the platform.");
            playerOnPlatform = true;

            if (transform.position.x <= startPosition) //if entered at startPosition, begin movement
            {
                movingForward = true;
                movingBackward = false;
            }
            isMoving = true; //keep running if player still on platform
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited the platform.");
            playerOnPlatform = false;
        }
    }
}