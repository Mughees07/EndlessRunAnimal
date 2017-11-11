using UnityEngine;
using System.Collections;

public class Constants {
	public const float DISTANCE_FACTOR =3;

	public static string TWEET = "";
	public const string Android_UnityAds_ZoneID = "rewardedVideo";
	public const string Android_UnitySimpleAds_ZoneID = "video";

	public const float SCREEN_WIDTH = 1024f;
	public const float SCREEN_HEIGHT = 768f;
	public static float XSCALE = 0f;
	public static void SwitchOffSounds(){
		//PatchSoundController []patchSoundController = GameObject.FindObjectsOfType(typeof(PatchSoundController)) as PatchSoundController[]; 
//		for (int i = 0; i < patchSoundController.Length; i++) {
//			patchSoundController[i].SwitchOffSound();
//		}

//		SoundManager.Instance.pauseSound();
		GameObject player = GameObject.FindGameObjectWithTag("Player");
	    if(player){
			AudioSource audioSource =  player.GetComponentInChildren<AudioSource>();
			if(audioSource ){
				audioSource.GetComponent<AudioSource>().Stop();
			}				 
		}
	}
	
//	public static void SwitchOnSounds(){
//		PatchSoundController []patchSoundController = GameObject.FindObjectsOfType(typeof(PatchSoundController)) as PatchSoundController[]; 
//		for (int i = 0; i < patchSoundController.Length; i++) {
//			patchSoundController[i].SwitchOnSound();
//		}
//
//		//SoundManager.Instance.resumeSound();
//
//		GameObject player = GameObject.FindGameObjectWithTag("Player");
//		//if(player && UserPrefs.isSound)
//		{
//			AudioSource audioSource =  player.GetComponentInChildren<AudioSource>();
//			if(audioSource && !audioSource.GetComponent<AudioSource>().isPlaying){
//				audioSource.GetComponent<AudioSource>().Play();
//			}
//			
//		}
//	}
	#region InApp
	
	public const string INAPP_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAoQWjhPGHZMCRWNs29LaME382p4jwADiAieA2EmLQhctc/m2h6L6yzqN1gf72XIxldiKucIANBCmZw0E0XXp1KLKiWRaAVlR0Judw2LDOO1v7O70vciZIUeqqb9jKDHMJp9GCBx2RE4Aj1esj0Rs1CIrWZEAM6vxKPAH7lPjbvJ0RATOtYRhCMMUQGTwjgJfwKbnz5n3YpmENhjSgm2gIRPlqvaRavKRChsyCMv/shWrpnwHxGI0UfrdWtRjvgfPL1Coe9urw3Zh6X8NQglHEMLxOJnKf/V3HRsBzw/WSyzCrazlLW8EYNITQ3ZMtAlCLMz9zCdStPgsJcK+hgKHONwIDAQAB";
	// Consumable In-apps. GN stand for Game Name

	public const string Coins_Package1Price = "29.99";




	public const string INAPP_CURRENCY = "USD";

	public const string PACKAGE_1  = "com.tapinator.ait.coins500"; 



	public const int PACKAGE_1_AMOUNT = 500;


	public const string PACKAGE_1_AMOUNT_New = "210,000";


	public const int PACKAGE_1_Coins = 210000;


	public const int SKIP_LEVEL_COINS = 400;

	public const string PACKAGE_1_Detail = "( 150,000 + 60,000 FREE )";




	public const string POLICE_02 = "com.xtroid.shapeit";
	//public const string POLICE_02 = "android.test.purhcased";


	public const string coins_5000 = "com.xtroid.shapeit";


	//Non Consumables In-apps. GN stand for Game Name
	public const string TEST_ID = "android.test.purhcased";

	public const string REMOVEADS = "com.xtroid.shapeit";
	public const string BundleID = "com.xtroid.shapeit";


	public const string space = " ";
	#endregion

	#region OutOFFuel
	public const int outOfFuelPackageOneCoins = 500;

	
	public const int outOfFuelPackageOneFuel = 20;	

	#endregion

	#region Episode coins
	
	public const int SecondEpisode_Unlock_Coins = 4000;
//	public const int ThirdEpisode_Unlock_Coins = 12000;
	
	#endregion
	#region Game play
	public const float BRAKE_UPGRADE_FACTOR = 0.25f;
	public const float ENGINE_UPGRADE_FACTOR = 5f;
	public const float ENGINE_UPGRADE_PERFORMANCE_FACTOR = 1f;
	public const float STEERING_UPGRADE_FACTOR = 0.002f;
	public const float MAX_STEERING_UPGRADE_FACTOR = 5f;
	public const int FUEL_UPGRADE_FACTOR = 20;
	public const int Coins_Level_Success = 400;







	#endregion




	#region Achievements
	//ACID stand for Achievement ID
	
	//Social Achievements
	public const string ACIDFBFAN = "CgkIzNDu_-kQEAIQDA";
	public const string ACIDSUPPORTER = "CgkIzNDu_-kQEAIQDQ";
	public const string ACIDTWITTERANNOUNCER = "CgkIzNDu_-kQEAIQDg";
	
	//Parking Achievements
	public const string ACIDRIDER = "CgkIzNDu_-kQEAIQAQ";
	public const string ACIDDRIVER = "CgkIzNDu_-kQEAIQAg";
	public const string ACIDPARKER = "CgkIzNDu_-kQEAIQAw";
	public const string ACIDBUSMAN = "CgkIzNDu_-kQEAIQBA";
	
	//Levels Achievements
	public const string ACIDHONKER = "CgkIzNDu_-kQEAIQBQ";
	public const string ACIDLASHER = "CgkIzNDu_-kQEAIQBg";
	
	public const string ACIDCHAUFFEUR = "CgkIzNDu_-kQEAIQBw";
	public const string ACIDCABBY = "CgkIzNDu_-kQEAIQCA";
	
	//Vehicles Achievements
	public const string ACIDTHIRLLLOVER = "CgkIzNDu_-kQEAIQCg";
	public const string ACIDMASTERBLASTER = "";
	public const string ACIDTURNKEY  = "";
	
	//Environment Achievements
	public const string ACIDEXPLORER = "CgkIzNDu_-kQEAIQCQ";
	public const string ACIDSHOPPINGKING = "";
	public const string ACIDALLOUT = "";
	
	//Coins Achievement
	public const string ACIDMANOFMEANS  = "CgkIzNDu_-kQEAIQCw";
	
	#endregion
	
	#region Leaderboards
	
	//LID stands for Leaderboard ID.
	public const string LIDTHEBENEFACTOR  = "CgkIzNDu_-kQEAIQDw";
	public const string LIDMASTERBLASTER = "CgkIzNDu_-kQEAIQEA";
	
	#endregion
	
	
	#region AdNetworks
	
	public const string INTERSTITIAL_ID_IOS = "56a87c0d14d843e79c650cb334f88521";  // Mobup ID
	public const string INTERSTITIAL_ID_ANDROID_LEVEL_END ="5353d51389cf433a98032bcabb2c582c";  // Mobup ID
	public const string INTERSTITIAL_ID_ANDROID_MAINMENU  = "b4ce79b338e743cca2a042cd5414ff8b"; 

	#endregion
	
	#region MenuConstants
	// menus Constants


	public const int SecondVehicle_Unlock_Coins = 6000;
	public const int ThirdVehicle_Unlock_Coins = 14000;

	public const string	GAME_NAME =BundleID;
	public const string FACEBOOK_LINK = "https://www.facebook.com/" ;
	public const string GOOGLEPLUS_LINK = "https://plus.google.com/111792587765949337090" ;
	public const string TWITTER_LINK = "https://twitter.com" ;
	public const string AMAZON_RATEUS_LINK ="amzn://apps/android?p="+BundleID;
	public const string IOS_RATEUS_LINK ="";
	public const string MOREGAMES_LINK = "https://play.google.com/store/apps/developer?id=Game+n%27Go+Studio" ;

	public const string ANDROID_RATEUS_LINK ="https://play.google.com/store/apps/details?id="+BundleID;
	public const int    COINSTOSKIPLEVEL = 50;            // 50 coins to skip level.
	public const int 	LEVELCOMPLETEREWARD = 30;    // 30 coins
	//public const string SCENE_EPISODE1 = "Endless_Driving_Desert";//"";
	public const string SCENE_EPISODE1 = "Env_escape"; //"Endless_Driving_Winter";
	public const string SCENE_EPISODE2 = "endless city_night"; //"Endless_Driving_Grass";

	public const string SCENE_EPISODE3 = "Airport_Endless_Racer";
	public const string SCENE_MENU ="MenusScene";
	public const int levelsPerEpisode = 12;
	
	public const int totalLevels = 24;
//	public const float TIMEPERLEVEL = 100.0f;
	public static string [ ] vehicleNameArray = { "kkkkV" , "kkkk","vehicle", "vehiclea" ,"vehicle " , "monster vehicle" } ;
	public static int	[ ] vehicleSpeedArray 		= {1, 5 ,	15  } ;			// 1 - 15
	public static int	[ ] vehicleHandlingArray	= { 4, 8 ,	15   } ;			// 1 - 15
	public static int	[ ] vehicleBrakingArray 	= {3, 8 ,	15  } ;			// 1 - 15
	public static int	[ ] vehicleResistanceArray	= { 2, 9 ,	15  } ;			// 1 - 15
	public static int [ ] vehicleAccelerationArray  =  {3, 12 , 15 } ;   // 1 s- 15
	public static float [ ] vehicleSelectionArray   = {0.441f, 0.583f,1f };   //  {0.17f, 0.37f, 0.50f,  0.68f, 0.85f , 1f}
 	public static int [ ] vehicleFuelArray    = {3, 3 , 7 , 9 , 15,15 } ;   // 1 - 15
 	public static int [ ] vehicleStrengthArray  = { 5, 5 , 7 , 8 , 15,15 } ;   // 1 - 15
 	public static int [ ] vehiclePriceArray   = { 0 ,  1000 , 1400 , 2500, 4000 , 6000 } ;
	public static int [ ] episodePriceArray   = { 0 ,  1000 , 1400 , 2400 } ;
	public static string [ ] episodeNameArray =       { "Episode 1" , "Episode 2","Episode 3", "Episode 4" } ;
	public static int[,] totalParkingLot = new int[3,levelsPerEpisode]{{1,1,1,1,1,1,1,1,1,1,1,1},{1,1,1,1,1,1,1,1,1,1,1,1}, {1,1,1,1,1,1,1,1,1,1,1,1}};
	public static float[,] timePerLevel = new float[3,levelsPerEpisode]{{105.0f,90.0f,10f,105.0f,105.0f,90.0f,100.0f,105.0f,105.0f,105.0f,105f,105f}, {150.0f,110.0f,110.0f,105.0f,105.0f,90.0f,100.0f,105.0f,105.0f,105.0f,105f,105f}, {200.0f,180.0f,150.0f,105.0f,105.0f,90.0f,100.0f,105.0f,105.0f,105.0f,105f,105f}};
	
	#endregion
	
	#region AchievementsRewards
	
	//Social Achievements Rewards
	public const int ACIDFBFANCOMPLETEDREWARD = 10;
	public const int ACIDSUPPORTERCOMPLETEDREWARD =10;
	public const int ACIDTWITTERANNOUNCERCOMPLETEDREWARD = 10;
	
	//Parking Achievements Rewards
	public const int ACIDRIDERCOMPLETEDREWARD = 5;
	public const int ACIDDRIVERCOMPLETEDREWARD = 10;
	public const int ACIDPARKERCOMPLETEDREWARD = 20;
	public const int ACIDBUSMANCOMPLETEDREWARD = 40;
	
	//Levels Achievements Rewards
	public const int ACIDHONKERCOMPLETEDREWARD = 5;
	public const int ACIDLASHERCOMPLETEDREWARD = 10;
	public const int ACIDCHAUFFEURCOMPLETEDREWARD = 15;
	public const int ACIDCABBYCOMPLETEDREWARD = 20;
	
	//Vehicles Achievements Rewards
	public const int ACIDTHIRLLLOVERCOMPLETEDREWARD = 25;
	public const int ACIDMASTERBLASTERCOMPLETEDREWARD = 50;
	public const int ACIDTURNKEYCOMPLETEDREWARD  = 75;
	
	//Environment Achievements Rewards
	public const int ACIDEXPLORERCOMPLETEDREWARD = 25;
	public const int ACIDSHOPPINGKINGCOMPLETEDREWARD = 50;
	public const int ACIDALLOUTCOMPLETEDREWARD = 75;
	
	//Coins Achievement Rewards
	public const int ACIDMANOFMEANSCOMPLETEDREWARD  = 25;
	
	#endregion

	public const string AndroidAppTokenPlayHaven = "b4e9d17bb9044bf0a88418557b77b806";
	public const string AndroidAppSecretPlayHaven = "cfec84d60a5a4734aa584b49ed3d50c9";
	public const string iOSAppTokenPlayHaven = "3c09eda824ae45668b3f0f9c5a35f7b1";
	public const string iOSAppSecretPlayHaven = "ab691c4cb0db4236aad6e52dcf687a3f";


	public static bool loadMainMenu = true;

}
