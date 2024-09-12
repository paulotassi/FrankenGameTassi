using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batFlipper : MonoBehaviour
{
    public ObstacleMover oM;
    // Start is called before the first frame update
    void Start()
    {
        oM = gameObject.GetComponent<ObstacleMover>();
    }

    // Update is called once per frame.
    void Update()
    {
        if (oM.movingLeft == true)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
