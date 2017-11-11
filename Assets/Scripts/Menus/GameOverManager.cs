//<<<<<<< .mine
//﻿using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using ChartboostSDK;

public class GameOverManager : MonoBehaviour {
	public Animator contentPanel;

	public Text TextTotalScore;
	public Text TextDistance;
	public Text TextCoins;

	public GameObject doubeit;
	//public Text TextReward;

	bool update=false;



	void OnEnable()
	{
		


	
	}

	public void GameOverEnable()
	{

		GAManager.Instance.LogDesignEvent("GameOver");
		doubeit.SetActive (true);

		//Chartboost.showInterstitial(CBLocation.GameOver);
		//Time.timeScale = 0;

		if(!CentralVariables.hasShowedInterstitial){
			if (CentralVariables.GameOverCount % 2 == 1) {
				//Tapdaq.ShowInterstitial ();

				CentralVariables.hasShowedInterstitial = true;
			}
		}	

		if (CentralVariables.rateUsBool) {
			if (CentralVariables.GameOverCount!=0 && CentralVariables.GameOverCount % 2 == 0) {
				//show Ratus
				MainMenuManager.Instance.RatusEnjoy.SetActive(true);
			}
			CentralVariables.GameOverCount++;
		}
	}

	void Start()
	{

	
	}
	int coins;

	public void UpdateScore(bool Double)
	{
		if(CentralVariables.PlayerCurrentCoins < 0)
		{
			CentralVariables.PlayerCurrentCoins *= -1;
		}

		if (Double) {
			TextTotalScore.text = CentralVariables.PlayerScore + "";
			CentralVariables.PlayerTotalCoins += CentralVariables.PlayerScore/2;
			doubeit.SetActive (false);
		}

		else
		{

		TextDistance.text = CentralVariables.PlayerCurrentDistance +"m";
		TextCoins.text =      CentralVariables.PlayerCurrentCoins  +"";

		int bonuscoins = CentralVariables.PlayerCurrentDistance / 5;
		CentralVariables.PlayerScore= CentralVariables.PlayerCurrentCoins + bonuscoins;

		CentralVariables.PlayerScore *= (int)CentralVariables.finalScoreMultiplier;
		//Debug.Log("bonus: "+ CentralVariables.CoinsCount);
		TextTotalScore.text = CentralVariables.PlayerScore+"";

		CentralVariables.PlayerTotalCoins += CentralVariables.PlayerScore;
		CentralVariables.SaveToFile ();

			FindObjectOfType<LeaderboardManager> ().OnAddScoreToLeaderBorad ();
		float price = CentralVariables.PlayerScore;
		GAManager.Instance.LogResourceEvent (false, "coins",price , "EarnedCoins", "EarnedCoins");
		}


	}


	public void ShareMenuToggle() {

		int isHidden = contentPanel.GetInteger("SlideValue");

		if(isHidden == 1) {
			contentPanel.SetInteger("SlideValue", 2);

		} else {
			contentPanel.SetInteger("SlideValue", 1);
		}

	}

	public void videoRewardButton(){

		Debug.LogError ("Called::");
		CentralVariables.DoubleCoins = true;
		//unityAds
		//UnityAdsManager.Instance.ShowRewardedVideoAd ();
	}

	void Update()
	{
		//TextTotalCoins.text = CentralVariables.CoinsCount + "";

	}
}

