using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefabs;
    public int enemyCount;
    private int waveNumber=1;
    public GameObject powerupPrefabs;
    
    void Start()
    {
        
        SpawnEnemeyWave(waveNumber);
        Instantiate(powerupPrefabs, GenerateSpawnPosition(), powerupPrefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount==0)
        {
            waveNumber++;
            SpawnEnemeyWave(waveNumber);
            Instantiate(powerupPrefabs, GenerateSpawnPosition(), powerupPrefabs.transform.rotation);
        }
    }
    void SpawnEnemeyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs, GenerateSpawnPosition(), enemyPrefabs.transform.rotation);
            
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(9, -9);
        float spawnZ = Random.Range(9, -9);
        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);
        return randomPos;
    }
   
}
