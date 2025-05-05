using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuitOnEscape : MonoBehaviour
{
    public GameObject exitPanel; // Reference to the exit panel
    public TextMeshProUGUI exitMessage; // Reference to the exit message
    public Button yesButton; // Reference to the yes button
    public Button noButton; // Reference to the no button

    private bool isExitRequested = false; // Initializes exit request to be false

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Hide the exit panel initially
        exitPanel.SetActive(false);

        // Add listeners for the buttons
        yesButton.onClick.AddListener(QuitApplication);
        noButton.onClick.AddListener(CancelExit);
    }

    // Update is called once per frame
    void Update()
    {
        // Listen for the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape) && !exitPanel.activeSelf)
        {
            isExitRequested = true; // Updates exit request to be true
            exitPanel.SetActive(true); // Show the exit confirmation panel
            exitMessage.text = "Are you sure you want to exit?"; // Sets the exit confirmation text
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && exitPanel.activeSelf)
        {
            isExitRequested = false; // Returns the exit request to be false
            exitPanel.SetActive(false); // Remove the exit confirmation panel
        }
    }

    // Fulfills the request of the exit process
    void QuitApplication()
    {
        // Quit the application
        Application.Quit();

        // If running in the Unity editor, stop the play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // Stops the execution of the exit process
    void CancelExit()
    {
        exitPanel.SetActive(false); // Hide the exit panel and reset the exit request
        isExitRequested = false; // Returns the exit request to be false
    }
}
