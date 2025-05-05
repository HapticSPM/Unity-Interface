using UnityEngine;
using System.Collections;

public class ParticleOnCollision : MonoBehaviour
{
    // Detect when there is a collision between the Haptic Pen and the surface
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the desired surface using a tag
        if (collision.gameObject.CompareTag("Surface"))
        {
            ContactPoint contact = collision.contacts[0]; // Get the first contact point
            Vector3 collisionPoint = contact.point; // Set the collision point to be a Vector3
            Quaternion collisionRotation = Quaternion.FromToRotation(Vector3.up, contact.normal); // Initalize the angle at which the collision occurred 

            // Request a particle effect from the pool
            ParticleSystem effect = ParticlePool.Instance.GetParticle(collisionPoint, collisionRotation);
            effect.Play();

            // Start a coroutine to return the particle system to the pool
            StartCoroutine(ReturnToPool(effect, effect.main.duration + effect.main.startLifetime.constantMax));
        }
    }

    // Coroutine to wait until the particle effect is finished before returning it
    IEnumerator ReturnToPool(ParticleSystem effect, float delay)
    {
        yield return new WaitForSeconds(delay);
        ParticlePool.Instance.ReturnParticle(effect);
    }
}
