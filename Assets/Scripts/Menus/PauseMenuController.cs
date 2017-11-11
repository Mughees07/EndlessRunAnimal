using UnityEngine;
using System.Collections;

public class PauseMenuController : MonoBehaviour {


	void OnEnable () {



	}
	
	void OnDisable () {
		//GameManager.Instance.ChangeState (GameManager.Instance.GetPreviousGameState()); 
	}


	public void ButtonHome()
	{

//		GameManager.Instance.playBgMusic (true, false, SoundManager.MUSIC_TYPE_LEVEL_1);
		Application.LoadLevel ("MainMenu");
		MainMenuManager.Instance.MenuHome();

		Time.timeScale = 1f;
		StartCoroutine (BackToHome (0.2f));


	}
	IEnumerator BackToHome(float wait){
		yield return new WaitForSeconds (wait);
		this.gameObject.SetActive (false);

	}

	/// <summary>
	/// Resume Button.
	/// </summary>
	public void ButtonPlayAgain() 
	{
	
//		GameManager.Instance.playBgMusic (true, false, SoundManager.MUSIC_TYPE_LEVEL_1);
		CentralVariables.GamePauseBool = false;
		this.gameObject.SetActive (false);
		Time.timeScale = 1f;
	}

}
