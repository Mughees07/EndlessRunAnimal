using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Revive : MonoBehaviour {

	// Use this for initialization

	PlayerMovement PlayerMove;
	GameObject player;
	public Text timerText;
	public Text reviveValue;
	int time;


	void OnEnable () {
		PlayerMove=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		//PlayerMove = player.GetComponent<PlayerMovement> ();
		time = 10;
		reviveValue.GetComponent<Text> ().text = "" + CentralVariables.reviveValue;
		//Time.timeScale = 1;
		if(CentralVariables.isDead)
			StartCoroutine (CountDown());
		//InvokeRepeating ("CountDown", 1.0f, 1.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReviveWithCoins()
	{
		GAManager.Instance.LogDesignEvent("GamePlay:ReviveWithCoins");
		//CentralVariables.reviveIncrementValue *= CentralVariables.reviveCount;
		//CentralVariables.reviveValue += CentralVariables.reviveIncrementValue;
		CentralVariables.PlayerTotalCoins -= CentralVariables.reviveValue;

		//MainMenuManager.Instance.RevivePanel.SetActive (false);
		//MainMenuManager.Instance.HUD.SetActive(true);
		//Time.timeScale = 1f;
		//GameObject.FindGameObjectWithTag("Hud").transform.GetChild(0).gameObject.SetActive(true);

		CentralVariables.ReviveGamePlay();
		//CentralVariables.reviveCount++;
		//CentralVariables.reviveIncrementValue *=2;
		CentralVariables.reviveValue *=2;
		PlayerMove.RevivePlayer ();
		iTween.FadeTo (gameObject, iTween.Hash ("alpha", 0, "time", .6, "delay", 0.2f, "easetype", "easeincubic", "oncomplete", "faded"));
		CentralVariables.IsRunning = true;	

	}
	public void faded()
	{
		MainMenuManager.Instance.RevivePanel.SetActive (false);
		MainMenuManager.Instance.HUD.SetActive(true);
	}
	public void ReviveWithAd()
	{
		GAManager.Instance.LogDesignEvent("GamePlay:ReviveWithAd");
		CentralVariables.videoAdRewardType = CentralVariables.VideoAdReward.REVIVE;
		UnityAdsHelper.ShowAd (CentralVariables.RewardedZoneId);
		CentralVariables.IsRunning = true;
	}


	IEnumerator CountDown()
	{
		for (int i = 0; i <= 10; i++) {
			timerText.GetComponent<Text> ().text = "" + time;
			time--;
			GameManager.Instance.ChangeSoundState (GameManager.SoundState.TIMER);
			yield return new WaitForSeconds (1f);

		}
		MainMenuManager.Instance.gameOver (false);
			this.gameObject.SetActive (false);


		//Debug.Log ("outside" + time);
		//yield return null;
	}



}
