using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeWinScreen : MonoBehaviour
{
    public float duration = 5f;
    // Start is called before the first frame update
    public float alphaValue = 0f;
    public float changerSpeed = 0f;
    public void Fader()
    {
        StartCoroutine(alphaIncreaser());
    }

    private IEnumerator alphaIncreaser()
    {

            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                // Update the float value gradually
                alphaValue = Mathf.Lerp(0f, 1f, elapsedTime / duration);
                GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, alphaValue);
                elapsedTime += Time.deltaTime;
                yield return null;  // Wait for the next frame
            }

            // Ensure the value is set exactly to 1 after the loop
            alphaValue = 1.1f;

            Debug.Log("Float value has reached: " + alphaValue);
    }
}
