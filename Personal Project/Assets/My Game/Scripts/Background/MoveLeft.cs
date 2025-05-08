using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]private float speed = 30;
    private PlayerDetectCollisions PlayerDetectCollisionsScript;
    GameManager GameManager;

    void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameActive == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }

    void PlayerHasSpawned()
    {
        PlayerDetectCollisionsScript = GameObject.Find("Player").GetComponent<PlayerDetectCollisions>();
        Debug.Log("Found player");
    }
}