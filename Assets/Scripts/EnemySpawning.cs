using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  Spawning 1-5 at a time,
 *  from specified points
 *  above the screen so they 
 *  move down towards the player
 */
public class EnemySpawning : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    int numberToSpawn;

    public float spawnFrequency = 5f;
    float spawnCooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnCooldown += Time.deltaTime;
        if(spawnCooldown >= spawnFrequency)
        {
            SpawnEnemies();
        }


    }

    void SpawnEnemies()
    {
        numberToSpawn = Random.Range(1, 6);
        for(int i = 1; i <= numberToSpawn; i++)
        {
            Instantiate(enemyPrefab, spawnPoints[i].position, spawnPoints[i].rotation); // need to spawn only once per point per spawn event
        }
        spawnCooldown = 0f;
        spawnFrequency = Random.Range(4, 8);
    }
}
