using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour {

	// By Convention Vector3 x,z is Position And y is Rotation
	// No need to defin z in Inspectator;

	GameObject player;
	public Text coinsCollected;
	public Text playerDistance;
	//private List<GameObject> 	coinsList;

	// Use this for initialization
	void Start () {
		coinsCollected.text = "0";
		playerDistance.text = "0";
		InvokeRepeating ("AddDistance", 0.2f, 0.2f);
	}

	public void AddCoins()
	{		
		CentralVariables.PlayerCurrentCoins+=CentralVariables.CoinsMultiplier;
	}

	public void AddDistance()
	{
		if (CentralVariables.IsRunning && !CentralVariables.isDead)
		CentralVariables.PlayerCurrentDistance++;

	}

	
	/// Update is called once per frame

}
