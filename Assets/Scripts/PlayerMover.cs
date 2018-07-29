using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour 
{
    public float speed = 4f;
    public float jumpSpeed = 3f;

    float camRayLength = 100f;          // The length of the ray from the camera into the scene.
    int floorMask;
    private Rigidbody playerRigidbody;
    Vector3 movement;                   // The vector to store the direction of the player's movement.

    void Awake ()
    {
        floorMask = LayerMask.GetMask ("Floor");
        playerRigidbody = GetComponent <Rigidbody> ();
    }


    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        bool startJump = Input.GetButtonDown("Jump");

        if(startJump) 
        {
            Jump();
        } else {
            Move(moveHorizontal, moveVertical);
        }
        Turning ();
    }

    void Jump()
    {
        playerRigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        //  Debug.Log("jump");
    }

    void Move (float h, float v)
    {
        movement = transform.forward * v;
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
        /*
        // Set the movement vector based on the axis input.
        movement.Set (h, 0f, v);
        
        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition (transform.position + movement);
        */
    }

    void Turning ()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation (newRotation);

            Debug.DrawLine(camRay.origin, floorHit.point, Color.red);

            // Debug.DrawLine(Camera.main.transform.position, floorHit.point, Color.red);
        }
    }

}