using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
	public float minRandTime = 0.1f;
	public float maxRandTime = 0.5f;
	public AudioClip[] sounds;
	AudioSource audioSource;
	void Start() {
		audioSource = GetComponent<AudioSource>();
		StartCoroutine("PlayRandomSound");
	}

	IEnumerator PlayRandomSound() {
		yield return new WaitForSeconds(Random.Range(minRandTime, maxRandTime));
		if (!audioSource.isPlaying) {
			Utils.PlayRandomAudio(audioSource, sounds);
		}
		StartCoroutine("PlayRandomSound");
	}
}
