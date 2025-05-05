using UnityEngine;
using System.Collections;

public class FadeInEffect : MonoBehaviour
{
    public CanvasGroup canvasGroup;  // Reference to the Canvas Group component
    public float fadeInDuration = 2f;  // Duration of the fade-in effect

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start the fade-in effect when the scene starts
        StartCoroutine(FadeIn());
    }

    // Coroutine to fade in the UI element
    IEnumerator FadeIn()
    {
        float elapsedTime = 0f; // Initialize the time to be zero
        canvasGroup.alpha = 0f; // Set initial alpha of the object to 0

        // Gradually increase the alpha of the object to 1
        while (elapsedTime < fadeInDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration); // Increase the alpha
            elapsedTime += Time.deltaTime; // Increase the time by a step
            yield return null;
        }

        // Ensure the alpha of the object is set to 1 at the end
        canvasGroup.alpha = 1f;
    }
}
