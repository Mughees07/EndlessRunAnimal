using UnityEngine;
using System.Collections;

public class AdsManager : SingeltonBase<AdsManager> {
	
	// Use this for initialization
//	public int displayAdAfterLvl = 2;
//	private int localCount = 0;
//	private bool gameLaunch = true;
//	private double pauseTime;
//	private double timeLimit;
//	private double timeDifference;
//	
//	private int adsCount = 1;
//	
//	void Start () {		
//		pauseTime = 0.0f;
//		timeLimit = 180.0f; // enter timeLimit in seconds => 1800.0f = 30 mins
//		timeDifference = 0.0f;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//	
//	public void DisplayAd()
//	{
//		
////		if(UserPrefs.isAmazonBuild || UserPrefs.isIgnoreAds){
////			//			if(gameLaunch){
////			//				gameLaunch = false;
////			//				UserPrefs.Load();
////			//			}
////			return;
////		}
//		
//		switch(GameManager.Instance.GetCurrentGameState())
//		{
//		case GameManager.GameState.MAIN_MENU:
//			//			this.PlayHavenOrMopubAdOnMainMenu();
//			break;
//		case GameManager.GameState.LOADING:
//			//			this.RequestForMopubAd();
//			break;
//			//case GameManager.GameState.MISSIONSSCREEN:
//			//	this.ShowMopubAdOnLevelEnd();
//			break;
//			//	    case GameManager.GameState.CRASHED:
//			//			this.ShowMopubAdOnLevelEnd();
//			break;
//		}
//		
//		if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.RATE_US){
//			return;
//		}
//		switch (GameManager.Instance.GetPreviousGameState ()) {
//			
//		case GameManager.GameState.GAMEOVER:
//			Debug.Log("Level Complete Ad"+adsCount);
//			//				this.ShowMopubAdOnLevelEnd();
//			if(adsCount % 2 == 0){
//				//UnityAdsHelper.isRewardedAd = false; 
//				//UnityAdsHelper.ShowAd(Constants.Android_UnitySimpleAds_ZoneID);
//			}
//
//			adsCount++;
//			break;
//
//		case GameManager.GameState.PAUSE:
//			Debug.Log("Level Complete PAUSED"+adsCount);
//			if(GameManager.Instance.GetCurrentGameState() != GameManager.GameState.GAME_PLAY){
//				if(adsCount % 2 == 0){
//					//UnityAdsHelper.isRewardedAd = false;
//					//UnityAdsHelper.ShowAd(Constants.Android_UnitySimpleAds_ZoneID);
//				}
//
//				adsCount++;
//			}
//			break;
//		}
//	}
//	//	private void RequestForMopubAd()
//	//	{
//	//		localCount ++;
//	//		Debug.Log(" Ad..................::::::::::::::::.... " + localCount);
//	//
//	//		if(localCount == displayAdAfterLvl && !UserPrefs.isIgnoreAds)
//	//		{
//	//			#if UNITY_ANDROID
//	//			if (MoPubAndroidManager.INTERSTITIAL_AD_STATE != MoPubAndroidManager.INTERSTITIAL_STATES.LOADED
//	//			    && MoPubAndroidManager.INTERSTITIAL_AD_STATE != MoPubAndroidManager.INTERSTITIAL_STATES.LOADING){
//	//				
//	//				if(adsCount % 2 == 0){
//	//					MoPubAndroid.requestInterstitalAd(Constants.VIDEO_ADD_ID_ANDROID);
//	//					MoPubAndroidManager.INTERSTITIAL_AD_STATE = MoPubAndroidManager.INTERSTITIAL_STATES.LOADING;
//	//					Debug.Log("Video Ad...................... " + Constants.VIDEO_ADD_ID_ANDROID);
//	//				}
//	//				else{
//	//					MoPubAndroid.requestInterstitalAd(Constants.INTERSTITIAL_ID_ANDROID);
//	//					MoPubAndroidManager.INTERSTITIAL_AD_STATE = MoPubAndroidManager.INTERSTITIAL_STATES.LOADING;
//	//					Debug.Log("Full Screen Ad-------------------------- " + Constants.INTERSTITIAL_ID_ANDROID);
//	//					
//	//				}
//	//				
//	//			}
//	//			//			if(!(UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 2))
//	//			adsCount++;
//	//			#endif
//	//			#if UNITY_IPHONE
//	//			if(MoPubManager.INTERSTITIAL_AD_STATE != MoPubManager.INTERSTITIAL_STATES.LOADED
//	//			   && MoPubManager.INTERSTITIAL_AD_STATE != MoPubManager.INTERSTITIAL_STATES.LOADING){				
//	//				MoPubBinding.requestInterstitialAd(Constants.INTERSTITIAL_ID_IOS,null);
//	//				MoPubManager.INTERSTITIAL_AD_STATE = MoPubManager.INTERSTITIAL_STATES.LOADING;
//	//			}
//	//			
//	//			#endif
//	//			localCount = 0;
//	//		}
//	//	}
//	//	
//	//	IEnumerator WaitForMopubAddOnLevelEnd(float wait)
//	//	{	
//	//			Debug.Log("----------- before : " + MoPubAndroidManager.INTERSTITIAL_AD_STATE);
//	//			yield return new WaitForSeconds(wait);
//	//#if UNITY_ANDROID
//	//		if(MoPubAndroidManager.INTERSTITIAL_AD_STATE == MoPubAndroidManager.INTERSTITIAL_STATES.LOADED)
//	//			MoPubAndroid.showInterstitalAd();
//	//#endif
//	//#if UNITY_IPHONE
//	//			if(MoPubManager.INTERSTITIAL_AD_STATE == MoPubManager.INTERSTITIAL_STATES.LOADED)
//	//			{
//	//				MoPubBinding.showInterstitialAd(Constants.INTERSTITIAL_ID_IOS);
//	//			}
//	//#endif
//	//	}
//	//	private void ShowMopubAdOnLevelEnd()
//	//	{
//	//		#if UNITY_ANDROID
//	//		Debug.Log("----------- Show MoPub Ad State: " + MoPubAndroidManager.INTERSTITIAL_AD_STATE);
//	//		if(MoPubAndroidManager.INTERSTITIAL_AD_STATE == MoPubAndroidManager.INTERSTITIAL_STATES.LOADED){	
//	//			
//	//			MoPubAndroid.showInterstitalAd();
//	//		} 
//	//		#endif
//	//		#if UNITY_IPHONE
//	//		if(MoPubManager.INTERSTITIAL_AD_STATE == MoPubManager.INTERSTITIAL_STATES.LOADED){
//	//			MoPubBinding.showInterstitialAd(Constants.INTERSTITIAL_ID_IOS);
//	//		}
//	//		
//	//		#endif	
//	//	}
//	
//	
//	
//	/*
//	private void PlayHavenOrMopubAdOnMainMenu()
//	{
//		if(gameLaunch)
//		{
//			UserPrefs.Load();
//			
//			if(!UserPrefs.isIgnoreAds){		
//				
//				#if UNITY_ANDROID
////				MoPubAndroid.reportApplicationOpen();
//				//				MoPubAndroid.initAppLovinSDK();
//				//				MoPubAndroid.initHeyzapSDK(Constants.PUBLISHER_ID);
//				//				MoPubAndroid.initPlayhavenSession();
//				#endif
//				
//				//Debug.Log("++++ AdsManagerStart +++++");
//				
//				#if UNITY_ANDROID
//				Upsight.init( Constants.AndroidAppTokenPlayHaven, Constants.AndroidAppSecretPlayHaven );
//				#else
//				Upsight.init( Constants.iOSAppTokenPlayHaven, Constants.iOSAppSecretPlayHaven );
//				#endif			
//				
//				// Make an open request at every app launch
//				Upsight.requestAppOpen();
//				
//				
//				UpsightManager.makePurchaseEvent += myMakePurchaseMethod;
//				UpsightManager.unlockedRewardEvent += myUnlockedRewardMethod;
//				
//				Upsight.sendContentRequest( "game_launch", true );
//				
//			
//				
//			}
//			gameLaunch = false;			
//		}
//			
//	}
//	*/
//	
//	//	private void showMoPubInterstitalAd(){		
//	//		#if UNITY_ANDROID
//	//			Debug.Log("----------- After : " + MoPubAndroidManager.INTERSTITIAL_AD_STATE);
//	//			if(MoPubAndroidManager.INTERSTITIAL_AD_STATE == MoPubAndroidManager.INTERSTITIAL_STATES.LOADED){
//	//				MoPubAndroidManager.INTERSTITIAL_AD_STATE = MoPubAndroidManager.INTERSTITIAL_STATES.NONE;
//	//				if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU)
//	//					MoPubAndroid.showInterstitalAd();
//	//			} else {
//	//				if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU)
//	//					Invoke("showMoPubInterstitalAd",1.0f);
//	//			}
//	//		#endif
//	//		#if UNITY_IPHONE
//	//			if(MoPubManager.INTERSTITIAL_AD_STATE == MoPubManager.INTERSTITIAL_STATES.LOADED){
//	//				MoPubManager.INTERSTITIAL_AD_STATE = MoPubManager.INTERSTITIAL_STATES.NONE;
//	//			Debug.Log("--------------- Mopub 1 ---------------");
//	//				if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU)
//	//				{
//	//					Debug.Log("--------------- Mopub 2 ---------------");
//	//					MoPubBinding.showInterstitialAd(Constants.INTERSTITIAL_ID_IOS);
//	//				}
//	//			} else {
//	//				if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU)
//	//					Invoke("showMoPubInterstitalAd",1.0f);
//	//			}
//	//		#endif	
//	//	}
//	////	IEnumerator WaitForMopubAddOnMainMenu()
//	////	{
//	////		if(!UserPrefs.isIgnoreAds)
//	////		{
//	////#if UNITY_ANDROID
//	////			Debug.Log("----------- before : " + MoPubAndroidManager.INTERSTITIAL_AD_STATE);
//	////			yield return MoPubAndroidManager.INTERSTITIAL_AD_STATE == MoPubAndroidManager.INTERSTITIAL_STATES.LOADED;
//	////		
//	////				// TODO : Mopub Add Loaded State Check
//	////#endif
//	////#if UNITY_IPHONE
//	////			yield return MoPubManager.INTERSTITIAL_AD_STATE == MoPubManager.INTERSTITIAL_STATES.LOADED;  // TODO : Mopub Add Loaded State Check	
//	////#endif
//	////		}
//	////
//	////	}
//	/// 
//	/// 
//	/// 
//	/// 
//	
//	/* public void PlayHavenOnMoreGames()
//	{
////		PlayHavenManager.instance.ContentRequest("more_games");
//		Upsight.sendContentRequest( "more_games", true );
//	}
//	
//	public void PlayHavenOnFreeDeal()
//	{
////		PlayHavenManager.instance.ContentRequest("on_deals");
//		Upsight.sendContentRequest( "on_deals", true );
//	}
//	
//	public void PlayHavenOnFreeDeal(string deal)
//	{
////		PlayHavenManager.instance.ContentRequest(deal);
//		Upsight.sendContentRequest( deal, true );
//	}
//	*/
//	
//	void OnApplicationPause(bool status)
//	{
//		//		if(status)
//		//		{
//		//			pauseTime = Time.realtimeSinceStartup;
//		//		}
//		//		else
//		//		{
//		//			#if UNITY_ANDROID
//		//			if(!UserPrefs.isIgnoreAds)
//		//				MoPubAndroid.initPlayhavenSession();
//		//			#endif
//		//			timeDifference = Time.realtimeSinceStartup - pauseTime;
//		//			if(timeDifference >= timeLimit)
//		//			{
//		//				if(!UserPrefs.isIgnoreAds && !UserPrefs.isAmazonBuild)
//		//					PlayHavenManager.instance.ContentRequest("game_resume");
//		//			}
//		//			else
//		//			{
//		//			}
//		//					
//		//		}
//		
//	}
//	
//	public void removeAds(){
//		//if(!UserPrefs.isIgnoreAds){
//			//UserPrefs.isIgnoreAds = true;
//			//UserPrefs.Save();
//		}
//	}
//	
//	//	void myMakePurchaseMethod( UpsightPurchase purchase )
//	//	{
//	//		if(purchase != null){
//	//			# if UNITY_IPHONE
//	//			if(StoreKitBinding.canMakePayments())
//	//			{						
//	//				StoreKitBinding.purchaseProduct(purchase.productIdentifier,purchase.quantity);
//	//			}
//	//			# endif
//	//			
//	//			# if UNITY_ANDROID		
//	//			GoogleIAB.purchaseProduct(purchase.productIdentifier);
//	//			# endif
//	//		}			
//	//	}
//	
//	//	void myUnlockedRewardMethod( UpsightReward reward )
//	//	{
//	//		if(reward != null){
//	//			UserPrefs.totalCash += reward.quantity;
//	//			UserPrefs.Save();
//	//		}
//	//	}
//	
}


