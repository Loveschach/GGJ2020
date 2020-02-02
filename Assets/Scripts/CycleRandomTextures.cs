using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleRandomTextures : MonoBehaviour
{
	public Texture[] textures;
	Renderer[] renderers;
    void Start()
    {
		renderers = GetComponentsInChildren<Renderer>();
		StartCoroutine("AssignRandomTextures");
    }

    IEnumerator AssignRandomTextures()
    {
		foreach (Renderer renderer in renderers) {
			renderer.material.EnableKeyword("_MainTex");
			renderer.material.SetTexture("_MainTex", textures[Random.Range(0, textures.Length)]);
			yield return new WaitForEndOfFrame();
		}
		StartCoroutine("AssignRandomTextures");
	}
}
