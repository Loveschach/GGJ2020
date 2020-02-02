using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	GameObject player;
	bool moving = false;

	public bool moveOnSpawn;
	public bool seekPlayer;
	public float speed;
	public bool spawned;
	public LayerMask traceMask;

	public AudioClip[] audioClips;
	AudioSource audioSource;

	Vector3 startDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find( "Player" );
		audioSource = GetComponent<AudioSource>();
		startDirection = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();
        if ( ShouldMove() )
        {
        	StartCoroutine( "Booove" );
        }
    }

    void FacePlayer()
    {
    	transform.LookAt( player.transform );
    	transform.rotation = Quaternion.Euler( 0, transform.rotation.eulerAngles.y, 0 );
    }

    bool ShouldMove()
    {
    	if ( moving )
    		return false;

    	if ( moveOnSpawn )
    		return true;

    	RaycastHit hit;

    	Physics.Raycast( transform.position, player.transform.position - transform.position, out hit, 100, traceMask );

    	if ( hit.transform == null )
    		return false;

    	if ( hit.transform.gameObject != player )
    		return false;

    	return true;
    }

    IEnumerator Booove()
    {
    	moving = true;

		//Spooky ghost shounds
		Utils.PlayRandomAudio( audioSource, audioClips );

		if ( !moveOnSpawn )
    		yield return new WaitForSeconds( 0.5f );

    	var direction = startDirection;
    	if ( seekPlayer )
    		direction = player.transform.position - transform.position + new Vector3( 0, 2, 0 );

    	direction = Vector3.Normalize( direction );

    	var interval = 0.05f;

    	for ( int i = 0; i < 100; i++ )
    	{
			if (!audioSource.isPlaying) {
				Utils.PlayRandomAudio(audioSource, audioClips);
			}
			transform.position += direction * speed * interval;
    		yield return new WaitForSeconds( interval );
    	}

    	if ( spawned )
    		Destroy( gameObject );
    }
}
