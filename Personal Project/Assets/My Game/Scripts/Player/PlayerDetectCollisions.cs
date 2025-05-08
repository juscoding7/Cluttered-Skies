using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectCollisions : MonoBehaviour
{
    public bool gameOver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            // Destroys self
            Destroy(gameObject);
            gameOver = true;
        }
    }
}
