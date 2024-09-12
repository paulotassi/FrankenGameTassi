using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleMover : MonoBehaviour
{
    public float speed;
    public bool movingLeft;
    public Vector2 rightThreshold;
    public Vector2 leftThreshold;
    public UnityEvent UnityEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= rightThreshold.x)
        {
            movingLeft = true;
        } else if (transform.position.x <= leftThreshold.x) 
        { 
            movingLeft = false;
        }

        if (movingLeft)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        
    }
}
