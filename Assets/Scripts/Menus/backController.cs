using UnityEngine;
using System.Collections;

public class backController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape)) {
			
			
		
				MainMenuManager.Instance.MainMenuPanel.SetActive (true);
				MainMenuManager.Instance.SettingsPanel.SetActive (false);
				MainMenuManager.Instance.DogSelectionPanel.SetActive (false);
				MainMenuManager.Instance.BoosterPanel.SetActive (false);
				MainMenuManager.Instance.CoinsPanel.SetActive (false);
			
			
		}

	}
}
