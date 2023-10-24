using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float force = 10.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // składowa y wektora prędkości
        if(rb.velocity.y == 0)
        {
            // działamy siłą na ciało A :)
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
