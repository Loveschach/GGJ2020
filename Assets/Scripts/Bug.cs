using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour {
	bool bugFixed = false;
	public int ID;
	// Start is called before the first frame update
	void Start() {

	}

	public void SetBugFixed( bool bugFixed ) {
		this.bugFixed = bugFixed;
	}
}
