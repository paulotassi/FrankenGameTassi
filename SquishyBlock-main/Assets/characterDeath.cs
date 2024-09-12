using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class characterDeath : MonoBehaviour
{
    public UnityEvent Death;
    // Start is called before the first frame update
 
    public void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Death.Invoke();
        }
    }

    public void characterTrueDeath()
    {
        SceneManager.LoadScene("SquishyBlock");
    }
}
