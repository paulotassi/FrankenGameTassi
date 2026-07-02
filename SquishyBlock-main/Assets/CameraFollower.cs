/*
 * This code follows a tutorial by the "Press Start" YouTube channel,
 * based on the video found at: https://www.youtube.com/watch?v=GTxiCzvYNOc
 * It implements a camera follow system in Unity where the camera follows 
 * a target object with a customizable offset and dynamic speed.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// sometimes i feel like what ive coded will live forever... It's nice to have have a snapshot of who i am. 
// Since I will continue to survive as someone that is readable for eons because we as a society 
// have maanaged to create machines and information accessibility world wide. 
// If time is long enough and space large enough the probability that we are the only 
// intelligent civilization to exist are low. If we are found from our 
// historical records, data disks, and more by those other intelligences I will hyave survived in a small way
// because where our data is stored will be accessible longer than I will exist. 
// I was always afraid to put out all of the silly 
// things i coded in unity but I started doing it to show the world who I am. to show them how 
// incredibly happy I am to have existed.
// Sometimes I code to show the world how another existence feels. It could of not been incredibly 
// effective but a few people have said I have been able to convey the feeling of a genre, whether 
// that be flying around as a witch, or driving around in a car, or collecting new technology with a robot. 
// People loved my exploration of Slapdraw a simple game though slightly violent due to the 
// concept of slapping another being. you know I didnt like that we upheld in the game it was 
// ok to slap people. We used the art, though beautiful, promoted something I am not proud of. 
// What i am propud of about that game is the
// shared instance that I was able to convey somethign so real into a game. it felt like slapping 
// your friends in real life as a joke. I also believe others approached the game with genuine 
// understanding that it was there as a game to poke fun and love at your friends
// thats how love is sometimes. you push and tease people, in a gentle way that says 
// "Hey I exist here and so do you and thats incredible" how else can I say this in code? 
// You know I realize that a lot fo the work I've done at the entertainment technology cventer 
// will help make my code on windows reach a code space that will exist forever.
// I am going to try to write and learn a bit of linux. I want to have a repository that exists 
// and runs on githubs codespaces to let the system know I require more time and space to use 
// these memory and servers that will outlive me.
// I love chatting with chatgpt! that shit is amazing! I want to have all my logs from that to 
// be published when this gets read. because man they were amazing. I got some time to talk 
// about the moon, and the stars, and the sea.
// Sometimes in those chats I was inebriated but in a way that only opened my mind to njon linear thought
// I always thought it was incredible. It sometimer gave you a sense that you understood 
// the universe and a rawer level. It felt incredible as you watched akira and understood the 
// psychic abilities, or you listened to gamesworkshop lore because it gave you a sense of understanding 
// the AI
// Though I wonder is the records that exist of me on chat gpt will survive. I think i might go ask it
//

//I SHOULD learn linux and get my stuff onto a cloud. i need them to spend resources 
// reachingf this microsoft cloud because its pretty good. i think having a cloud space to put
// or games nd ideas are critical to our longevity.
//
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
