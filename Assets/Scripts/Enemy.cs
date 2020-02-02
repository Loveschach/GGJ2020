using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	GameObject player;
	bool moving = false;

	public bool seekPlayer;
	public float speed;

	public AudioClip[] audioClips;
	AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find( "Player" );
		audioSource = GetComponent<AudioSource>();
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

    	RaycastHit hit;

    	Physics.Raycast( transform.position, player.transform.position - transform.position, out hit, 100 );

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

    	yield return new WaitForSeconds( 0.5f );

    	var direction = transform.forward;
    	if ( seekPlayer )
    		direction = player.transform.position - transform.position + new Vector3( 0, 2, 0 );

    	direction = Vector3.Normalize( direction );

    	var interval = 0.05f;

    	for ( int i = 0; i < 1000; i++ )
    	{
			if (!audioSource.isPlaying) {
				Utils.PlayRandomAudio(audioSource, audioClips);
			}
			transform.position += direction * speed * interval;
    		yield return new WaitForSeconds( interval );
    	}
    }
}
