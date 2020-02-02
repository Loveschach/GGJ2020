using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
	public CharacterController playerController;
	public bool complete = false;

    // Start is called before the first frame update
    void Start()
    {
        // Log enemy positions
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( "r" ) )
        	Reset();
    }

    public void Reset( bool playerDied = false )
    {
    	complete = false;
    }
}
