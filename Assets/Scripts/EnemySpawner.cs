using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
    public bool active = false;
    public float spawnRate = 2f;
    public float spawnOffset;

    float nextSpawnTime = 0f;
	
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime += spawnOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if ( active && Time.time >= nextSpawnTime )
        {
            Enemy enemy = Instantiate( enemyPrefab, transform.position, transform.rotation ).GetComponent<Enemy>();
            enemy.spawned = true;
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
