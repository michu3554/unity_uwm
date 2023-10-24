using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad1 : MonoBehaviour
{
    private bool movingRight = true;
    private float startingPosition;

    private void Start()
    {
        startingPosition = transform.position.x;
    }

    private void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
            if (transform.position.x >= startingPosition + 10)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
            if (transform.position.x <= startingPosition)
            {
                movingRight = true;
            }
        }
    }
}
