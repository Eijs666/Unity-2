using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller; // Declaring our Charactercontroller


    public Transform cam; // Declaring our camera

    public float speed = 6f; // declaring a speed variable

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity; // variable used for smoothing angle 

    private bool groundedPlayer; // player touching ground?
    private float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity; //velocity speed in a given direction

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // getting raw input from the horizantal axis
        float vertical = Input.GetAxisRaw("Vertical"); // getting raw input from the vertical axis

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // creating a vector for storing our direction

        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // calling Atan2 for calculating the x and z axis, then using eulerAngles to rotate the camera
            float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //using SmoothDampAngle for smooth rotation
            transform.rotation = Quaternion.Euler(0f, angel, 0f); // adding angles for the rotation

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // Gives us the direction to move in, taking into account the rotation of the camera

            controller.Move(moveDir.normalized * speed * Time.deltaTime); // getting input to our controller and moving our player
        }

        // Changes the height position of the player..
        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) // Interacting with AI
    {
        if (other.CompareTag("AI"))
        {
            transform.position = respawn.position;
            print("AI");
        }
    }
}
