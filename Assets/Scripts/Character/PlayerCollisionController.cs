using UnityEngine;
using System.Collections;

public class PlayerCollisionController : MonoBehaviour {

	public GameObject deathEffect;
	public GameObject coinEffect;
	public GameObject magnetTrigger;
	public GameObject stealthEffect;
	public GameObject speedEffect;
	public GameObject doubleCoinsEffect;
	public GameObject[] magnet;

	public GameObject playerBody;
	//public GameObject ragdoll;

	PlayerMovement playerMov;

	public GameObject tutorial;



	bool glassCollision=false;

	// Use this for initialization


	ParticleSystem coinEffectSystem;
	PatchPlacementManager placementManager;
	CoinsManager coinManager;
	Character_Animation_Controller animationController;
	BoosterExecuter boosterExecutor;

	bool isCollided=false;



	void Start()
	{
		placementManager = GameObject.FindGameObjectWithTag ("Patch_Placement_Manger").GetComponent<PatchPlacementManager>();
		coinManager= GameObject.FindGameObjectWithTag ("CoinManager").GetComponent<CoinsManager>();
		playerMov=GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement>();
		//Invoke ("wait", 1.0f);
		 playerBody = GameObject.FindGameObjectWithTag ("PlayerBody");
		boosterExecutor = GameObject.FindGameObjectWithTag ("BoosterExecutor").GetComponent<BoosterExecuter>();
		animationController=playerBody.GetComponent<Character_Animation_Controller>();
		coinEffectSystem = coinEffect.GetComponent<ParticleSystem>();

		tutorial = GameObject.FindGameObjectWithTag ("tutorial");
	}

	#region Triggers


	void OnTriggerEnter(Collider collider){

		if (collider.gameObject.tag == "Hurdle" || collider.gameObject.transform.parent.gameObject.tag == "Hurdle") {
			if (!CentralVariables.isDead && !CentralVariables.Stealth && !CentralVariables.isReviving && !isCollided && !CentralVariables.SpeedBooster && !CentralVariables.GameStart) {

				Debug.Log ("Hurdle Hit");
				GameManager.Instance.ChangeSoundState (GameManager.SoundState.HIT);

				animationController.PlayerDeath ();
				StartCoroutine (isCollidedDeactivate ());
				isCollided = true;
				animationController.EndAll ();
				boosterExecutor.disableBoosters ();
				CentralVariables.IsRunning = false;


				playerMov.playerMesh.SetActive (false);


			}
		}
		if (collider.gameObject.tag == "PatchTrigger") {

			StartCoroutine (ActivateObject (collider.gameObject));
			placementManager.addNextPatch ();
			Debug.Log ("patch Created");

		} else if (collider.gameObject.tag == "PatchDestroyer") {
		
			StartCoroutine (ActivateObject (collider.gameObject));
			placementManager.RecycleOldPatch ();

		} else if (collider.gameObject.tag == "Coin") {
			if (!CentralVariables.isDead) {
				coinEffect.SetActive(false);
				GameManager.Instance.ChangeSoundState (GameManager.SoundState.COINCOLLECTSOUND);
				coinEffect.transform.position = collider.gameObject.transform.position;
				coinEffect.SetActive(true);
				StartCoroutine (ActivateObjectCoin (collider.gameObject));
				coinManager.AddCoins ();	
				collider.gameObject.SetActive (false);
			}
		} else if (collider.gameObject.tag == "Booster") {

			if (collider.gameObject.name.Contains ("Magnet")) {
				if (!CentralVariables.Magnet) {
					GameManager.Instance.ChangeSoundState (GameManager.SoundState.MAGNETSOUND);
					magnetTrigger.SetActive (true);
					magnet [CentralVariables.currentSelectedDog].SetActive (true);
					boosterExecutor.magnet (magnetTrigger, magnet [CentralVariables.currentSelectedDog]);
				}				
			} else if (collider.gameObject.name.Contains ("2X")) {

				if (!CentralVariables.DoubleCoins) {
					GameManager.Instance.ChangeSoundState (GameManager.SoundState.DOUBLECOINSOUND);
					boosterExecutor.doubleCoins (doubleCoinsEffect);
				}
			} else if (collider.gameObject.name.Contains ("Shield")) {
				if (!CentralVariables.Stealth) {
					GameManager.Instance.ChangeSoundState (GameManager.SoundState.STEALTHSOUND);
					boosterExecutor.stealth (stealthEffect);
				}

			} else if (collider.gameObject.name.Contains ("Speed")) {
				if (!CentralVariables.SpeedBooster) {
					GameManager.Instance.ChangeSoundState (GameManager.SoundState.SPEEDSOUND);
					boosterExecutor.SpeedBooster (speedEffect);
				}
			}			
			collider.gameObject.SetActive (false);
		} 
		else if (collider.gameObject.tag == "right" && CentralVariables.tutorialActionCount < 0) {

			//if(!tutorial)
			//	tutorial = GameObject.FindGameObjectWithTag ("tutorial");
			//anim.enabled = false;
			playerMov.enabled = false;
			CentralVariables.tutorialActionCount++;
			tutorial.transform.GetChild (0).gameObject.SetActive (true);
		}
		else if(collider.gameObject.tag == "left" && CentralVariables.tutorialActionCount < 1)
		{
			//animationController.enabled = false;
			playerMov.enabled = false;
			CentralVariables.tutorialActionCount++;
			tutorial.transform.GetChild (1).gameObject.SetActive (true);
		}
		else if(collider.gameObject.tag == "jump" && CentralVariables.tutorialActionCount < 2)
		{
			//animationController.enabled = false;
			playerMov.enabled = false;
			CentralVariables.tutorialActionCount++;
			tutorial.transform.GetChild (2).gameObject.SetActive (true);
		}
		else if(collider.gameObject.tag == "down" && CentralVariables.tutorialActionCount < 3)
		{
			//animationController.enabled = false;
			playerMov.enabled = false;	
			CentralVariables.tutorialActionCount++;
			tutorial.transform.GetChild (3).gameObject.SetActive (true);
		}
			

	}

	#endregion


	void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.tag == "Hurdle" || collider.gameObject.transform.parent.gameObject.tag == "Hurdle") {
			if (!CentralVariables.isDead && !CentralVariables.Stealth && !CentralVariables.isReviving && !isCollided && !CentralVariables.SpeedBooster && !CentralVariables.GameStart) {

				Debug.Log ("Hurdle Hit");
				GameManager.Instance.ChangeSoundState (GameManager.SoundState.HIT);
				//Camera.main.GetComponent<GameEnd> ().enabled = true;
				animationController.PlayerDeath ();
				StartCoroutine (isCollidedDeactivate ());
				isCollided = true;
				animationController.EndAll ();
				boosterExecutor.disableBoosters ();
				CentralVariables.IsRunning = false;

				//ragdoll.SetActive (true);
				playerMov.playerMesh.SetActive (false);
				//playerMov.playerMeshRenderer.enabled = false;
				//playerBody.SetActive (false);
				//Camera.main.gameObject.transform.LookAt (playerBody.transform);
				//deathEffect.SetActive (true);
				//deathEffect.GetComponent<ParticleSystem> ().Play ();
				//StartCoroutine (DeactivatDeathEffect ());
				//Camera.main.gameObject.GetComponent<GameEnd> ().Catch ();

			}
		} else if (collider.gameObject.tag == "Floor") {

			if (CentralVariables.rampJump) {

				Rigidbody r = GetComponent<Rigidbody> ();
				RigidbodyConstraints rc;
				rc = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
				r.useGravity = false;
				r.constraints = rc;
				CentralVariables.rampJump = false;
				animationController.anim.speed = 1f;
				if (CentralVariables.Stealth || CentralVariables.isReviving)
					playerMov.DisableCollision ();
			}

		} else if (collider.gameObject.tag == "glass") {
		
			if (!glassCollision) {
				GameManager.Instance.ChangeSoundState (GameManager.SoundState.GLASSBREAK);
				ActivateGlass (collider.gameObject.transform.parent.gameObject);
				glassCollision = true;
				//Camera.main.GetComponent<SmoothFollowCSharp> ().enabled = true;
			}
		
		}

	


	}

	public void ActivateGlass(GameObject  glass)
	{
		GameObject g=null;
		int r;
		int childCount = glass.transform.childCount;
		for(int i=0;i< childCount;i++) { 

			g = glass.transform.GetChild (i).gameObject;
			if (i == 0)
				g.SetActive (true);
			else {
				r = Random.Range (3, 7);
				g.AddComponent<Rigidbody> ();	
				g.GetComponent<Rigidbody> ().AddForce (-Vector3.right*r,ForceMode.Impulse);
			}
		}


	}


	#region ActivateDeactivate

	IEnumerator isCollidedDeactivate( )
	{		
		yield return new WaitForSeconds (2.0f);
		isCollided = false;
	}

	IEnumerator ActivateObjectCoin(GameObject coin)
	{
		coin.SetActive (false);
		//coinEffect.SetActive (true);
		//coinEffect.GetComponent<ParticleSystem> ().Play ();
		yield return new WaitForSeconds (0.1f);
		//coinEffect.SetActive (false);


		yield return new WaitForSeconds (0.9f);
		coin.SetActive (true);


	}

	IEnumerator ActivateObject(GameObject obj)
	{		
		obj.SetActive (false);
		yield return new WaitForSeconds (5f);
		obj.SetActive (true);
		
		
	}

	IEnumerator DeactivatDeathEffect( )
	{
		
		yield return new WaitForSeconds (3.0f);
		deathEffect.SetActive (false);
		
	}

	public void wait()
	{
		return;
	}

	#endregion







}
