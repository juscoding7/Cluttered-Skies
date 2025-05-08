using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    public ParticleSystem explosionParticle;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "projectile")
        {
            Debug.Log("Explode");

            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
        // Destroys object and target on contact
        Destroy(gameObject);
        Destroy(other.gameObject);

    }
}
