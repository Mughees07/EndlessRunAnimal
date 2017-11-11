using UnityEngine;
using System.Collections;

public class backControllerPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape)) {		

//				MainMenuManager.Instance.PausePanel.SetActive (true);
//				CentralVariables.isPaused = true;
//				Time.timeScale = 0;
			
			if (CentralVariables.isPaused) {

				MainMenuManager.Instance.GameResumeEvent ();

			} else if (CentralVariables.IsRunning) {

				MainMenuManager.Instance.GamePauseEvent ();
			}
			
			
		}

	}
}
