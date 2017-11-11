using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using Prime31;
using UnityEngine.SocialPlatforms;

public class GameManager : SingeltonBase<GameManager> {

	private GameState previousGameState;
	private GameState currentGameState;
	private int RateUsCount = 0;
	GameObject popup;
	private SoundState currentSoundState;



	public enum GameDebug
	{
		ON,
		OFF
	}

	public enum DebugType
	{
		LOG,
		ERROR,
		WARNING
	}

	public GameDebug gameLog;



	#region GameDebugSystem
	public void Print(string text,DebugType type)
	{
		if(gameLog.Equals(GameDebug.ON))
		{
			switch(type)
			{
			case DebugType.LOG:
				Debug.Log(text);
				break;
			case DebugType.ERROR:
				Debug.LogError(text);
				break;
			case DebugType.WARNING:
				Debug.LogWarning(text);
				break;
			}
		}
	}
	#endregion





	public enum GameState { 

		SPLASH,
		MAIN_MENU,
		DOG_SELECT_MENU,
		LOADING,
		GAME_PLAY,
		SETTINGS,
		LEADERBOARD,
		ACHIEVEMENT,
		RATE_US,
		PAUSE,
		REVIVE,
		GAMEOVER

	};

	public enum SoundState { 

		STUMBLE_SOUND,
		JUMP_SOUND,
		SLIDESOUND,
		LEVEL_SUCCESS,
		LEVEL_FAIL,
		COINCOLLECTSOUND,
		CountDown,
		CLICKSOUND,
		REVIVESOUND,
		MAGNETSOUND,
		 STEALTHSOUND,
		 DOUBLECOINSOUND,
		 SPEEDSOUND,
		BARK,
		HIT,
		GO,
		TIMER,
		GLASSBREAK,
	};

	// Use this for initialization
	void Start () {

		Application.targetFrameRate = 60;
		//UserPrefs.Load ();
		#if UNITY_IPHONE
		TwitterBinding.init("YfDeqRuAyp1mnEBw5ylQglxh5", "TAY9B9duKQfTrCB4eWoe8ArbnDIfEQ36dZQLQKpmlNWuJEi2IW");
		
		FacebookBinding.init();
		#endif
		
		#if UNITY_ANDROID
		//TwitterAndroid.init( "YfDeqRuAyp1mnEBw5ylQglxh5", "TAY9B9duKQfTrCB4eWoe8ArbnDIfEQ36dZQLQKpmlNWuJEi2IW" );
		#endif


	}

	// Update is called once per frame
	void Update () {
		
	}



	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable(){



		#if UNITY_IPHONE
		#endif
	}

	/// <summary>
	/// Raises the disable event.
	/// </summary>
	void OnDisable(){

		#if UNITY_IPHONE
		#endif

	}

	/// <summary>
	/// Gets the state of the sound.
	/// </summary>
	/// <returns>The sound state.</returns>
	public SoundState GetSoundState() {
		return currentSoundState;
	}

	/// <summary>
	/// Sets the state of the sound.
	/// </summary>
	/// <param name="state">State.</param>
	public void SetSoundState(SoundState state) {
		currentSoundState = state;
	}

	/// <summary>
	/// Changes the state of the sound.
	/// </summary>
	/// <param name="soundState">Sound state.</param>
	public void ChangeSoundState (SoundState soundState) {
		SetSoundState(soundState);
		SoundManager.Instance.PlaySound();
	}

	public void ChangeSoundState (SoundState soundState,float pExtraDelay, SoundManager.AudioCallback callback ) {
		SetSoundState(soundState);
		SoundManager.Instance.PlaySoundWithCallback(pExtraDelay, callback);
	}





	
	#region StateHandler

	/// <summary>
	/// Gets the state of the current game.
	/// </summary>
	/// <returns>The current game state.</returns>
	public GameState GetCurrentGameState() {
		return currentGameState;
	}

	/// <summary>
	/// Gets the state of the previous game.
	/// </summary>
	/// <returns>The previous game state.</returns>
	public GameState GetPreviousGameState() {
		return previousGameState;
	}

	/// <summary>
	/// Sets the state of the previous game.
	/// </summary>
	/// <param name="state">State.</param>
	public void SetPreviousGameState(GameState state) {
		previousGameState=state;
	}

	/// <summary>
	/// Sets the state of the game.
	/// </summary>
	/// <param name="state">State.</param>
	private void SetGameState(GameState state) {
		previousGameState = currentGameState;
		currentGameState = state;
	}

	/// <summary>
	/// Changes the state.
	/// </summary>
	/// <param name="state">State.</param>
	public void ChangeState (GameState state) {
		
		SetGameState(state);

//		switch(currentGameState){
//		case GameState.SPLASH:
//			break;
//		case GameState.MAIN_MENU:
//			break;
//		case GameState.GAME_PLAY:
//			break;
//		case GameState.SETTINGS:
//			break;
//		case GameState.LEADERBOARD:
//			break;
//		case GameState.ACHIEVEMENT:
//			break;
//		case GameState.RATE_US:
//			break;
//		case GameState.:
		


			//AdsManager.Instance.showIntersitialAds();
			//
//			Debug.Log("coming");
//			if (CentralVariables.AdsCount % 3 == 0) {
//				Debug.Log ("OVER");
//				UnityAdsManager.Instance.ShowVideoAd ();
//				CentralVariables.AdsCount++;
//			} 
//			else if (CentralVariables.AdsCount % 2 == 0) {
//				Tapdaq.ShowInterstitial ();
//				CentralVariables.AdsCount++;
//			}
//			break;
//	
//			
//		}

	}

	/// <summary>
	/// Changes the sound.
	/// </summary>
	/// <param name="isMute">If set to <c>true</c> is mute.</param>
	private void changeSound(bool isMute){
		//Implementation Changed @@Deprecated
		if(isMute) {

		} else {

		}
	}
		
	#endregion



	#region Achievements
	
	/// <summary>
	/// Locked Achievement.
	/// </summary>
	/// <param name="achieveID">Achieve ID.</param>

	#endregion
	
	/// <summary>
	/// Posts the on facebook.
	/// </summary>

	#region TwitterEvents

	/// <summary>
	/// Posts the on twitter.
	/// </summary>
	public void postOnTwitter() {

		#if UNITY_IPHONE

		//			if (TwitterBinding.isTweetSheetSupported()){
		//				string text = this.getSharingText();
		//			TwitterBinding.showTweetComposer(text,null,RotatioConstants.APP_LINK);
		//			} else {
		//				Debug.Log("TweetSheet not supported");
		//			}

		#endif

		#if UNITY_ANDROID
		//			if(TwitterAndroid.isLoggedIn()) {
		//				createTweet ();
		//			} else {
		//				TwitterAndroid.showLoginDialog();
		//			}

		#endif
	}

	/// <summary>
	/// Gets the sharing text.
	/// </summary>
	/// <returns>The sharing text.</returns>
	public string getSharingText() {
		return "";
//		return CentralVariables.getShareText ();
	}

	/// <summary>
	/// Creates the tweet.
	/// </summary>
	private void createTweet() {

		#if UNITY_ANDROID

		//		GameObject popUp = GameObject.Instantiate(Resources.Load("Prefabs/TwitterDialog")) as GameObject;
		//		popUp.GetComponent<TweetDialogScript>().setText(text + " " + RotatioConstants.appLink());
		//			string text = this.getSharingText();
		//			TwitterAndroid.postStatusUpdate(text + " " + CentralVariables.appLink());

		#endif
	}
	/// <summary>
	/// Shows the IAP pop U.
	/// </summary>
	/// <param name="pMsg">P message.</param>
	private void showIAPPopUP(string pMsg) {
		//: Show popup for Success
		if (popup != null) {
			Destroy(popup);
		}
		//		
		Debug.Log("Yes I am running");
		//GameObject.Find("InAppPanel").SetActive(true);
		popup = GameObject.Instantiate(Resources.Load ("Animations/InAppPanel")) as GameObject;
		popup.SetActive(true);
		//		IAPPopup iAPPopup = popup.GetComponentInChildren <IAPPopup> ();
		//		iAPPopup.textMsg.text = ""+pMsg;
	}
	/// <summary>
	/// Shows the refreshed value.
	/// </summary>
	public void showRefreshedValue() {

	}


	void loginSucceeded( string username ) {
		Debug.Log( "Local Methods: Successfully logged in to Twitter: " + username );
		createTweet ();
	}


	public void PurchaseProductResult(string package, bool result) 
	{
		Debug.Log("purchase prodcut result " + result );

		if (result) 
		{
			for (int i = 0; i < CentralVariables.InAppPackages.Length; i++) {
				if (package == CentralVariables.InAppPackages[i]) {
					int startVal = CentralVariables.PlayerTotalCoins;
					CentralVariables.PlayerTotalCoins += CentralVariables.CoinPrices [i];
					//float upgradePrice = CentralVariables.boosterUpgrades [index].currentUpgradePrice;
					//GAManager.Instance.LogResourceEvent (true, "coins", upgradePrice, "BoosterUpgrade", "" + index);
					GAManager.Instance.LogDesignEvent ("package" + i + ":Purchased" );				
					MainMenuManager.Instance.CoinsPurchaseSuccess(startVal,CentralVariables.PlayerTotalCoins,CentralVariables.CoinPrices [i]);
					CentralVariables.SaveToFile ();
					break;
				}
			}
		}

	}


	/// <summary>
	/// Logins the failed.
	/// </summary>
	/// <param name="error">Error.</param>
	void loginFailed( string error ) {
		Debug.Log( "Local Methods: Twitter login failed: " + error );
	}

	/// <summary>
	/// Requests the did fail event.
	/// </summary>
	/// <param name="error">Error.</param>
	void requestDidFailEvent( string error ) {
		Debug.Log( "Local Methods: requestDidFailEvent: " + error );
	}

	/// <summary>
	/// Requests the did finish event.
	/// </summary>
	/// <param name="result">Result.</param>
	void requestDidFinishEvent( object result ) {
		if( result != null )
		{
			Debug.Log( "Local Methods: requestDidFinishEvent" );
		}
	}

	/// <summary>
	/// Tweets the sheet completed event.
	/// </summary>
	/// <param name="didSucceed">If set to <c>true</c> did succeed.</param>
	void tweetSheetCompletedEvent( bool didSucceed ) {
		Debug.Log( "Local Methods: tweetSheetCompletedEvent didSucceed: " + didSucceed );
	}

	#endregion

	#if UNITY_IPHONE

	// facebook events
	void facebookComposeCompletedEvent( bool status) {
	Debug.Log( "Local Methods: facebookComposeCompletedEvent didSucceed: " + status );
	}

	#endif

	}






