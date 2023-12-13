using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithCharacterController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 8.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float pushPower = 2.0f;

    private void Start()
    {
        // zak�adamy, �e komponent CharacterController jest ju� podpi�ty pod obiekt
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetButton("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // zgodnie ze wzorem y = (1/2 * g) * t-kwadrat, ale jednak w trybie play
        // okazuje si�, �e jest to zbyt wolne opadanie, wi�c zastosowano g * t-kwadrat
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // Apply the push
        body.velocity = pushDir * pushPower;

        // Checking for 'Obstacle' objects: 
        if (hit.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player collided with an Obstacle object");
        }
    }

    public void ApplyExternalForce(float force)
    {
        if (groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(force * -2f * gravityValue);
        }
    }    
}