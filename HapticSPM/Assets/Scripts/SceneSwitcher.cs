using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI; 
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{
    public TextMeshProUGUI loadingText; // Reference to the UI Text
    public Slider progressBar;  // Reference to the progress bar (slider)


    private string[] scenes = { "i2atoms", "i1atom", "honeycomb", "BN", "Wse2", "onedefectWSe2", "twodefectsWSe2", "iline", "inatoms", "hi" }; // List of all the available surface scenes
    private int currentSceneIndex = 0; // Initialize the index of the first scene at 0

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progressBar.gameObject.SetActive(false); // Hide progress bar initially
        loadingText.gameObject.SetActive(false); // Hide loading text initially

        // Forbids switching in StartScene
        if (SceneManager.GetActiveScene().name == "StartScene") return; 

        // Finds the loading text
        if (loadingText == null)
        {
            loadingText = GameObject.Find("LoadingText").GetComponent<TextMeshProUGUI>();
        }

        // Finds the progress bar
        if (progressBar == null)
        {
            progressBar = GameObject.Find("ProgressBar").GetComponent<Slider>();
        }

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex - 1; // Adjust index to remove StartScene
    }

    void Update()
    {

        // Only allows switching outside of StartScene
        if (SceneManager.GetActiveScene().name != "StartScene") 
        {
            // Press hotkey '1' to load scene 1
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentSceneIndex = 0;
                LoadScene(0);
            }
            // Press hotkey '2' to load scene 2
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentSceneIndex = 1;
                LoadScene(1);
            }

            // Press hotkey '3' to load scene 3
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentSceneIndex = 2;
                LoadScene(2);
            }

            // Press hotkey '4' to load scene 4
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                currentSceneIndex = 3;
                LoadScene(3);
            }

            // Press hotkey '5' to load scene 5
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                currentSceneIndex = 4;
                LoadScene(4);
            }

            // Press hotkey '6' to load scene 6
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                currentSceneIndex = 5;
                LoadScene(5);
            }

            // Press hotkey '7' to load scene 7
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                currentSceneIndex = 6;
                LoadScene(6);
            }

            // Press hotkey '8' to load scene 8
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                currentSceneIndex = 7;
                LoadScene(7);
            }

            // Press hotkey '9' to load scene 9
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                currentSceneIndex = 8;
                LoadScene(8);
            }

            // Press hotkey '0' to load scene 10
            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                currentSceneIndex = 9;
                LoadScene(9);
            }

            // If Right Arrow key is pressed, go to the next scene
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                LoadNextSceneAsync();
            }

            // If Left Arrow key is pressed, go to the previous scene
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                LoadPreviousSceneAsync();
            }
        }
    }

    // Loads scene based on scene index
    public void LoadScene(int sceneIndex)
    {
        // Determines if scene index is valid
        if (sceneIndex >= 0 && sceneIndex < scenes.Length)
        {
            // Start a coroutine to load the indicated scene
            StartCoroutine(LoadSceneAsync(scenes[sceneIndex]));
        }
    }

    // Asynchronously loads the next scene
    public void LoadNextSceneAsync()
    {
        currentSceneIndex = (currentSceneIndex + 1) % scenes.Length; // Increases the scene index by one (modulo the number of surfaces)
        StartCoroutine(LoadSceneAsync(scenes[currentSceneIndex])); // Starts a coroutine to load the next scene
    }

    // Asynchronously loads the previous scene
    public void LoadPreviousSceneAsync()
    {
        currentSceneIndex = (currentSceneIndex - 1 + scenes.Length) % scenes.Length; // Decreases the scene index by one (modulo the number of surfaces)
        StartCoroutine(LoadSceneAsync(scenes[currentSceneIndex])); // Starts a coroutine to load the previous scene
    }

    // Creates the loading elements
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        loadingText.gameObject.SetActive(true);  // Show loading message
        loadingText.text = "Loading " + sceneName + "..."; // Show the loading scene
        progressBar.gameObject.SetActive(true);  // Show progress bar
        progressBar.value = 0f;  // Reset progress bar value to 0 at the start

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName); // Checks status of asynchronous loading

        // Shows the loading text and progress bar when the asycnhronous loading is incomplete
        while (!asyncLoad.isDone)
        {
            progressBar.value = asyncLoad.progress; // Set the progress of the loading operation (from 0 to 1)
            loadingText.text = "Loading " + sceneName + " (" + (asyncLoad.progress * 100f).ToString("F0") + "%)"; // Update the loading text with the progress percentage

            asyncLoad.allowSceneActivation = true; // Allows the loading scene to activate

            yield return null;
        }

        // Hide loading message and progress bar when done
        loadingText.gameObject.SetActive(false);
        progressBar.gameObject.SetActive(false);
    }
}
