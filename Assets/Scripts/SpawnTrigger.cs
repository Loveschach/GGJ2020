using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
	public EnemySpawner[] spawners;
	public bool stopSpawning;

    void OnTriggerEnter( Collider other )
    {
    	foreach( EnemySpawner spawner in spawners )
    	{
    		if ( stopSpawning )
    			spawner.active = false;
    		else
    			spawner.active = true;
    	}
    }
}
