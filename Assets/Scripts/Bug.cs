using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour {
	public enum LogStatus
	{
		Future,
		Undiscovered,
		Assigned,
		InProgress,
		Fixed,
		NotFixed
	}
	public bool logged = false;
	public LogStatus status = LogStatus.Future;
	public int buildIntroduced = 0; // one build per day
	public int ID;
	// Start is called before the first frame update
	void Start() {
		logged = SaveSystem.GetLogged( ID );
	}

	public void SetLogged( bool logged ) {
		this.logged = logged;
	}
}
