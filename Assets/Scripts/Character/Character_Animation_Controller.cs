using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character_Animation_Controller : MonoBehaviour {

	public Animator anim;
	private Vector2 startPos;
	GameObject player;

	private Vector2 fp; 
	private Vector2 lp;

	private float dragDistance;
	private List<Vector3>touchPositions;
	float minSwipeDistY = 15;
	float minSwipeDistX = 10;



	int tutorialCount=0;
	GameObject tutorial;

	public GameObject ragdoll;

	public bool isJump;

	public bool isLeftPressed;
	public bool isRightPressed;

	private AudioSource Run_Sound;


	public GameObject skitDust;

	PlayerMovement playerMove;


	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();

		player =  GameObject.FindGameObjectWithTag("Player");
		//Run_Sound= player.GetComponentInChildren<AudioSource> ();

		tutorial = GameObject.FindGameObjectWithTag ("tutorial");
	
		dragDistance = 50;
		isLeftPressed = false;
		isRightPressed = false;
		touchPositions = new List<Vector3> ();
		dragDistance = Screen.height*20/100;
		playerMove = player.GetComponent<PlayerMovement>();
	}


	void forMobile()
	{
		//isJump = false;
		//player.GetComponent<PlayerMovement>().isJump=false;
		if (Input.touchCount > 0) 
		{
			Touch touch = Input.touches[0];

			switch (touch.phase) 
			{
			case TouchPhase.Began:

				startPos = touch.position;
				break;

			case TouchPhase.Moved:

				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;


				if (swipeDistHorizontal > minSwipeDistX && swipeDistHorizontal>swipeDistVertical) 
				{

					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

					if (swipeValue > 0) {//right swipe
						playerMove.RightSwipe ();
						//anim.SetBool ("isRight", true);	

						anim.SetBool ("isJump", false);
						anim.SetBool("isDown",false);
						//anim.SetBool ("isLeft", false);


					} else if (swipeValue < 0) {//left swipe
						playerMove.LeftSwipe ();
						anim.SetBool ("isLeft", true);
						anim.SetBool ("isJump", false);
						anim.SetBool("isDown",false);
						anim.SetBool ("isRight", false);

					}

				}
				else if (swipeDistVertical > minSwipeDistY && swipeDistHorizontal< swipeDistVertical) 
				{

					float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

					if (swipeValue > 0)//up swipe
					{
						
						anim.SetInteger("Jump_Selector",Random.Range(0,2));
						anim.SetBool ("isJump", true);
						anim.SetBool("isDown",false);
						anim.SetBool ("isRight", false);
						anim.SetBool ("isLeft", false);

						GameManager.Instance.ChangeSoundState (GameManager.SoundState.JUMP_SOUND);



					} 

					if (swipeValue < 0)//down swipe
					{
						

						anim.SetBool("isDown",true);
						anim.SetBool ("isJump", false);
						anim.SetBool ("isRight", false);
						anim.SetBool ("isLeft", false);

						GameManager.Instance.ChangeSoundState (GameManager.SoundState.SLIDESOUND);
					

					}
				
				}

		
				break;
			}
		}





	}




	void forComputer()
	{



		if (Input.GetKeyUp(KeyCode.UpArrow)) {

			//anim.SetBool ("isRight", false);
			//anim.SetBool ("isLeft", false);

			anim.SetInteger("Jump_Selector",Random.Range(0,2));
			anim.SetBool ("isJump", true);
			anim.SetBool("isDown",false);
			anim.SetBool ("isRight", false);
			anim.SetBool ("isLeft", false);
		
			//			hudlistener.jump.SetActive(false);
	
			//playerMove.enabled=true;
			//playerMove.isJump=true;
			//GameManager.Instance.ChangeState(GameManager.SoundState.JumpSound);
			//Run_Sound.Stop ();
			//player.GetComponentInChildren<Animator>().enabled=true;
			GameManager.Instance.ChangeSoundState (GameManager.SoundState.JUMP_SOUND);
		} 
		else if (Input.GetKeyUp (KeyCode.DownArrow)) {
			
			anim.SetBool("isDown",true);
			anim.SetBool ("isJump", false);
			anim.SetBool ("isRight", false);
			anim.SetBool ("isLeft", false);
			//anim.SetInteger("Slide_Selector",Random.Range(1,3));

			GameManager.Instance.ChangeSoundState (GameManager.SoundState.SLIDESOUND);
				
			//GameManager.Instance.ChangeState(GameManager.SoundState.SkidSound);
			//Run_Sound.Stop ();


			//skitDust.SetActive(true);
			//skitDust.GetComponent<ParticleSystem>().Play();

			//player.GetComponentInChildren<Animator>().enabled=true;

		}

		else if (Input.GetKeyUp(KeyCode.LeftArrow)) {
			
			playerMove.LeftSwipe();		
			//anim.SetBool ("isLeft", true);
			anim.SetBool("isDown",false);
			anim.SetBool ("isJump", false);
			//anim.SetBool ("isRight", false);	

		}
		else if(Input.GetKeyUp (KeyCode.RightArrow)) {			
			playerMove.RightSwipe();
			//anim.SetBool ("isRight", true);	
			anim.SetBool("isDown",false);
			anim.SetBool ("isJump", false);
			//anim.SetBool ("isLeft", false);	
		}

	}

	public void IsIdle(bool Check)
	{
		anim.SetBool ("IsIdle", Check);			

	}


	public void PlayerDeath()
	{
		GameObject g=  GameObject.Instantiate (ragdoll);
		g.transform.SetParent (transform);
		g.transform.localPosition = Vector3.zero;
		Destroy (g, 3f);
		CentralVariables.isDead = true;
		//anim.SetBool ("isDead", true);
		StartCoroutine(WaitForDeath(2f));
//		if (CentralVariables.PlayerTotalCoins >= CentralVariables.reviveValue)
//			MainMenuManager.Instance.showReviveMenu ();
//		else
//			MainMenuManager.Instance.gameOver(true);

	}

	IEnumerator WaitForDeath(float duration)
	{

		yield return new WaitForSeconds (duration);
	

		if (CentralVariables.PlayerTotalCoins >= CentralVariables.reviveValue)
			MainMenuManager.Instance.showReviveMenu ();
		else
			MainMenuManager.Instance.gameOver(true);

//		Vector3 newPos = transform.position;
//		newPos.x = 0;
//		transform.position = newPos;
//		GetComponent<PlayerMovement> ().currentMovementindex = 0;


	}


	// Update is called once per frame
	void Update () {
		


	
		if (CentralVariables.IsRunning ) {
			{

				if (CentralVariables.isTutorialSeen) {
					#if UNITY_EDITOR
					forComputer();
					#else
					forMobile();
					#endif
				}
				else 
				{
					#if UNITY_EDITOR
					forComputerTutorial ();
					#else
					forMobileTutorial();
					#endif

				}
			}



		}
	}

	#region AnimationEvents




	public void EndAll()
	{
		anim.SetBool ("isJump", false);
		anim.SetBool ("isLeft", false);	
		anim.SetBool ("isRight", false);
		anim.SetBool ("isDown", false);

			}

	public void Dizzy()
	{
		//transform.parent.gameObject.GetComponent<PlayerCollisionController> ().deathEffect.SetActive (false);
	}

	#endregion


	#region tutorial

	void forComputerTutorial()
	{
		//if(!tutorial)
		//	tutorial = GameObject.FindGameObjectWithTag ("tutorial");
		if (Input.GetKeyUp(KeyCode.UpArrow)  && CentralVariables.tutorialActionCount==2) {	

			if (tutorialCount < 3) {
		
				anim.SetInteger("Jump_Selector",Random.Range(0,2));
				anim.SetBool ("isJump", true);
				anim.SetBool ("isDown", false);
				anim.SetBool ("isRight", false);
				anim.SetBool ("isLeft", false);
		
				GameManager.Instance.ChangeSoundState (GameManager.SoundState.JUMP_SOUND);

				GetComponent<Animator> ().enabled = true;
				playerMove.enabled = true;
				tutorial.transform.GetChild (CentralVariables.tutorialActionCount).gameObject.SetActive (false);

				tutorialCount++;
			}
		} 
		else if (Input.GetKeyUp (KeyCode.DownArrow)   && CentralVariables.tutorialActionCount==3) {


				
				anim.SetBool ("isDown", true);
				anim.SetBool ("isJump", false);
				anim.SetBool ("isRight", false);
				anim.SetBool ("isLeft", false);

				GameManager.Instance.ChangeSoundState (GameManager.SoundState.SLIDESOUND);

				GetComponent<Animator> ().enabled = true;
				playerMove.enabled = true;
				CentralVariables.isTutorialSeen = true;

				tutorial.transform.GetChild (CentralVariables.tutorialActionCount).gameObject.SetActive (false);
				CentralVariables.SaveToFile ();

		}

		else if (Input.GetKeyUp(KeyCode.LeftArrow)  && CentralVariables.tutorialActionCount==1) {

			if (tutorialCount < 2) {
				GetComponent<Animator> ().enabled = true;
				playerMove.enabled = true;
				playerMove.LeftSwipe ();		
				anim.SetBool ("isLeft", true);
				anim.SetBool ("isDown", false);
				anim.SetBool ("isJump", false);
				anim.SetBool ("isRight", false);

				tutorial.transform.GetChild (CentralVariables.tutorialActionCount).gameObject.SetActive (false);
				tutorialCount++;
			}

		}
		else if(Input.GetKeyUp (KeyCode.RightArrow)   && CentralVariables.tutorialActionCount==0 ) {			
			if (tutorialCount < 1) {

				GetComponent<Animator> ().enabled = true;
				playerMove.enabled = true; 

				playerMove.RightSwipe ();
				//anim.SetBool ("isRight", true);	
				anim.SetBool ("isDown", false);
				anim.SetBool ("isJump", false);
				//anim.SetBool ("isLeft", false);	


				tutorial.transform.GetChild (CentralVariables.tutorialActionCount).gameObject.SetActive (false);
				tutorialCount++;
			}
		}

	}


	void forMobileTutorial()
	{
		//if(!tutorial)
		//	tutorial = GameObject.FindGameObjectWithTag ("tutorial");
		if (Input.touchCount > 0  ) 
		{
			Touch touch = Input.touches[0];

			switch (touch.phase) 
			{
			case TouchPhase.Began:

				startPos = touch.position;
				break;

			case TouchPhase.Moved:

				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;


				if (swipeDistHorizontal > minSwipeDistX && swipeDistHorizontal>swipeDistVertical) 
				{
					

					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

					if (swipeValue > 0  && CentralVariables.tutorialActionCount==0) {//right swipe

						if (tutorialCount < 1) {
							GetComponent<Animator> ().enabled = true;
							playerMove.enabled = true;
							playerMove.RightSwipe ();
							//anim.SetBool ("isRight", true);	
							anim.SetBool ("isJump", false);
							anim.SetBool ("isDown", false);
							//nim.SetBool ("isLeft", false);



							tutorialCount++;
							tutorial.transform.GetChild (CentralVariables.tutorialActionCount).gameObject.SetActive (false);
						}

					} else if (swipeValue < 0   && CentralVariables.tutorialActionCount==1) {//left swipe
						if (tutorialCount < 2) {

							GetComponent<Animator> ().enabled = true;
							playerMove.enabled = true;
							playerMove.LeftSwipe ();
							//anim.SetBool ("isLeft", true);
							anim.SetBool ("isJump", false);
							anim.SetBool ("isDown", false);
							//anim.SetBool ("isRight", false);

							tutorialCount++;
							tutorial.transform.GetChild (CentralVariables.tutorialActionCount).gameObject.SetActive (false);
						}
					}

				}
				else if (swipeDistVertical > minSwipeDistY && swipeDistHorizontal< swipeDistVertical) 
				{

					float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

					if (swipeValue > 0   && CentralVariables.tutorialActionCount==2)//up swipe
					{

						if (tutorialCount < 3) {
							//isJump=true;

							anim.SetInteger("Jump_Selector",Random.Range(0,2));
							anim.SetBool ("isJump", true);
							//anim.SetBool ("IsStanding", false);


							anim.SetBool ("isDown", false);
							anim.SetBool ("isRight", false);
							//anim.SetBool ("isLeft", false);

							GameManager.Instance.ChangeSoundState (GameManager.SoundState.JUMP_SOUND);

							//playerMove.isJump=true;
							//player.GetComponentInChildren<Animator>().enabled=true;

							tutorialCount++;
							GetComponent<Animator> ().enabled = true;
							playerMove.enabled = true;
							tutorial.transform.GetChild (CentralVariables.tutorialActionCount).gameObject.SetActive (false);
						}
					} 

					if (swipeValue < 0   && CentralVariables.tutorialActionCount==3)//down swipe
					{

						//anim.SetInteger("Slide_Selector",Random.Range(1,3));
						anim.SetBool("isDown",true);
						//anim.SetBool ("isJump", false);
						anim.SetBool ("isJump", false);
						//anim.SetBool ("isRight", false);
						//anim.SetBool ("isLeft", false);
						//skitDust.SetActive(true);
						//skitDust.GetComponent<ParticleSystem>().Play();
						//Invoke ("stopEffect",1f);
						GameManager.Instance.ChangeSoundState (GameManager.SoundState.SLIDESOUND);

						CentralVariables.isTutorialSeen=true;
						GetComponent<Animator> ().enabled = true;
						playerMove.enabled = true;
						tutorial.transform.GetChild (CentralVariables.tutorialActionCount).gameObject.SetActive (false);

						CentralVariables.SaveToFile ();
					//GameManager.Instance.ChangeState(GameManager.SoundState.SkidSound);
						}
						//Run_Sound.Stop ();
						//player.GetComponentInChildren<Animator>().enabled=true;
					}
				break;
				}


				
			}
		}

	#endregion 



	}



