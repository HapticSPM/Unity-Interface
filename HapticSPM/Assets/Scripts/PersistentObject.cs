using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    // Initializes when the application starts
    void Awake()
    {
        // This will keep the main actor across scenes without checking for duplicates
        DontDestroyOnLoad(gameObject);
    }
}
