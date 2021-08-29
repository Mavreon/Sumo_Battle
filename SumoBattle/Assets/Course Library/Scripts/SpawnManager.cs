using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Properties...
    public GameObject enemy;
    public GameObject powerup;
    private float spawnRange = 9.0f;
    private int enemiesToSpawn = 1;
    private int enemyCount;
    
    // Start is called before the first frame update
    void Start()
    {
       // InvokeRepeating("SpawnEnemy", 3.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<EnemyController>().Length;
        if(enemyCount <= 0)
        {
            SpawnEnemy();
            SpawnPowerup();
        }
    }

    //Spawn enemy when called...
    private void SpawnEnemy()
    {
        for(int i = 1; i <= enemiesToSpawn ; i++)
        {
            float spawnPosX = Random.Range(0.0f, spawnRange);
            float spawnPosZ = Random.Range(0.0f, spawnRange);
            Vector3 spawnPos = new Vector3(spawnPosX, 0.0f, spawnPosZ);
            Instantiate(enemy, spawnPos, transform.rotation);
        }
        enemiesToSpawn++;
    }

    private void SpawnPowerup()
    {
        float spawnPosX = Random.Range(0.0f, spawnRange);
        float spawnPosZ = Random.Range(0.0f, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0.0f, spawnPosZ);
        Instantiate(powerup, spawnPos, transform.rotation);
    }
}
