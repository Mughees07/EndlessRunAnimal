using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Prime31;
using UnityEngine.Advertisements;
using Facebook.Unity;
using System;


public class MainMenuManager : SingeltonBase<MainMenuManager> {
	
	 Animator facebookAnim,twitterAnim;
	public GameObject MainMenuPanel, GameOverPanel,soundObject,RevivePanel,PausePanel,DogSelectionPanel,BoosterPanel,CoinsPanel,SettingsPanel;
	public GameObject Loading;
	 Sprite mute,sound;
	public GameObject musicStatePause, soundStatePause;
	public GameObject musicStateMainMenu,soundStateMainMenu;
	public GameObject RevivetotalCoins,PauseTotalCoins,DogSelectionTotalCoins,BoosterTotalCoins,CoinsPanelTotalCoins;

	public ReadyToGO readyToGo;
	public GameObject RatusEnjoy;
	public GameObject RatusDialog;
	public GameObject HUD;
	public GameObject UICamera;

	public GameObject PopUp;
	public GameObject rateStar;
	public Text PopUpText;
	public RectTransform facebook,twitter;

	bool hidden=true;
	GameObject dogs;
	public Texture2D cameraTexture;

	//public GameObject MainMenuBg;
	// Use this for initialization

	void Start () {
		//iTween.CameraFadeAdd(cameraTexture,200);
		CentralVariables.ResetGamePlay ();
		//DontDestroyOnLoad(this.gameObject);
		DontDestroyOnLoad(UICamera);
		facebookAnim = facebook.GetComponent<Animator> ();
		twitterAnim = twitter.GetComponent<Animator> ();
		FaddingMenu.Instance.FadeIn ();
		//FaddingMenu.Instance.FadeOut (1f);
		dogs = GameObject.FindGameObjectWithTag ("SelectionDogs");
		MenuHome ();
		//Advertisement.Initialize ("1192021");
		//GAManager.Instance.LogDesignEvent("MainMenu:StartGame");
		//gameOver ();
	}




	/// <summary>
	/// Menus the home.
	/// </summary>
	public void MenuHome () {
		MainMenuPanel.SetActive(true);
		//MainMenuBg.SetActive (true);
//		iTween.MoveTo ( MainMenuPanel, iTween.Hash(
//			"position", new Vector3 (0, 0, 0), 
//			"islocal", true, 
//			"delay", 0.3f,
//			"easetype",	iTween.EaseType.spring,
//			"time", 1.0f));


	}

	public void HomeReviveEvent()
	{
		Time.timeScale = 1;
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		Application.LoadLevel (0);
		MainMenuPanel.SetActive(true);
		RevivePanel.SetActive (false);
		SoundManager.Instance.playMainMenuSound();
	}
	
	/// <summary>
	/// Menu home hide.
	/// </summary>
	public void MenuHomeHide() {
		iTween.MoveTo ( MainMenuPanel, iTween.Hash(
			"position", new Vector3 (-956.5f, 0, 0), 
			"islocal", true, 
			"delay", 0.5f,
			"easetype",	iTween.EaseType.spring,
			"time", 1.0f));
	}
	
	/// <summary>
	/// Share menu toggle.
	/// </summary>

	

	/// <summary>
	/// Games the over.
	/// </summary>
	public void gameOver(bool findHud) {


		SoundManager.Instance.mute();
		GAManager.Instance.LogDesignEvent("GamePlay:GameOver");
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.LEVEL_FAIL);
		if (findHud) {
			HUD = GameObject.FindGameObjectWithTag ("Hud");
			HUD.transform.GetChild (0).gameObject.SetActive (false);
		}

		GameOverPanel.SetActive(true);
		GameOverPanel.GetComponent<GameOverManager> ().UpdateScore (false);
		GameOverPanel.GetComponent<GameOverManager> ().GameOverEnable ();

		//GetComponent<Config> ().signin ();
		
		iTween.MoveTo ( GameOverPanel, iTween.Hash(
			"position", new Vector3 (0, 0, 0), 
			"islocal", true, 
			"delay", 0.0f,
			"easetype",	iTween.EaseType.spring,
			"time", 1.0f));
		
	}

	/// <summary>
	/// Games the over home event.
	/// </summary>
	/// 
	/// 
	public void GameOverHomeEvent(){

		UnityAdsHelper.ShowAd (CentralVariables.VideoZoneId);
		Application.LoadLevel (0);
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		SoundManager.Instance.playMainMenuSound();
		//FaddingMenu.Instance.FadeIn ();

//		iTween.MoveTo ( GameOverPanel, iTween.Hash(
//			"position", new Vector3 (-956.5f, 0, 0), 
//			"islocal", true, 
//			"delay", 0.1f,//0.5
//			"easetype",	iTween.EaseType.spring,
//			"time", 0.1f));//1.0

		//iTween.FadeTo (GameOverPanel, iTween.Hash ("alpha", 0, "time", 1f, "delay", 2f, "easetype", "easeincubic", "oncomplete", "faded","oncompletetarget",gameObject));
		GAManager.Instance.LogDesignEvent("GameOver:Home");
		GameOverPanel.SetActive (false);
		MainMenuPanel.SetActive(true);

		//StartCoroutine(MoveFromGameOver(0.1f));//1.0
		//UnityAdsHelper.ShowAd (CentralVariables.VideoZoneId);
		//CentralVariables.videoAdRewardType = CentralVariables.VideoAdReward.GAMEOVERHOME;
		//CentralVariables.AdsCounter++;
		
	}

	public void faded()
	{
		GameOverPanel.SetActive (false);
		MainMenuPanel.SetActive(true);
	}

	public void GamePauseHomeEvent(){

		CentralVariables.isPaused = false;
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		SoundManager.Instance.playMainMenuSound ();
		//CentralVariables.isPaused = false;
		Time.timeScale = 1;
		Application.LoadLevel (0);
		PausePanel.SetActive(false);
		MainMenuPanel.SetActive (true);
		iTween.MoveTo ( MainMenuPanel, iTween.Hash(
			"position", new Vector3 (0, 0, 0), 
			"islocal", true, 
			"delay", 0.5f,
			"easetype",	iTween.EaseType.spring,
			"time", 1.0f));
		//StartCoroutine(MoveFromGameOver(1.0f));
	}


	IEnumerator MoveFromGameOver(float waitTime){
		yield return new WaitForSeconds(waitTime);

		MainMenuPanel.SetActive(true);
		iTween.MoveTo ( MainMenuPanel, iTween.Hash(
			"position", new Vector3 (0, 0, 0), 
			"islocal", true, 
			"delay", 0.0f,
			"easetype",	iTween.EaseType.spring,
			"time", 1.0f));
		
		//StartCoroutine(HomeScene(1.0f));
	}
	
	
	IEnumerator HomeScene(float waitTime){
		yield return new WaitForSeconds(waitTime);
		
	}



	public void RestartEvent(){

		//CentralVariables.GameOverCount++;
		GAManager.Instance.LogDesignEvent("GameOver:Retry");
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		//ResetData();

		iTween.MoveTo ( GameOverPanel, iTween.Hash(
			"position", new Vector3 (-956.5f, 0, 0), 
			"islocal", true, 
			"delay", 0.0f,
			"easetype",	iTween.EaseType.spring,
			"time", 1.0f));
		
		StartCoroutine(MenuGameOverHide(0.4f));
	}
	
	IEnumerator MenuGameOverHide(float waitTime) {
		
		yield return new WaitForSeconds(waitTime);
		GameOverPanel.SetActive(false);
		//Application.LoadLevel("Loading");
		CentralVariables.ResetGamePlay ();
		startLoadingGameplay ();
	}

	public void RestartEventRevive()
	{
		RevivePanel.SetActive (false);		
		//Application.LoadLevel("Loading");
		CentralVariables.ResetGamePlay ();
		startLoadingGameplay();
	}



	GameObject go;
	public void GamePauseEvent()
	{
		if (CentralVariables.IsRunning) {
			Time.timeScale = 0;
			SoundManager.Instance.mute ();
			GAManager.Instance.LogDesignEvent ("GamePlay:Pause");
			GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
			//if(go!=null)
			go = GameObject.FindGameObjectWithTag ("Hud").gameObject;
			go.SetActive (false);

			//SoundManager.Instance.mute();
			PauseTotalCoins.GetComponent<Text> ().text = "" + CentralVariables.PlayerTotalCoins;
			PausePanel.SetActive (true);
			loadStatePause();
			iTween.MoveTo (PausePanel, iTween.Hash (
				"position", new Vector3 (0, 0, 0), 
				"islocal", true, 
				"delay", 0.5f,
				"easetype",	iTween.EaseType.spring,
				"time", 1.0f));
			CentralVariables.isPaused = true;
		}

	}

	public void GameResumeEvent()
	{
		Time.timeScale = 1;
		CentralVariables.isPaused = false;
		PausePanel.SetActive(false);

		if(CentralVariables.isPlayMusic)
			SoundManager.Instance.unmute ();
		if (!readyToGo)
			readyToGo = GameObject.FindGameObjectWithTag ("ReadyToGO").GetComponent<ReadyToGO> ();
		Time.timeScale = 1;
		readyToGo.Go ();
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);

		if(go!=null)
		go.SetActive(true);

	}
	 
	public void PetsEvent()
	{
		//iTween.CameraFadeTo(1,2);
		//iTween.CameraFadeTo(0,2);
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		GAManager.Instance.LogDesignEvent("MainMenu:PetSelection");
		DogSelectionTotalCoins.GetComponent<Text> ().text = ""+CentralVariables.PlayerTotalCoins;
		DogSelectionPanel.SetActive (true);
		MainMenuPanel.SetActive (false);
		BoosterPanel.SetActive (false);
		CoinsPanel.SetActive (false);
	}

	public void BoostersEvent()
	{
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		GAManager.Instance.LogDesignEvent("MainMenu:BoosterUpgrade");
		BoosterTotalCoins.GetComponent<Text> ().text = ""+CentralVariables.PlayerTotalCoins;
		BoosterPanel.SetActive (true);
		MainMenuPanel.SetActive (false);
		DogSelectionPanel.SetActive (false);
		CoinsPanel.SetActive (false);
	}

	public void CoinsEvent()
	{
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		GAManager.Instance.LogDesignEvent("MainMenu:CoinsPurchase");
		CoinsPanelTotalCoins.GetComponent<Text> ().text = ""+CentralVariables.PlayerTotalCoins;
		BoosterPanel.SetActive (false);
		MainMenuPanel.SetActive (false);
		DogSelectionPanel.SetActive (false);
		CoinsPanel.SetActive (true);
	}

	public void CoinsPurchaseSuccess(int start , int end , int Price)
	{
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.DOUBLECOINSOUND);
		textCounterEffect (CoinsPanelTotalCoins.GetComponent<Text> (), start, end, Price, true);
		//GAManager.Instance.LogDesignEvent("MainMenu:CoinsPurchase");
		//CoinsPanelTotalCoins.GetComponent<Text> ().text = ""+CentralVariables.PlayerTotalCoins;
		BoosterPanel.SetActive (false);
		MainMenuPanel.SetActive (false);
		DogSelectionPanel.SetActive (false);
		CoinsPanel.SetActive (true);
	}

	public void SettingsEvent()
	{
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		SettingsPanel.SetActive (true);
		loadStateMainMenu ();
		//MainMenuPanel.SetActive (false);

	}

	public void GamePlayEvent(){
		GAManager.Instance.LogDesignEvent("MainMenu:Play");

		startLoadingGameplay ();
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		Time.timeScale = 1;
		//Application.LoadLevel ("Loading");
		MainMenuPanel.SetActive(false);
		DogSelectionPanel.SetActive (false);
		CentralVariables.ResetGamePlay();
		SoundManager.Instance.playGamePlaySound();
		GAManager.Instance.LogDesignEvent ("GamePlay:SelectedDog" + CentralVariables.currentSelectedDog);
	}

	#region BackPressed

	public void OnBackPressedSelectionMenu()
	{
		DogSelectionPanel.SetActive (false);
		MainMenuPanel.SetActive (true);
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		}

	public void OnBackPressedBoosterMenu()
	{
		BoosterPanel.SetActive (false);
		MainMenuPanel.SetActive (true);
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
	}

	public void OnBackPressedSettingsMenu()
	{
		SettingsPanel.SetActive (false);
		MainMenuPanel.SetActive (true);
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
	}

	public void OnBackPressedCoinPurchaseMenu()
	{
		CoinsPanel.SetActive (false);
		MainMenuPanel.SetActive (true);
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
	}
	#endregion

	/// <summary>
	/// Sound state.
	/// </summary>
	#region Links
	public void ShareMenuToggle() {

		GAManager.Instance.LogDesignEvent("MainMenu:Share");

//		FindObjectOfType<FacebookManager> ().Apprequest ("Hi", OGActionType.SEND , "", null, null, null,
//			delegate (IAppRequestResult result ) {
//				Debug.Log (result.RawResult);
//			});

		FB.Mobile.AppInvite(
			new Uri("https://fb.me/369553566806482"),
			new Uri("http://i.imgur.com/zkYlB.jpg"),
			delegate (IAppInviteResult result ) {
				Debug.Log (result.RawResult);
			}
		);
//		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
//		hidden = !hidden;		
//		Vector2 pos = facebook.anchoredPosition;
//		Vector2 pos1 = twitter.anchoredPosition;
//
//		if (hidden) {
//			pos.y += 100f;
//			pos1.y += 200f;
//			iTween.ValueTo(this.gameObject, iTween.Hash("from", facebook.anchoredPosition,"to", pos,"easetype", "Linear","time", 0.5f,"onupdate", "MoveFb"));
//			iTween.ValueTo(this.gameObject, iTween.Hash("from", twitter.anchoredPosition,"to", pos1,"easetype", "Linear","time", 0.5f,"delay",0.2f,"onupdate", "MoveTwitter"));
//		}			
//				
//		 else {
//			pos.y -= 100f;
//			pos1.y -= 200f;
//			iTween.ValueTo(this.gameObject, iTween.Hash("from", facebook.anchoredPosition,"to", pos,"easetype", "EaseOutBounce","time", 0.5f,"onupdate", "MoveFb"));
//			iTween.ValueTo(this.gameObject, iTween.Hash("from", twitter.anchoredPosition,"to", pos1,"easetype", "EaseOutBounce","time", 0.5f,"delay",0.2f,"onupdate", "MoveTwitter"));
//
//			//iTween.MoveFrom (facebook, iTween.Hash ("position", pos, "easetype", "linear", "time", 0.5f));
//			//iTween.MoveFrom (twitter, iTween.Hash ("position", pos1, "easetype", "linear", "delay", 0.3f, "time", 0.5f));
//				}
		}

		//facebookAnim.SetBool ("isDown", !hidden);s
		//twitterAnim.SetBool("isDown",!hidden);
		//facebook.SetActive (!hidden);
		//twitter.SetActive (!hidden);



		void MoveFb(Vector2 pos)
		{
		facebook.anchoredPosition = pos;

		}
	void MoveTwitter(Vector2 pos)
	{
		twitter.anchoredPosition = pos;

	}

	public void FacebookShare(){
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
//		GameManager.Instance.fbShareLinkCustom();
		Application.OpenURL ("https://www.facebook.com");
	}

	public void TwitterShare(){
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
//		GameManager.Instance.postOnTwitter();
		Application.OpenURL ("https://twitter.com");
	}

	public void ShowLeaderBoard(){
		//Debug.Log("Yes I am Leaderboard");
		GAManager.Instance.LogDesignEvent("MainMenu:Leaderboard");
		//GetComponent<Config> ().ShowLeaderBoard();
		FindObjectOfType<LeaderboardManager>().OnShowLeaderBoard();
	}

	public void UpdateScore(){
		//Debug.Log("Yes I am Leaderboard");
		GAManager.Instance.LogDesignEvent("MainMenu:UpdateScore" +
			"");
		//GetComponent<Config> ().signin();

		//		GCManager.Instance.ShowLeaderboards();
	}

	public void MoreGames()
	{
		GAManager.Instance.LogDesignEvent("MainMenu:MoreGames");
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		Application.OpenURL (Constants.MOREGAMES_LINK);
	}

	#endregion

	#region RateUs

	public void OnRateUsClick()
	{
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		Application.OpenURL (CentralVariables.Android_RateUsLink);
		GAManager.Instance.LogDesignEvent("MainMenu:RateUs");
		MainMenuManager.Instance.RatusDialog.SetActive (false);
		CentralVariables.rateUsBool = false;
		CentralVariables.SaveToFile();
	}

	public void OnRateUsClickStar(int index)
	{
		

		for (int i = 1; i < rateStar.transform.childCount; i++) {
		
			if (i <= index)
				rateStar.transform.GetChild (i).gameObject.SetActive (true);
				
		}	
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);

		GAManager.Instance.LogDesignEvent("MainMenu:RateUs");
		CentralVariables.rateUsBool = false;
		CentralVariables.SaveToFile();
		Invoke ("rateUsRedirect", 0.5f);
	}

	public void rateUsRedirect()
	{
		Application.OpenURL (CentralVariables.Android_RateUsLink);
		MainMenuManager.Instance.RatusDialog.SetActive (false);

	}
	public void RateUsYesClicked()
	{
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		MainMenuManager.Instance.RatusEnjoy.SetActive (false);
		MainMenuManager.Instance.RatusDialog.SetActive (true);
		GAManager.Instance.LogDesignEvent("MainMenu:RateUsYes");
	}



	public void RateUsNo()
	{
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		MainMenuManager.Instance.RatusEnjoy.SetActive (false);
		CentralVariables.rateUsBool = false;
		CentralVariables.SaveToFile();
		//MainMenuManager.Instance.RatusDialog.SetActive (false);
		//MainMenuManager.Instance.GameOverPanel.SetActive (true);
		//MainMenuManager.Instance.MainMenuPanel.SetActive (true);
		GAManager.Instance.LogDesignEvent("MainMenu:RateUsNo");

	}

	public void RateUsLater()
	{
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		//MainMenuManager.Instance.RatusEnjoy.SetActive (false);
		MainMenuManager.Instance.RatusDialog.SetActive (false);
		//MainMenuManager.Instance.GameOverPanel.SetActive (true);
		//MainMenuManager.Instance.MainMenuPanel.SetActive (true);
		GAManager.Instance.LogDesignEvent("MainMenu:RateUsLater");

	}
	#endregion

	#region revive
	public void showReviveMenu(){

		GAManager.Instance.LogDesignEvent("GamePlay:Revive");
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		HUD = GameObject.FindGameObjectWithTag ("Hud");
		HUD.SetActive(false);
		//Time.timeScale = 0.01f;
		RevivePanel.SetActive (true);
		RevivetotalCoins.GetComponent<Text> ().text = ""+CentralVariables.PlayerTotalCoins;
		iTween.MoveTo ( RevivePanel, iTween.Hash(
			"position", new Vector3 (0, 0, 0), 
			"islocal", true, 
			"delay", 0.3f,
			"easetype",	iTween.EaseType.spring,
			"time", 1.0f));
		//CentralVariables.PlayerTotalCoins = 1000;
		//UserPrefs.Save ();


	}

	public void skipReviveMenu(){
		iTween.MoveTo ( RevivePanel, iTween.Hash(
			"position", new Vector3 (-844,0, 0), 
			"islocal", true, 
			"delay", 0.3f,
			"easetype",	iTween.EaseType.spring,
			"time", 1.0f));
		StartCoroutine(OnReviveSkip(1));

	}

	IEnumerator OnReviveSkip(float waitTime){
		yield return new WaitForSeconds(waitTime);
		RevivePanel.SetActive (false);


	}

	#endregion


	#region SoundControl

	public void SoundOnOffPause()
	{
		CentralVariables.isPlaySound = !CentralVariables.isPlaySound;
		soundStatePause.transform.GetChild (0).gameObject.SetActive (CentralVariables.isPlaySound);
		soundStatePause.transform.GetChild (1).gameObject.SetActive (!CentralVariables.isPlaySound);

		CentralVariables.SaveToFile ();
	}

	public void MusicOnOffPause()
	{	

		CentralVariables.isPlayMusic = !CentralVariables.isPlayMusic;
		SoundManager.Instance.bgMusicMute (CentralVariables.isPlayMusic);
		musicStatePause.transform.GetChild (0).gameObject.SetActive (CentralVariables.isPlayMusic);
		musicStatePause.transform.GetChild (1).gameObject.SetActive (!CentralVariables.isPlayMusic);
		CentralVariables.SaveToFile ();
	}

	public void loadStatePause()
	{
		soundStatePause.transform.GetChild (0).gameObject.SetActive (CentralVariables.isPlaySound);
		soundStatePause.transform.GetChild (1).gameObject.SetActive (!CentralVariables.isPlaySound);
		musicStatePause.transform.GetChild (0).gameObject.SetActive (CentralVariables.isPlayMusic);
		musicStatePause.transform.GetChild (1).gameObject.SetActive (!CentralVariables.isPlayMusic);
	}

	public void SoundOnOffMainMenu()
	{
		CentralVariables.isPlaySound = !CentralVariables.isPlaySound;
		soundStateMainMenu.transform.GetChild (0).gameObject.SetActive (CentralVariables.isPlaySound);
		soundStateMainMenu.transform.GetChild (1).gameObject.SetActive (!CentralVariables.isPlaySound);

		CentralVariables.SaveToFile ();
	}

	public void MusicOnOffMainMenu()
	{


		CentralVariables.isPlayMusic = !CentralVariables.isPlayMusic;
		SoundManager.Instance.bgMusicMute (CentralVariables.isPlayMusic);
		musicStateMainMenu.transform.GetChild (0).gameObject.SetActive (CentralVariables.isPlayMusic);
		musicStateMainMenu.transform.GetChild (1).gameObject.SetActive (!CentralVariables.isPlayMusic);
		CentralVariables.SaveToFile ();
	}

	public void loadStateMainMenu()
	{
		soundStateMainMenu.transform.GetChild (0).gameObject.SetActive (CentralVariables.isPlaySound);
		soundStateMainMenu.transform.GetChild (1).gameObject.SetActive (!CentralVariables.isPlaySound);
		musicStateMainMenu.transform.GetChild (0).gameObject.SetActive (CentralVariables.isPlayMusic);
		musicStateMainMenu.transform.GetChild (1).gameObject.SetActive (!CentralVariables.isPlayMusic);
	}

	#endregion


	public void FreeCoins()
	{
		float price = CentralVariables.FreeCoinsValue;
		GAManager.Instance.LogResourceEvent (false, "coins",price , "FreeVideo", "FreeVideo");
		CentralVariables.videoAdRewardType = CentralVariables.VideoAdReward.FREE_COINS;
		UnityAdsHelper.ShowAd (CentralVariables.RewardedZoneId);
		//MainMenuManager.Instance.MainMenuPanel.SetActive (true);
		//MainMenuManager.Instance.DogSelectionPanel.SetActive (false);
		//MainMenuManager.Instance.BoosterPanel.SetActive(false);

	}


	public void ShowPopUp(string txt)
	{
		if (!dogs) 
			dogs = GameObject.FindGameObjectWithTag ("SelectionDogs");

		
		if(dogs)
			dogs.SetActive (false);
		
		PopUp.transform.parent.gameObject.SetActive (true);
		PopUpText.text = txt;
		PopUp.GetComponent<Animator> ().SetBool ("play", true);

		//Invoke ("waitPopUp", 1.5f);
		StartCoroutine (waitPopUp ());
	}

	public IEnumerator waitPopUp()
	{
		yield return new WaitForSeconds (1.5f);
		if (!dogs) 
			dogs = GameObject.FindGameObjectWithTag ("SelectionDogs");
		if(dogs)
			dogs.SetActive (true);
		
		PopUp.transform.parent.gameObject.SetActive (false);
		PopUp.GetComponent<Animator> ().SetBool ("play", false);
		//PopUp.GetComponent<Animator> ().SetBool ("play", false);
	}

	public void FreeVideoCoins()
	{
		GameManager.Instance.ChangeSoundState(GameManager.SoundState.DOUBLECOINSOUND);

		MainMenuManager.Instance.textCounterEffect 
			(RevivetotalCoins.GetComponent<Text> (), CentralVariables.PlayerTotalCoins, CentralVariables.PlayerTotalCoins+CentralVariables.FreeCoinsValue,300, true);

			MainMenuManager.Instance.textCounterEffect
			(BoosterTotalCoins.GetComponent<Text> (), CentralVariables.PlayerTotalCoins, CentralVariables.PlayerTotalCoins+CentralVariables.FreeCoinsValue,300, true);

			MainMenuManager.Instance.textCounterEffect 
			(DogSelectionTotalCoins.GetComponent<Text> (), CentralVariables.PlayerTotalCoins, CentralVariables.PlayerTotalCoins+CentralVariables.FreeCoinsValue,300, true);

			MainMenuManager.Instance.textCounterEffect 
			(CoinsPanelTotalCoins.GetComponent<Text> (), CentralVariables.PlayerTotalCoins, CentralVariables.PlayerTotalCoins+CentralVariables.FreeCoinsValue,300, true);



		CentralVariables.PlayerTotalCoins += CentralVariables.FreeCoinsValue;
		CentralVariables.SaveToFile ();
//		RevivetotalCoins.GetComponent<Text> ().text = ""+CentralVariables.PlayerTotalCoins;
//		BoosterTotalCoins.GetComponent<Text> ().text = ""+CentralVariables.PlayerTotalCoins;
//		//PauseTotalCoins.GetComponent<Text> ().text = ""+CentralVariables.PlayerTotalCoins;
//		DogSelectionTotalCoins.GetComponent<Text> ().text = ""+CentralVariables.PlayerTotalCoins;
//		CoinsPanelTotalCoins.GetComponent<Text> ().text = ""+CentralVariables.PlayerTotalCoins;
		ShowPopUp ("Coins Added");
	}

	public void DoubleItGameOver()
	{
		CentralVariables.videoAdRewardType = CentralVariables.VideoAdReward.DOUBLEIT;
		UnityAdsHelper.ShowAd (CentralVariables.RewardedZoneId);

	}

	public void gameOverDouble() {	
		//GameOverPanel.SetActive(true);
		GameOverPanel.GetComponent<GameOverManager> ().UpdateScore(true);


	}

	#region Loading 
	AsyncOperation async;

	public void startLoadingGameplay()
	{
		Loading.SetActive (true);
		StartCoroutine(showLoading ());
	}
	public IEnumerator showLoading()
	{
		
		GAManager.Instance.LogDesignEvent("GamePlay:Loading");
		async = Application.LoadLevelAsync("GamePlay");
		yield return async;

	}

	#endregion

	#region TextCounter

	public void  textCounterEffect(Text t, int start, int end , int Value,bool increase)
	{
		Value = Value / 100;
		StartCoroutine(textChangeEffect(t,start,end,Value,increase));
	}

	IEnumerator textChangeEffect(Text t, int start, int end , int Value,bool increase)
	{

		while (start != end) {

			if (increase)
				start+=Value;
			else
				start-=Value;

			t.text = "" + start;
		
			yield return new WaitForSeconds (0.01f);
		
		}

	}

	#endregion
}
