using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
/// <summary>
/// Unity ads event listener. This script must be attached with the game object along with 'UnityAdsHelper.cs' present in plugins.
/// </summary>
public class UnityAdsEventListener : MonoBehaviour 
{
	void Awake ()
	{
		DontDestroyOnLoad(gameObject);
		//Advertisement.Initialize ("1192021");
		//UnityAdsHelper.
		Advertisement.Initialize (CentralVariables.GameId, false);
	}
	
	/// <summary>
	/// Sets the listeners. Listening to their respective Actions
	/// </summary>
	public static void SetListeners ()
	{
		UnityAdsHelper.onFinished += OnAdFinished;
		UnityAdsHelper.onFailed += OnAdFailed;
		UnityAdsHelper.onSkipped += OnAdSkipped;
	}

	/// <summary>
	/// Raises the ad finished event. Implement the behaviour on ad finish.
	/// </summary>
	private static void OnAdFinished ()
	{
		//MainMenuManager.Instance.ShowPopUp ("  Video not available !");
		if (CentralVariables.videoAdRewardType == CentralVariables.VideoAdReward.PLAYER_UNLOCK) {
			//GameObject.FindGameObjectWithTag ("MainCanvas").GetComponent<FaddingMenu> ().FadeIn ();
			int index = CentralVariables.currentIndexMenu;
			CentralVariables.petSelection [index].TryStatus = true;
			CentralVariables.petSelection [index].UnlockStatus = false;
			CentralVariables.currentSelectedDog = index;
			CentralVariables.SaveToFile ();
			MainMenuManager.Instance.GamePlayEvent ();
		} else if (CentralVariables.videoAdRewardType == CentralVariables.VideoAdReward.REVIVE) {

			MainMenuManager.Instance.RevivePanel.SetActive (false);
			MainMenuManager.Instance.HUD.SetActive (true);
			CentralVariables.ReviveGamePlay ();
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ().RevivePlayer ();

		} else if (CentralVariables.videoAdRewardType == CentralVariables.VideoAdReward.FREE_COINS) {

			//CentralVariables.SaveToFile ();
			MainMenuManager.Instance.FreeVideoCoins ();

		} else if (CentralVariables.videoAdRewardType == CentralVariables.VideoAdReward.GAMEOVERHOME) {
			//GameObject.FindGameObjectWithTag ("MainCanvas").GetComponent<FaddingMenu> ().FadeIn ();
			//if (CentralVariables.AdsCounter % 2 == 0)
				//MainMenuManager.Instance.RatusEnjoy.SetActive (true);
		
		}		else if (CentralVariables.videoAdRewardType == CentralVariables.VideoAdReward.DOUBLEIT) {
			//GameObject.FindGameObjectWithTag ("MainCanvas").GetComponent<FaddingMenu> ().FadeIn ();
			CentralVariables.PlayerScore*=2;
			MainMenuManager.Instance.gameOverDouble ();

		}




	}
	/// <summary>
	/// Raises the ad failed event. Implement the behaviour on ad fail.
	/// </summary>
	/// 
	private static void OnAdFailed ()
	{
		MainMenuManager.Instance.ShowPopUp ("  Video not available !");
	}
	/// <summary>
	/// Raises the ad skipped event. Implement the behaviour on ad skip.
	/// </summary>
	private static void OnAdSkipped ()
	{
		//MainMenuManager.Instance.ShowPopUp ("  Video not available !");
	}
}