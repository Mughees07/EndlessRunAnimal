using UnityEngine;
using System.Collections;


public class BoosterExecuter : MonoBehaviour {

	GameObject MagnetTrigger;
	GameObject Magnet;
	GameObject StealthEffect;
	GameObject SpeedEffect;
	GameObject DoubleCoinsEffect;
	GameObject playerBody;


	float lastSpeed=14;

	BoxCollider [] bx;
	HUDMenuController HudMenuController;
	void Start()
	{
		HudMenuController=GameObject.FindGameObjectWithTag("Hud").GetComponent<HUDMenuController>();
		playerBody = GameObject.FindGameObjectWithTag ("PlayerBody");
		bx=playerBody.GetComponentsInChildren<BoxCollider> ();

	}
	public void magnet (GameObject magnetTrigger, GameObject mg)
	{
		//GameManager.Instance.ChangeState(GameManager.SoundState.MagnetPick);

		MagnetTrigger = magnetTrigger;
		Magnet = mg;

		CentralVariables.Magnet = true;
		StartCoroutine(HudMenuController.MagnetboosterBar ());
		//MagnetTrigger.SetActive (true);
		StartCoroutine(endMagnetBooster());
	}


	public void stealth(GameObject stealthEffect)
	{

		//GameManager.Instance.ChangeState(GameManager.SoundState.Stealth);
		StealthEffect = stealthEffect;

		StealthEffect.SetActive (true);
		CentralVariables.Stealth=true;
		StartCoroutine(HudMenuController.ShieldboosterBar ());
		StartCoroutine(endStealthBooster());
		if (!CentralVariables.rampJump)
		DisableCollision();
	}

	public void doubleCoins(GameObject doubleCoinsEffect)
	{
		DoubleCoinsEffect = doubleCoinsEffect;

		//GameManager.Instance.ChangeState(GameManager.SoundState.DoubleCoins);
		DoubleCoinsEffect.SetActive (true);
		CentralVariables.DoubleCoins=true;
		CentralVariables.CoinsMultiplier += 2;
		//Debug.Log("Double coins Started");
		StartCoroutine(HudMenuController.DoubleCoinsboosterBar ());
		StartCoroutine(endDoubleCoinsBooster());

	}
	public void SpeedBooster(GameObject speedEffect)
	{
		CentralVariables.SpeedBooster=true;

		lastSpeed = CentralVariables.CURRENT_SPEED;
		CentralVariables.CURRENT_SPEED += 30;
		SpeedEffect = speedEffect;
		SpeedEffect.SetActive (true);
		//Debug.Log("Double coins Started");
		StartCoroutine(HudMenuController.SpeedboosterBar ());
		StartCoroutine(endSpeedBooster());
		//DisableCollision ();
	}

	IEnumerator endMagnetBooster()
	{

		yield return new WaitForSeconds(CentralVariables.MagnetTime);
		CentralVariables.Magnet=false;
		MagnetTrigger.SetActive (false);
		Magnet.SetActive (false);

	}
	
	IEnumerator endDoubleCoinsBooster()
	{	
		yield return new WaitForSeconds(CentralVariables.DoubleCoinsTime);	
		CentralVariables.DoubleCoins=false;
		CentralVariables.CoinsMultiplier -= 2;
	}
	
	IEnumerator endStealthBooster()
	{		
		yield return new WaitForSeconds(CentralVariables.StealthTime);
		StealthEffect.SetActive (false);
		yield return new WaitForSeconds(0.2f);
		CentralVariables.Stealth=false;
		//Debug.Log ("stealth ends");
		EnableCollision();
	}

	IEnumerator endSpeedBooster()
	{		
		yield return new WaitForSeconds(CentralVariables.SpeedBoosterTime);
		SpeedEffect.SetActive (false);
		CentralVariables.CURRENT_SPEED = lastSpeed;
		yield return new WaitForSeconds (0.2f);
		CentralVariables.SpeedBooster=false;
		//EnableCollision ();

		//Debug.Log ("stealth ends");
	}

	public void disableBoosters()
	{
		StopCoroutine ("endStealthBooster");
		StopCoroutine ("endDoubleCoinsBooster");
		StopCoroutine ("endMagnetBooster");
		StopCoroutine ("endSpeedBooster");

		CentralVariables.Magnet = false;

		if (CentralVariables.DoubleCoins) {
			CentralVariables.DoubleCoins = false;
			CentralVariables.CoinsMultiplier -= 2;
		}
		CentralVariables.Stealth = false;		
		CentralVariables.SpeedBooster = false;


		CentralVariables.CURRENT_SPEED = lastSpeed;
	
		if(StealthEffect)
		StealthEffect.SetActive (false);

		if(SpeedEffect)
		SpeedEffect.SetActive (false);

		if(MagnetTrigger)
		MagnetTrigger.SetActive (false);

		if(Magnet)
		Magnet.SetActive (false);
		

	}

	public void DisableCollision()
	{
		
		foreach (BoxCollider b in bx)
			b.enabled = false;



	}

	public void EnableCollision()
	{
		foreach (BoxCollider b in bx)
			b.enabled = true;
	}

}
