using UnityEngine;

public class ProbeDetector : MonoBehaviour
{
    // Turns the probe tip green when a collision at the surface is detected
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }

    // Turns the probe tip red when the collision ends
    private void OnCollisionExit(Collision collision)
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
