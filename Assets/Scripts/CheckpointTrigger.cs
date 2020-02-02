using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
	public GameObject checkpointOrigin;
	public Vector3 checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        checkpoint = checkpointOrigin.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
