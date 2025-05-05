using UnityEngine;
using System.Collections.Generic;

public class ParticlePool : MonoBehaviour
{
    
    public static ParticlePool Instance; // Singleton instance for easy access
    public ParticleSystem particlePrefab; // Assign your particle system prefab via the Inspector
    public int poolSize = 10; // Define the initial pool size
    private Queue<ParticleSystem> pool = new Queue<ParticleSystem>(); // Queue to hold available particle systems

    // Initializes when the application starts
    void Awake()
    {
        Instance = this; // Initialize the singleton instance

        // Pre-instantiate particle systems and deactivate them
        for (int i = 0; i < poolSize; i++)
        {
            ParticleSystem particle = Instantiate(particlePrefab);
            particle.gameObject.SetActive(false);
            pool.Enqueue(particle);
        }
    }

    // Retrieves a particle system from the pool and positions it
    public ParticleSystem GetParticle(Vector3 position, Quaternion rotation)
    {
        ParticleSystem particle;
        if (pool.Count > 0)
        {
            particle = pool.Dequeue();
            particle.gameObject.SetActive(true);
            particle.transform.position = position;
            particle.transform.rotation = rotation;
        }
        else
        {
            particle = Instantiate(particlePrefab, position, rotation); // If the pool is empty, instantiate a new particle system
        }
        return particle;
    }

    // Returns the particle system to the pool for reuse
    public void ReturnParticle(ParticleSystem particle)
    {
        particle.gameObject.SetActive(false);
        pool.Enqueue(particle);
    }
}
