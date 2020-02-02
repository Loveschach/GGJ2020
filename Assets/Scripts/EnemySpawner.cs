using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
    public bool active = false;
    public float spawnRate = 2f;
    public float spawnOffset;
    public int count = -1;

    float nextSpawnTime;
    int spawned = 0;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool wasActive = false;

    // Update is called once per frame
    void Update()
    {
        if ( active && !wasActive )
            nextSpawnTime = Time.time + spawnOffset;

        wasActive = active;

        if ( active && Time.time >= nextSpawnTime && ( count < 0 || spawned < count ) )
        {
            Enemy enemy = Instantiate( enemyPrefab, transform.position, transform.rotation ).GetComponent<Enemy>();
            enemy.spawned = true;
            spawned++;
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    public void Reset()
    {
        active = false;
        wasActive = false;
        spawned = 0;
        nextSpawnTime = 0;
    }
}
