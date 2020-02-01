using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TeleportTrigger : MonoBehaviour
{
	public GameObject teleportOrigin;
    
    void OnTriggerEnter( Collider other )
    {
    	var controller = other.GetComponent<FirstPersonController>();
    	StartCoroutine( TeleportCharacter( controller ) );
    }

    IEnumerator TeleportCharacter( FirstPersonController controller )
 	{
 
    	controller.enabled = false;
    	controller.transform.position = teleportOrigin.transform.position;
    	yield return new WaitForSeconds(0.05f);
    	controller.enabled = true; 
 	}
}
