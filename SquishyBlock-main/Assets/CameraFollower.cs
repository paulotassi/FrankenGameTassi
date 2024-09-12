/*
 * This code follows a tutorial by the "Press Start" YouTube channel,
 * based on the video found at: https://www.youtube.com/watch?v=GTxiCzvYNOc
 * It implements a camera follow system in Unity where the camera follows 
 * a target object with a customizable offset and dynamic speed.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Public variables that can be set in the Unity Inspector
    public GameObject followObject;   // The object that the camera will follow (e.g., the player)
    public Vector2 followOffset;      // The customizable offset between the camera and the follow object
    public fadeWinScreen fader;       // Fade to black function for win screen

    // Private variables used internally by the script
    private Vector2 threshold;        // The distance the target has to move before the camera follows
    public float cameraSpeed = 3f;    // Default camera speed, can be changed in Inspector
    private Rigidbody2D rb;           // The Rigidbody2D of the object being followed

    // Start is called before the first frame update
    void Start()
    {
        // Calculate the initial threshold value based on camera aspect ratio and offset
        threshold = calculateThreshold();

        // Access the Rigidbody2D component of the followObject, used to adjust camera speed based on object's movement
        rb = followObject.GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called at fixed intervals (used for physics updates)
    void FixedUpdate()
    {
        // Get the current position of the object we are following
        Vector2 follow = followObject.transform.position;

        // Calculate the horizontal distance (x-axis) between the camera and the follow object
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);

        // Calculate the vertical distance (y-axis) between the camera and the follow object
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        // Initialize a new position variable with the current camera position
        Vector3 newPosition = transform.position;

        // If the x-axis distance exceeds the threshold, adjust the camera's x position to follow
        if (Mathf.Abs(xDifference) >= threshold.x)
        {
            newPosition.x = follow.x;
        }

        // If the y-axis distance exceeds the threshold, adjust the camera's y position to follow
        if (Mathf.Abs(yDifference) >= threshold.y)
        {
            newPosition.y = follow.y;
        }

        // Determine the camera's movement speed, either the object's velocity or the default cameraSpeed, whichever is greater
        float moveSpeed = rb.velocity.magnitude > cameraSpeed ? rb.velocity.magnitude : cameraSpeed;

        // Smoothly move the camera towards the new position using MoveTowards function
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);

        if (transform.position.y < -530f)
        {
           fader.GetComponent<fadeWinScreen>().Fader(); 
        //A soft Fade to black end screen
        }
    }

    // Function to calculate the threshold at which the camera will start following the object
    private Vector3 calculateThreshold()
    {
        // Get the dimensions of the camera's viewable area
        Rect aspect = Camera.main.pixelRect;

        // Calculate the size of the threshold based on the camera's orthographic size and the aspect ratio
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);

        // Subtract the followOffset to customize the offset of the camera from the object
        t.x -= followOffset.x;
        t.y -= followOffset.y;

        // Return the calculated threshold as a Vector2
        return t;
    }

    // Draws visual aids in the Unity editor to show the threshold boundaries for the camera
    private void OnDrawGizmos()
    {
        // Set the Gizmos color to blue
        Gizmos.color = Color.blue;

        // Calculate the threshold again to draw the correct boundaries
        Vector2 border = calculateThreshold();

        // Draw a wireframe cube in the scene view showing the camera's boundary box for following the object
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
}
