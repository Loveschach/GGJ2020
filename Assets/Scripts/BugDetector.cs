using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BugDetector : MonoBehaviour
{
	[SerializeField]
	Shader bugShader; // Make sure object has this material before trying to operate on it
	Transform camTrans;

	// Used to unhighlight when we're not pointing at it anymore
	Bug lastBug;

	// Used to slow down player while in detective mode
	[SerializeField]
	float slowedSpeed = 0.5f;
	FirstPersonController player;
	float originalWalkSpeed = 0;
	float originalRunSpeed = 0;

	void Start()
	{
		camTrans = Camera.main.transform;
		player = GetComponent<FirstPersonController>();
		originalWalkSpeed = player.m_WalkSpeed;
		originalRunSpeed = player.m_RunSpeed;

		// Warn if multiple bugs have the same ID
		Bug[] bugs = FindObjectsOfType<Bug>();
		foreach (Bug bug1 in bugs) {
			foreach (Bug bug2 in bugs) {
				if (bug1 != bug2 && bug1.ID == bug2.ID) {
					Debug.LogError(string.Format("{0} and {1} share the same ID. Saving/loading bug state will have issues.", bug1, bug2));
				}
			}
		}
	}

	void ClearLastHighlight()
	{
		if (lastBug != null)
		{
			lastBug.ClearHighlight();
			lastBug = null;
		}
	}

	void DetectiveModeUpdate() {
		RaycastHit hit;
		// Does the ray intersect any buggable objects?
		if (Physics.Raycast(camTrans.position, camTrans.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) {
			Bug bug = hit.collider.GetComponentInParent<Bug>();
			if (bug != null && !bug.logged) {
				// If it's different, unhighlight the last thing, and highlight this thing
				if (lastBug != bug) {
					ClearLastHighlight();
					bug.SetHighlight();
					lastBug = bug;
				}

				//Left mouse or Q... my laptop wouldn't let me click both left and right mouse buttons at once.
				if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Q)) {
					bug.SetLogged(true);
				}
			}
			else {
				ClearLastHighlight();
			}
		}
		else {
			ClearLastHighlight();
		}
	}

	void Update() {

		//Exit Detective mode
		if (Input.GetMouseButtonUp(1)) {
			player.m_WalkSpeed = originalWalkSpeed;
			player.m_RunSpeed = originalRunSpeed;
			ClearLastHighlight();
		}
		//Enter Detective mode
		else if (Input.GetMouseButtonDown(1)) {
			player.m_WalkSpeed = slowedSpeed;
			player.m_RunSpeed = slowedSpeed;
		}
		//Update Detective mode
		if (Input.GetMouseButton(1)) {
			DetectiveModeUpdate();
		}
	}
}
