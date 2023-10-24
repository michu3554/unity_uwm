using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad6 : MonoBehaviour
{
    // Smooth towards the height of the target

    Transform target;
    float smoothTime = 0.3f;
    float yVelocity = 0.0f;
    float lerpTime = 0.5f;
    private void Start()
    {
        target = GameObject.Find("Plane").transform;
    }

    void Update()
    {
        float newPositionSmooth = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        float newPositionLerp = Mathf.Lerp(transform.position.y, target.position.y, lerpTime);
        //transform.position = new Vector3(transform.position.x, newPositionSmooth, transform.position.z);
        transform.position = new Vector3(transform.position.x, newPositionLerp, transform.position.z);
    }
}
