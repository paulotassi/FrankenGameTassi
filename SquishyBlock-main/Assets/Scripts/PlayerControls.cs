using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
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
