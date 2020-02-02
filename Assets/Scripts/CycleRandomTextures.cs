using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleRandomTextures : MonoBehaviour
{
	public float minRandTime = 0.1f;
	public float maxRandTime = 0.5f;
	public Texture[] textures;
	public Renderer[] renderers;
    void Start()
    {
		renderers = GetComponentsInChildren<Renderer>();
		StartCoroutine("AssignRandomTextures");
    }

    IEnumerator AssignRandomTextures()
    {
		foreach (Renderer renderer in renderers) {
			renderer.material.SetTexture("Texture", textures[Random.Range(0, textures.Length)]);
			yield return new WaitForSeconds(Random.Range(minRandTime, maxRandTime));
		}
    }
}
