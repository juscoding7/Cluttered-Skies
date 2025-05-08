using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateDestroy : MonoBehaviour
{
    public static DuplicateDestroy instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Duplicate Audio Destroyed");
            Destroy(gameObject);
        }
        instance = this;
    }
}
