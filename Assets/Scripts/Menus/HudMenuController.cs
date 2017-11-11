using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudMenuController : MonoBehaviour {

	public GameObject PauseMenu;

	public GameObject TextScore;


	public void BUTTON_Pause()
	{

		Time.timeScale = 0f;
		CentralVariables.GamePauseBool = true;
		PauseMenu.SetActive (true);
	}

	void LateUpdate()
	{
		if (CentralVariables.PlayerScore < 10 && CentralVariables.PlayerScore!=0) {
			TextScore.GetComponent<Text> ().text = "0"+CentralVariables.PlayerScore ;
		}
		else
		TextScore.GetComponent<Text>().text = CentralVariables.PlayerScore + "";
	}


	void OnEnable () {
	

	}
	
	void OnDisable () {
		//GameManager.Instance.ChangeState (GameManager.Instance.GetPreviousGameState()); 
	}


}
