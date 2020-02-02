using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
	FirstPersonController controller;
	Vector3 og_checkpoint;
	Vector3 checkpoint;

	public Image deathScreen;
	public Image hurtScreen;

	public AudioClip[] deathSounds;
	AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
    	controller = GetComponent<FirstPersonController>();
        checkpoint = transform.position;
        og_checkpoint = checkpoint;
		audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter( Collider other )
    {
    	var trigger = other.GetComponent<CheckpointTrigger>();
        if ( trigger != null )
        {
        	checkpoint = trigger.checkpoint;
        	return;
        }

        var enemy = other.GetComponent<Enemy>();
        if ( enemy != null )
        {
        	StartCoroutine( "Die" );
        }
    }

    IEnumerator Die()
    {
    	controller.enabled = false;

    	StartCoroutine( LerpAlpha( hurtScreen, 0.5f, 1f ) );

		Utils.PlayRandomAudio(audioSource, deathSounds);

    	yield return new WaitForSeconds( 0.5f );

    	StartCoroutine( LerpAlpha( hurtScreen, 0.5f, 1f ) );
    	StartCoroutine( LerpAlpha( deathScreen, 0.5f, 1f ) );

    	yield return new WaitForSeconds( 0.5f );

    	controller.transform.position = checkpoint;

    	yield return new WaitForSeconds( 0.2f );

    	controller.enabled = true;

    	SetAlpha( hurtScreen, 0.0f );
    	SetAlpha( deathScreen, 0.0f );
    }

    IEnumerator LerpAlpha( Image screen, float seconds, float targetAlpha )
    {
    	var startAlpha = screen.color.a;
    	var timeElapsed = 0.0f;
    	var interval = 0.05f;
    	while ( timeElapsed < seconds )
    	{
    		yield return new WaitForSeconds( interval );
    		timeElapsed += interval;
    		SetAlpha( screen, Mathf.Lerp( startAlpha, targetAlpha, timeElapsed / seconds ) );
    	}
    	SetAlpha( screen, targetAlpha );
    }

    void SetAlpha( Image screen, float alpha )
    {
    	screen.color = new Color( screen.color.r, screen.color.g, screen.color.b, alpha );
    }
}
