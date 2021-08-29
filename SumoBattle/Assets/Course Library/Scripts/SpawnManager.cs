using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Properties...
    public GameObject enemy;
    private float spawnRange = 9.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 3.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Spawn enemy when called...
    private void SpawnEnemy()
    {
        float spawnPosX = Random.Range(0.0f, spawnRange);
        float spawnPosZ= Random.Range(0.0f, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0.0f, spawnPosZ);
        Instantiate(enemy, spawnPos, transform.rotation);
    }
}
