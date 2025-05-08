using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Barrier for surrounding play area
    [SerializeField] private float horizontalInput;
    [SerializeField] private float speed = 30.0f;
    [SerializeField] private float xRange = 30.0f;
    [SerializeField] private float zForward = 10.0f;
    [SerializeField] private float zBack = 46.0f;
    
    // Movement
    public float forwardInput;

    // Barell Roll
    bool isRotating = false;
    public bool pRotateR;
    public bool pRotateL;

    // Ammo
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        // Dodge Rotation Keyinput
        if (Input.GetKeyDown(KeyCode.Q))
        {
            pRotateL = true;
            pRotateR = false;
            if (isRotating == false)
                StartCoroutine(Rotate(5));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            pRotateR = true;
            pRotateL = false;
            if (isRotating == false)
                StartCoroutine(Rotate(5));
        }

        // Ammo activator
        SpawnAmmo();
       
        //LocksPlayerPos when rotating
        LockPos();
        
    
    }
    // Seperate Functions
    void LockPos()
    {
        if (transform.position.y < 0.230485f || transform.position.y > 0.230485f)
        {
            transform.position = new Vector3(transform.position.x, 0.230485f, transform.position.z);
        }
        if (!isRotating)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    void MovePlayer()
    {
        // Side to side Range
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Forward and back Range
        if (transform.position.z > zForward)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zForward);
        }

        if (transform.position.z < -zBack)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBack);
        }

        // General Movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
    }

    void SpawnAmmo()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(projectilePrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }
    //Barrel Roll
    IEnumerator Rotate(float duration)
    {
        Quaternion startRot = transform.rotation;
        float t = 0.0f;
        while (t < .5f)
        {
            isRotating = true;
            t += Time.deltaTime;

            if (pRotateR)
            {
                transform.rotation = startRot * Quaternion.AngleAxis(t / -.5f * 360, Vector3.forward);
            }
            if (pRotateL)
            {
                transform.rotation = startRot * Quaternion.AngleAxis(t / .5f * 360, Vector3.forward);
            }

            yield return null;
        }
        transform.rotation = startRot;

        isRotating = false;
    }
}
