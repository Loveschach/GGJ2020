using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    void OnTriggerEnter( Collider other )
    {
    	Level level = GameObject.Find( "Level" ).GetComponent<Level>();
    	level.complete = true;
    }
}
