using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 60;
    private float spawnRangeZ = 14.0f;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    private float ySpawn = 0;
    private float randomTimer;  //random float between 3 and 5
    [SerializeField] public float rndRngLow;
    [SerializeField] private float rndRngHigh;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), ySpawn, spawnRangeZ);


        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation * Quaternion.Euler(0f, 180f, 0f));

    }
}