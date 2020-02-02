using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static void PlayRandomAudio(AudioSource audioSource, AudioClip[] clips) {
		// pick & play a random sound from the array
		int n = Random.Range(0, clips.Length);
		audioSource.clip = clips[n];
		audioSource.PlayOneShot(audioSource.clip);
	}
}
