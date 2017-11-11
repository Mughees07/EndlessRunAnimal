using UnityEngine;
using System.Collections;


public class BoosterUpgrades
{	
	public  int NumberOfFilledBars;
	public  int currentUpgradePrice;
	public  int BoosterMultiplier;
}

public class PetSelection
{
	public bool UnlockStatus;
	public bool TryStatus;
	public int Price;
	public bool Selected;
}


public class CentralVariables : MonoBehaviour {

		// Use this for initialization
	//Formula::
	public static int TimeSeconds=1;

	public static bool isDay = true;

	public static bool isTutorialSeen = true;
	public static bool isTutorialLoaded = true;

	//Revive
	public static int reviveValue=800;


	public static bool isPaused=false;
	//PlayerSpeed
	public static float MAX_SPEED = 30;
	public static float CURRENT_SPEED = 14;
	public static float increamentFactor = 0.022f;
	public static bool IsRunning;
	public static int CurrentLevelIndex;

	//GameModes
	public static bool GameStart=true;
	public static int DIFFICULTY_MODE;
	public const int EASY_MODE=0;
	public const int MEDIUM_MODE=1;
	public const int HARD_MODE=2;
	public static int MODE_CHANGETIME_MEDIUM=100;
	public static int MODE_CHANGETIME_HARD=200;


	//hurdlesCount
	public const int PoolHurdlesCount = 10;
	public const int patchHurdlesCount = 6;
	public const int PoolVehicleCount = 12;
	public const int patchVehiclesCount = 2;
	public const int PoolBoostersCount = 8;
	public const int patchBoostersCount = 2;

	public static int currentMovementindex=0;

	public static float VehicleMovementTime=5f;
	public static bool isReviving;
	public static bool isDead=false;

	public static  bool DogTry;
	public static bool DogTryStatus;

	//PlayerScores
	public static int PlayerTotalCoins=500;
	public static int PlayerCurrentCoins;
	public static int PlayerCurrentDistance;
	public static int PlayerScore;
	public static int PlayerHighestScore;
	public static int CoinsMultiplier=1;
	public static int FreeCoinsValue=30;

	//Boosters
	public static bool Stealth;
	public static bool Magnet;
	public static bool DoubleCoins;
	public static bool SpeedBooster;
	public static float StealthTime;
	public static float MagnetTime;
	public static float DoubleCoinsTime;
	public static float SpeedBoosterTime;
	public static float finalScoreMultiplier;

	//BoosterStore
	public static BoosterUpgrades[] boosterUpgrades=new BoosterUpgrades[5];
	public static int StealthIncrement=200;
	public static int MagnetIncrement=400;
	public static int SpeedBoosterIncrement=200;
	public static int DoubleCoinsIncrement=800;
	public static int finalScoreMultiplierIncrement=1800;


	public static int SpeedBoosterValue=600;
	public static int MagnetValue=800;
	public static int StealthValue=600;
	public static int DoubleCoinsValue = 1000;
	public static int finalScoreMultiplierValue=3200;

	//CoinsStore
	public static int []CoinPrices= new int[]{3500,7500,11500,22500,50000};

	//PetStore
	public static PetSelection[] petSelection=new PetSelection[5];
	public static int currentSelectedDog = 0;
	public static int currentIndexMenu=0;

	public static bool rampJump=false;
	public static bool GamePauseBool=false;
	public static bool ReviveGameBool=false;

	public static bool isPlayMusic=true;
	public static bool isPlaySound=true ;


	//Tutorial
	public static bool left;
	public static bool right;
	public static bool up;
	public static bool down;
	public static int tutorialActionCount=-1;


	public static bool hasShowedInterstitial=false;

	//Ads
	public enum VideoAdReward
	{
		REVIVE,
		PLAYER_UNLOCK,
		FREE_COINS,
		GAMEOVERHOME,
		DOUBLEIT
	};

	public static VideoAdReward videoAdRewardType;
	public const string GameId="1217055";
	public const string RewardedZoneId = "rewardedVideo";
	public const string VideoZoneId = "video";


	//Reset GamePlay
	public static void ResetGamePlay()
	{
		

		reviveValue = 800;
	

		if (DogTryStatus)
			DogTryStatus = false;
		else			
			DogTry = false;

		PlayerTotalCoins = 500;

		#region BoosterUpgrades
		for (int i = 0; i < boosterUpgrades.Length; i++) {
			boosterUpgrades [i] = new BoosterUpgrades ();

			boosterUpgrades [i].NumberOfFilledBars = 1;	
			if(i==4)
				boosterUpgrades [i].BoosterMultiplier = 2;
			else
			boosterUpgrades [i].BoosterMultiplier = 10;
		}
		boosterUpgrades [0].currentUpgradePrice = 600;
		boosterUpgrades [1].currentUpgradePrice = 800;
		boosterUpgrades [2].currentUpgradePrice = 600;
		boosterUpgrades [3].currentUpgradePrice = 1000;
		boosterUpgrades [4].currentUpgradePrice = 3200;	

		#endregion

		#region Pets

		for (int i = 1; i < petSelection.Length; i++) {
			petSelection [i] = new PetSelection ();
			petSelection [i].UnlockStatus = false;			
			petSelection [i].Selected = false;
			petSelection [i].TryStatus = false;
		}

		petSelection [1].Price =3200;
		petSelection [2].Price =4200;
		petSelection [3].Price =6400;
		petSelection [4].Price =9600;

		petSelection [0] = new PetSelection ();
		petSelection [0].UnlockStatus = true;
		petSelection [0].Price = 0;
		petSelection [0].Selected = true;
		petSelection [0].TryStatus = false;
	
		#endregion

		LoadFromFile ();


		SpeedBoosterTime= boosterUpgrades [0].BoosterMultiplier-3;
		MagnetTime= boosterUpgrades [1].BoosterMultiplier-3;
		StealthTime= boosterUpgrades [2].BoosterMultiplier-3;
		DoubleCoinsTime= boosterUpgrades [3].BoosterMultiplier-3;
		finalScoreMultiplier = boosterUpgrades [4].BoosterMultiplier;

		//Debug.Log (CentralVariables.PlayerTotalCoins);


		Stealth=false;
		Magnet=false;
		DoubleCoins=false;
		SpeedBooster=false;


		CURRENT_SPEED = 14;
		increamentFactor = 0.02f;
		TimeSeconds = 1;

		CoinsMultiplier = 1;
		DIFFICULTY_MODE = EASY_MODE;
		GameStart = true;
		PlayerCurrentCoins=0;
		PlayerCurrentDistance=0;
		PlayerScore=0;
		isReviving = false;
		isDead = false;
		IsRunning = false;
		if (CentralVariables.isPlayMusic)
			SoundManager.Instance.unmute ();
	}
	//Revive
	public static void ReviveGamePlay()
	{
	//To increase difficulty after time
		if (DIFFICULTY_MODE == MEDIUM_MODE) {
			TimeSeconds = MODE_CHANGETIME_MEDIUM-10;
		} else if (DIFFICULTY_MODE == HARD_MODE) {
			
			TimeSeconds = MODE_CHANGETIME_HARD - 10;
		}
		else
		TimeSeconds = TimeSeconds - 10;

		VehicleMovementTime = 5f;
		DIFFICULTY_MODE = EASY_MODE;
		isDead = false;
	}

	//public static int AdsCounter;
	public static int GameOverCount = 1;

	//public const bool isAmazonBuild = false;


	// Data Path
	public static string DATA_PATH = Application.persistentDataPath;
	public const string BUNDLE_ID = "com.xtroid.shapeit";
	public const string IOS_BUNDLE_ID = "";
	public const string AMAZON_LEADERBOARD_ID = "";
	public const string ANDROID_LEADERBOARD_ID = "CgkIopHE0bEZEAIQBg";
	public const string INAPP_CURRENCY="USD";
	public const string INAPP_KEY="MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA76gTihCxhVWVemve0YBtCd6LAYJbFTbxT63TyyGVfmnhjoSAPEDVrbFzs8XUhdtE9U/vF0M1mTZ1/25a0wgqvIkMVlJMnigvU9erTQo7Y6eAp95hCSI5EPePEvPvD58ttARF1vehozWFdf6EB44k8w++IqFEaNalvM3f342SSW24x17ShR6qtnb+Y5JKDIh1bgDVPRvNVdKXYSu58LbqQVh/TvHHG+imHspA/0J5VezWCg79tnzg2DREUJ6ZcsU35PqiXOwiXoaW289H+Zhk6KQZ/buqE2puXmAH3fn41VeKOa4KOBtzqv9ZhLkwos9L4cFFUhoOnAB5WsYDbZx6XwIDAQAB";
	public static string[] InAppPackages = new string[5]{"com.gogames.mannequinescape.pkg099", "com.gogames.mannequinescape.pkg199", "com.gogames.mannequinescape.pkg299", "com.gogames.mannequinescape.pkg499", "com.gogames.mannequinescape.pkg899" };
	//public static string[] InAppPackages = new string[5]{"android.test.purchased", "com.gogames.mannequinescape.pkg199", "com.gogames.mannequinescape.pkg299", "com.gogames.mannequinescape.pkg499", "com.gogames.mannequinescape.pkg899" };

	#if UNITY_IPHONE
	public static string receiptVerifySandboxURL = "";
	#endif
	#if UNITY_ANDROID

	#endif

	public static bool rateUsBool = true;
	//public const string iOS_RateUsLink = "itms-apps://itunes.apple.com/app/"+IOS_BUNDLE_ID+"?at=10l6dK";
	//public const string Amazon_RateUsLink = "amzn://apps/android?p=" + BUNDLE_ID;
	public const string Android_RateUsLink = "market://details?id="+BUNDLE_ID;

	public static string getNotReadyText(){
		return "Please Wait \n Video Ad is not loaded!";
	}


	#region PlayerPrefs
	/// <summary>
	/// Saves to file.
	/// </summary>
	public static void SaveToFile ( ) {


		if (isTutorialSeen == isTutorialLoaded) {
			PreviewLabs.PlayerPrefs.SetBool	("isTutorialSeen", isTutorialSeen);
			PreviewLabs.PlayerPrefs.SetBool	("isTutorialLoaded", isTutorialLoaded);
		}


		PreviewLabs.PlayerPrefs.SetBool	( "isPlayMusic", isPlayMusic) ;
		PreviewLabs.PlayerPrefs.SetBool	( "isPlaySound", isPlaySound) ;
		//PreviewLabs.PlayerPrefs.SetBool	( "isAdRemoved", isAdRemoved);
		PreviewLabs.PlayerPrefs.SetBool("rateUsBool",rateUsBool);		
		PreviewLabs.PlayerPrefs.SetInt ("PlayerTotalCoins",PlayerTotalCoins);	
		PreviewLabs.PlayerPrefs.SetInt ("PlayerHighestScore",PlayerHighestScore);

		//PreviewLabs.PlayerPrefs.SetInt ("TutorialShowCount",TutorialShowCount);

		for (int i = 0; i < petSelection.Length; i++) {

			PreviewLabs.PlayerPrefs.SetBool( "PetSelectionUnlockStatus"+i,petSelection[i].UnlockStatus);	
			PreviewLabs.PlayerPrefs.SetBool( "PetSelectionSelectedStatus"+i,petSelection[i].Selected);	
			PreviewLabs.PlayerPrefs.SetBool( "PetSelectionTryStatus"+i,petSelection[i].TryStatus);
			PreviewLabs.PlayerPrefs.SetInt( "PetSelectionPrice"+i,petSelection[i].Price);

		}
		if(!DogTry)
		PreviewLabs.PlayerPrefs.SetInt( "CurrentDog",currentSelectedDog);


		for ( int i = 0 ; i < boosterUpgrades.Length ; i ++ )
		{
			PreviewLabs.PlayerPrefs.SetInt( "BoosterUpgradePrice"+i,boosterUpgrades[i].currentUpgradePrice);
			PreviewLabs.PlayerPrefs.SetInt( "BoosterUpgradeFilledBars"+i,boosterUpgrades[i].NumberOfFilledBars);
			PreviewLabs.PlayerPrefs.SetInt( "BoosterMultiplier"+i,boosterUpgrades[i].BoosterMultiplier);
		}


		PreviewLabs.PlayerPrefs.Flush ();
	}


	public static void LoadFromFile ( )	
	{

		if(!DogTry)
		currentSelectedDog=PreviewLabs.PlayerPrefs.GetInt( "CurrentDog",currentSelectedDog);

		for (int i = 0; i < petSelection.Length; i++) {
			
			petSelection[i].UnlockStatus=PreviewLabs.PlayerPrefs.GetBool( "PetSelectionUnlockStatus"+i,petSelection[i].UnlockStatus);	
			petSelection[i].Selected=PreviewLabs.PlayerPrefs.GetBool( "PetSelectionSelectedStatus"+i,petSelection[i].Selected);	
			petSelection[i].TryStatus=PreviewLabs.PlayerPrefs.GetBool( "PetSelectionTryStatus"+i,petSelection[i].TryStatus);
			petSelection[i].Price=PreviewLabs.PlayerPrefs.GetInt( "PetSelectionPrice"+i,petSelection[i].Price);
		
		}

		for ( int i = 0 ; i < boosterUpgrades.Length ; i ++ )
		{
			boosterUpgrades[i].currentUpgradePrice=PreviewLabs.PlayerPrefs.GetInt( "BoosterUpgradePrice"+i,boosterUpgrades[i].currentUpgradePrice);
			boosterUpgrades[i].NumberOfFilledBars=PreviewLabs.PlayerPrefs.GetInt(  "BoosterUpgradeFilledBars"+i,boosterUpgrades[i].NumberOfFilledBars);
			boosterUpgrades[i].BoosterMultiplier=PreviewLabs.PlayerPrefs.GetInt( "BoosterMultiplier"+i,boosterUpgrades[i].BoosterMultiplier);	
		}
		//isRegistered 		 = PreviewLabs.PlayerPrefs.GetBool	( "isRegistered", isRegistered) ;
		isTutorialSeen= PreviewLabs.PlayerPrefs.GetBool("isTutorialSeen", isTutorialSeen) ;
		isTutorialLoaded=PreviewLabs.PlayerPrefs.GetBool( "isTutorialLoaded", isTutorialLoaded) ;

		isPlayMusic=PreviewLabs.PlayerPrefs.GetBool	( "isPlayMusic", isPlayMusic) ;
		isPlaySound=PreviewLabs.PlayerPrefs.GetBool	( "isPlaySound", isPlaySound) ;
		//isLaunchedFirstTime  = PreviewLabs.PlayerPrefs.GetBool	( "isLaunchedFirstTime", isLaunchedFirstTime) ;
		//isAdRemoved          =PreviewLabs.PlayerPrefs.GetBool	( "isAdRemoved", isAdRemoved);
		rateUsBool = PreviewLabs.PlayerPrefs.GetBool("rateUsBool",rateUsBool);

		//TutorialShowCount = PreviewLabs.PlayerPrefs.GetInt	( "TutorialShowCount");
		PlayerTotalCoins 	= PreviewLabs.PlayerPrefs.GetInt ("PlayerTotalCoins",PlayerTotalCoins);

		PlayerHighestScore = PreviewLabs.PlayerPrefs.GetInt ("PlayerHighestScore");




	}
	#endregion

}
