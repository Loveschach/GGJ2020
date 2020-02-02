using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
	public Text winScreen;

    void OnTriggerEnter( Collider other )
    {
    	Level level = GameObject.Find( "Level" ).GetComponent<Level>();
    	level.complete = true;
    	SetAlpha( winScreen, 1 );

    }

    void SetAlpha( Text screen, float alpha )
    {
    	screen.color = new Color( screen.color.r, screen.color.g, screen.color.b, alpha );
    }
}
