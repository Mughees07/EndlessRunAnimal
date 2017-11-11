using UnityEngine;
using System.Collections;

public class GameOverPanelScript : MonoBehaviour {

	void Start()
	{


	}

	void OnEnable () {

//		GCManager.Instance.PostToLeaderboard ();

		GameManager.Instance.ChangeSoundState (GameManager.SoundState.LEVEL_FAIL);

	}
	
	void OnDisable () {

	}
}
