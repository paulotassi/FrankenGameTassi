using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    //I loved coding and learning how to change games ito manipoulate what I worked on
    //I want to upload a bunch of important projects here because I saw i onyl 
    // get aroiund 128gb of space in my code space. This is my second entry as a diary into the cloudspace. 
    //I don't think anyone will ever read this section but I will in time put my chatgpt logs here to show how introspective I was or tried to be.
    //I will possibly use the space to write about my life
    //I may forget about the space entirely but I dontthink I will in the long term
    //maybe this is all i wil write right now.
    //I love coffee!
    //I want to make sure all of the games and things i submit here are run. Even if some of it requires returning to windows to run correctly or just to read my comments i find it important
    //to point out that there is some value in windows coding even if it is not incredibly effecient in comparison to linux. I know that code spaces run in linux
    //I will try to learn linux to put word documents and more classic diary application on linux but for now if I dont get there please at least open and read and see how my games helped create other small infinetesimly small
    //universes where I could maybe fly, or relive moments, and get do overs =D 
    //test change

    //Other Diary entry is in the Camera Controller

    //Aditional entry is in the TeleportCharacter in theNetworkShop Unity Game
    public Rigidbody2D rb;
    float speed = 0.022f;
    public float maxVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0, 0) ;
   
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed , 0, 0) ;
     
        }
        if (GetComponent<Rigidbody2D>().velocity.y < maxVelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxVelocity);
        }
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("SquishyBlock");
        }


        //Mechanic (Squishing the Block)
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.localScale = new Vector3(1.5f, 3f, 1f);
            rb.gravityScale = 1.5f;
          
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            transform.localScale = new Vector3(3f, 3f, 1f);
            rb.gravityScale = 0.5f;
          
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.localScale = new Vector3(4f, 1f, 1f);
            rb.velocity += new Vector2(0f, 30f);
            GetComponent<CapsuleCollider2D>().direction = CapsuleDirection2D.Horizontal;
            GetComponent<CapsuleCollider2D>().size = new Vector2 (0.45f, 0.1f);
            if (gameObject.GetComponent<Rigidbody2D>().velocity.y >= 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
            }
           
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<CapsuleCollider2D>().direction = CapsuleDirection2D.Vertical;
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.25f, 0.45f);
            transform.localScale = new Vector3(3f, 3f, 1f);
            rb.gravityScale = 0.5f;

        }

    }
}
