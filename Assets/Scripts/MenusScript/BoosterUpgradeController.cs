using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoosterUpgradeController : MonoBehaviour {

	// Use this for initialization

	public GameObject[] Boosters;
	public GameObject[] PriceText;
	public GameObject[] BoosterMultiplier;


	public GameObject totalCoins;

	GameObject bars;

	void Start () {
	
		//DontDestroyOnLoad (this.gameObject);
		for (int i = 0; i < CentralVariables.boosterUpgrades.Length; i++) {
		
			bars=Boosters [i].transform.FindChild ("FilledCoins").gameObject;
			PriceText[i].GetComponent<Text>().text = "" + CentralVariables.boosterUpgrades [i].currentUpgradePrice;
			BoosterMultiplier[i].GetComponent<Text>().text = "" +(CentralVariables.boosterUpgrades [i].BoosterMultiplier)+"";

				
			for (int j = 0; j < CentralVariables.boosterUpgrades[i].NumberOfFilledBars; j++) {
				bars.transform.GetChild (j).gameObject.SetActive (true);
			}
			BoosterMultiplier [4].GetComponent<Text> ().text = "" + CentralVariables.boosterUpgrades [i].BoosterMultiplier + "X";
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void BoosterUpgrade(int index)
	{
		if (CentralVariables.PlayerTotalCoins >= CentralVariables.boosterUpgrades [index].currentUpgradePrice) {

			if (CentralVariables.boosterUpgrades [index].NumberOfFilledBars < 5) {
			
				int startVal=CentralVariables.PlayerTotalCoins;

				CentralVariables.PlayerTotalCoins -= CentralVariables.boosterUpgrades [index].currentUpgradePrice;
				float upgradePrice = CentralVariables.boosterUpgrades [index].currentUpgradePrice;
				GAManager.Instance.LogResourceEvent (true, "coins", upgradePrice, "BoosterUpgrade", "" + index);

				CentralVariables.boosterUpgrades [index].currentUpgradePrice = checkBooster (index);
				CentralVariables.boosterUpgrades [index].NumberOfFilledBars++;
				GAManager.Instance.LogDesignEvent ("Booster" + index + ":UpgradedTo" + CentralVariables.boosterUpgrades [index].NumberOfFilledBars);



				if (index == 4)
					CentralVariables.boosterUpgrades [index].BoosterMultiplier += 1;
				else
					CentralVariables.boosterUpgrades [index].BoosterMultiplier += 3;
				



				bars = Boosters [index].transform.FindChild ("FilledCoins").gameObject;

				for (int j = 0; j < CentralVariables.boosterUpgrades [index].NumberOfFilledBars; j++) {
					bars.transform.GetChild (j).gameObject.SetActive (true);
				}
				//totalCoins.GetComponent<Text> ().text = "" + CentralVariables.PlayerTotalCoins;
				GameManager.Instance.ChangeSoundState(GameManager.SoundState.DOUBLECOINSOUND);
				MainMenuManager.Instance.textCounterEffect (totalCoins.GetComponent<Text> (), startVal, CentralVariables.PlayerTotalCoins,(int)upgradePrice, false);

				
				if (CentralVariables.boosterUpgrades [index].NumberOfFilledBars < 5) {
					
					PriceText [index].GetComponent<Text> ().text = "" + CentralVariables.boosterUpgrades [index].currentUpgradePrice;
					if (index == 4)
						BoosterMultiplier [index].GetComponent<Text> ().text = "" + CentralVariables.boosterUpgrades [index].BoosterMultiplier + "X";
					else
						BoosterMultiplier [index].GetComponent<Text> ().text = "" + CentralVariables.boosterUpgrades [index].BoosterMultiplier;
					
				} else {
					PriceText [index].GetComponent<Text> ().text = "-";
					BoosterMultiplier [index].GetComponent<Text> ().text = "-";
				}

				CentralVariables.SaveToFile ();
			}

		} else {
		
			MainMenuManager.Instance.ShowPopUp ("Not Enough Coins !!");
		}
	}

	public int checkBooster(int index)
	{
		int numberOfFilledBars = CentralVariables.boosterUpgrades [index].NumberOfFilledBars-1;
		switch (index) {
		case 0:
			CentralVariables.SpeedBoosterValue = (CentralVariables.SpeedBoosterValue + (CentralVariables.SpeedBoosterIncrement+(200* numberOfFilledBars)));
			return CentralVariables.SpeedBoosterValue;

		case 1:
			CentralVariables.MagnetValue =(CentralVariables.MagnetValue + (CentralVariables.MagnetIncrement + (200* numberOfFilledBars)));
			return CentralVariables.MagnetValue;

		case 2:
			CentralVariables.StealthValue =(CentralVariables.StealthValue +( CentralVariables.StealthIncrement + (200* numberOfFilledBars)));
			return CentralVariables.StealthValue;
		
		case 3:
			CentralVariables.DoubleCoinsValue =(CentralVariables.DoubleCoinsValue + (CentralVariables.DoubleCoinsIncrement + (400* numberOfFilledBars)));
			return CentralVariables.DoubleCoinsValue;


		case 4:
			CentralVariables.finalScoreMultiplierValue = (CentralVariables.finalScoreMultiplierValue +(CentralVariables.finalScoreMultiplierIncrement + (200* numberOfFilledBars)));
			return CentralVariables.finalScoreMultiplierValue;


		}
		return 0;


	}




	}


	

