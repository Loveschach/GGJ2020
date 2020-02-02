using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
	public FirstPersonController playerController;
	public bool complete = false;

	List<Enemy> enemies;
	List<Enemy> checkpointEnemies;

	void Awake()
	{
		playerController = GameObject.Find( "Player" ).GetComponent<FirstPersonController>();
		enemies = new List<Enemy>();
		checkpointEnemies = new List<Enemy>();
	}

    // Start is called before the first frame update
    void Start()
    {
    	
        // Log enemy positions
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( "r" ) )
        	Reset();
    }

    public void Reset( bool playerDied = false )
    {
    	complete = false;

    	foreach ( Enemy enemy in enemies )
    	{
    		Destroy( enemy.gameObject );
    	}

    	enemies = new List<Enemy>();

    	var spawners = FindObjectsOfType<EnemySpawner>();
    	foreach ( EnemySpawner spawner in spawners )
    	{
    		spawner.Reset();
    	}

    	WinTrigger trigger = FindObjectOfType<WinTrigger>();
    	trigger.Reset();

    	if ( !playerDied )
    	{
    		StartCoroutine( "SendPlayerToStart" );
    	}

    	//List<Enemy> enemiesToReset = enemies;
    	//if ( playerDied )
    	//	enemiesToReset = checkpointEnemies;
    }

    IEnumerator SendPlayerToStart()
    {
    	playerController.enabled = false;

    	PlayerDeath playerDeath = playerController.GetComponent<PlayerDeath>();
    	Image deathScreen = playerDeath.deathScreen;
    	SetAlpha( deathScreen, 1.0f );

    	yield return new WaitForSeconds( 0.1f );

    	playerDeath.Reset();
    	playerController.transform.position = playerDeath.GetStartPosition();

    	yield return new WaitForSeconds( 0.1f );

    	playerController.enabled = true;

    	SetAlpha( deathScreen, 0.0f );
    }

    void SetAlpha( Image screen, float alpha )
    {
    	screen.color = new Color( screen.color.r, screen.color.g, screen.color.b, alpha );
    }

    public void AddEnemy( Enemy enemy )
    {
    	enemies.Add( enemy );
    	//checkpointEnemies.Add( enemy );
    }

    public void RemoveEnemy( Enemy enemy )
    {
    	enemies.Remove( enemy );
    	//if ( checkpointEnemies.Contains( enemy ) )
    	//	checkpointEnemies.Remove( enemy );
    }

    public void Checkpoint()
    {
    	//checkpointEnemies = new List<Enemy>();
    }
}
