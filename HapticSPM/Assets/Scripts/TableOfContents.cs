using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TableOfContents : MonoBehaviour
{
    public GameObject tableContents;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Hide table of contents initially
        tableContents.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Listen for the t key press and check if the table of contents is not active
        if (Input.GetKeyDown(KeyCode.T) && !tableContents.activeSelf)
        {
            tableContents.SetActive(true); // Show the table of contents
        }

        // Listen for the t key press and check if the table of contents is already active
        else if (Input.GetKeyDown(KeyCode.T) && tableContents.activeSelf)
        {
            tableContents.SetActive(false); // Hide the table of contents
        }
    }
}
