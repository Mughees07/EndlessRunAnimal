using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinPurchaseController : MonoBehaviour {

	// Use this for initialization

	public GameObject[]PriceText;

	//public GameObject[] PriceText;
	//public GameObject[] BoosterMultiplier;


	public GameObject totalCoins;

	GameObject bars;

	void Start () {
	
		//DontDestroyOnLoad (this.gameObject);
		for (int i = 0; i < CentralVariables.CoinPrices.Length; i++) {
		
			PriceText [i].GetComponent<Text> ().text = "$" + CentralVariables.CoinPrices [i];
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void CoinPurchase(int index)
	{
		Debug.Log ("Purchase : " + index);
		StoreManager.Instance.PurchasePackage(index);	

	}





	}


	

