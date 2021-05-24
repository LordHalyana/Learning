using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

    public GameObject[] enemyType;
    public float spawnTime = 60.0f;

    private GameObject _spawndEnemy;
    private int enemynumber = 0;

	void Start ()
    {
        InvokeRepeating("SpawnRandom", spawnTime, spawnTime);
	}
	

    public void SpawnRandom()
    {
        Debug.Log("Attempting to spawn enemy...");

        GameObject[] enemySpawns = GameObject.FindGameObjectsWithTag("EnemySpawnLocation");

        int spawnNumber = Random.Range(0, enemySpawns.Length);
        GameObject positionToSpawnAt = enemySpawns[spawnNumber];

        enemynumber++;
        GameObject enemy;

        enemy = Instantiate(enemyType[Random.Range(0, enemyType.Length)], positionToSpawnAt.transform.position, positionToSpawnAt.transform.rotation);
        enemy.name = "Enemy" + enemynumber;
    }
}
