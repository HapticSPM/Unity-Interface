using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenu : MonoBehaviour
{
    public string firstSimulationScene = "i2atoms"; // Set to your first atomic scene
    public AudioSource buttonClickSound; // Assign the sounds of clicking the start button
    public CanvasGroup startMenuCanvasGroup; // Reference to the CanvasGroup for fading out
    public float fadeDuration = 1.0f; // Duration of the fade-out effect

    // Shift from startup screen to loading the first surface
    public void StartSimulation()
    {
        buttonClickSound.Play(); // Play the button sound
        StartCoroutine(FadeOutAndLoadScene()); // Fade out before loading the scene
    }

    // Fade out the UI elements in the startup screen
    private IEnumerator FadeOutAndLoadScene()
    {
        float elapsedTime = 0f; // Initialize time to zero

        // Fade while time is below the chosen duration of the fade
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);  // Lerp from 1 (opaque) to 0 (transparent)
            startMenuCanvasGroup.alpha = alpha; // Assign the alpha of the start menu to the assigned value
            elapsedTime += Time.deltaTime; // Increase time by a step
            yield return null; // Wait until the next frame
        }
        
        startMenuCanvasGroup.alpha = 0f; // Ensure it is fully transparent before loading the scene

        // Load the next scene after the fade-out is complete
        SceneManager.LoadScene(firstSimulationScene);
    }

    // Close the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
