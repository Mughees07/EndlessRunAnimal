using UnityEngine;
using System.Collections;

public class TapdaqHandler : MonoBehaviour {




	void OnEnable(){

		Tapdaq.hasInterstitialsAvailableForOrientation += DisplayInterstitialWhenAvailable;
		Tapdaq.didCloseInterstitial += DidCloseInterstitial;
		CentralVariables.hasShowedInterstitial = false;
	}

	void OnDisable(){

		Tapdaq.hasInterstitialsAvailableForOrientation -= DisplayInterstitialWhenAvailable;
		Tapdaq.didCloseInterstitial -= DidCloseInterstitial;
	}

	void DidCloseInterstitial(){

		Invoke ("SetHasShowedInterstitial", 3);		
	}

	void SetHasShowedInterstitial(){

		CentralVariables.hasShowedInterstitial = false;
	}

	void DisplayInterstitialWhenAvailable(string orientation){

	
	}
}
