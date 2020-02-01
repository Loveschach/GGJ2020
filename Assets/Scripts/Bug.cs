using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour {
	public bool logged = false;
	public int ID;
	// Start is called before the first frame update
	void Start() {
		logged = SaveSystem.GetLogged( ID );
	}

	public void SetLogged( bool logged ) {
		this.logged = logged;
	}
}
