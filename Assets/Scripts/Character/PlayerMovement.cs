using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public GameObject playerBody; // to get active transform
	public GameObject playerMesh;
	public SkinnedMeshRenderer playerMeshRenderer;
	public ReadyToGO readyToGo;
	GameObject mainCamera;
	//public GameObject ragdoll;


	//leftRightMovement

	public bool isMovingLeftOrRight=false;

	public float movementSpeed;
	public bool movingRight;
	Vector3 targetPosition;


	//Speed Control

	BoxCollider []bx;

	public Vector3 newPos;




	void Start () {
		if (!player)
		player = GameObject.FindGameObjectWithTag ("Player");


		mainCamera = Camera.main.gameObject;
		//playerMeshRenderer = playerMesh.GetComponent<SkinnedMeshRenderer> ();

//		Run_Sound=player.GetComponentInChildren<AudioSource> ();
//		Run_Sound.Stop ();	
//		isJump = false;
		playerBody=GameObject.FindGameObjectWithTag("PlayerBody");
		playerMesh=GameObject.FindGameObjectWithTag("PlayerMesh");
		bx=playerBody.GetComponentsInChildren<BoxCollider> ();
		ResetLeftRight ();
		InvokeRepeating("IncreaseSpeed", 1.0f, 1.0f);
	}


	//Difficulty Mode
	public void changeMode(int modeNumber)
	{

		switch (modeNumber) {

		case 0:
			CentralVariables.DIFFICULTY_MODE = CentralVariables.EASY_MODE;
			CentralVariables.VehicleMovementTime=5f;
			break;
		case 1:
			CentralVariables.DIFFICULTY_MODE = CentralVariables.MEDIUM_MODE;
			CentralVariables.VehicleMovementTime=3f;
			break;
		case 2:
			CentralVariables.DIFFICULTY_MODE = CentralVariables.HARD_MODE;
			CentralVariables.VehicleMovementTime=2f;
			break;
		}
	}

	#region PlayerAcceleration

	public void IncreaseSpeed()
	{
		CentralVariables.TimeSeconds++;
		if(CentralVariables.CURRENT_SPEED <= CentralVariables.MAX_SPEED)
			CentralVariables.CURRENT_SPEED += CentralVariables.increamentFactor;
		

		if (CentralVariables.TimeSeconds==1)
			changeMode (0);
		else if(CentralVariables.TimeSeconds >= CentralVariables.MODE_CHANGETIME_MEDIUM)
			changeMode (1);
		else if(CentralVariables.TimeSeconds >= CentralVariables.MODE_CHANGETIME_HARD)
			changeMode (2);

		//if (CentralVariables.TimeSeconds % 30 == 0)
		//	GameManager.Instance.ChangeSoundState (GameManager.SoundState.BARK);	
		
			}




	// Update is called once per frame
	void FixedUpdate () {

		if(!CentralVariables.isDead)
		controlPlayerAccelration();


	}

	void controlPlayerAccelration(){	

			 newPos = transform.position;

		newPos.y=Mathf.Clamp (newPos.y, 0f, 50f);

		newPos.z +=  CentralVariables.CURRENT_SPEED * Time.deltaTime;

		if (isMovingLeftOrRight) {		
			if (!movingRight) {
				newPos.x -= 2  *movementSpeed* Time.deltaTime;
					
			} else if (movingRight) {
				newPos.x += 2  *movementSpeed* Time.deltaTime;						
			}


			float val=Mathf.Abs(CentralVariables.currentMovementindex - newPos.x);

			if (val < 0.1f)  {
				newPos.x = CentralVariables.currentMovementindex;			
				isMovingLeftOrRight = false;
			}


		}

			transform.position = newPos;

	}


	public void ResetLeftRight()
	{

		isMovingLeftOrRight = false;
		CentralVariables.currentMovementindex = 0;
		newPos = transform.position;
		newPos.x = 0;
		transform.position = newPos;
	
	}

	#endregion


	#region LeftRightMovement

	public void LeftSwipe(){
				Move (false);
			}


	public void RightSwipe(){
		Move (true);

	}




	public void Move(bool right)
	{
		
		if (right && CentralVariables.currentMovementindex < 2 && !isMovingLeftOrRight) {
			movingRight = right;
			isMovingLeftOrRight = true;
			//Invoke ("StopMovement",0.2f);
			CentralVariables.currentMovementindex+=2;
		} else if (!right && CentralVariables.currentMovementindex > -2 && !isMovingLeftOrRight) {
			isMovingLeftOrRight = true;
			movingRight = right;
			//StartCoroutine (MoveLeftRight (player.transform.position, Right.position, movementSpeed));		
			CentralVariables.currentMovementindex-=2;
		

		} else if (!isMovingLeftOrRight)
		{
			mainCamera.GetComponent<SmoothFollowCSharp> ().ShakeCamera (); ;

		}

	}



	#endregion

	public void RevivePlayer()
	{
		//playerBody.SetActive (true);
		//ragdoll.SetActive (false);
		//ragdoll.transform.position = Vector3.zero;
		//ragdoll.transform.rotation = Quaternion.identity;

		ResetLeftRight ();
		CentralVariables.isReviving = true;
//		Camera.main.GetComponent<SmoothFollowCSharp> ().enabled = true;
		//transform.parent.root.gameObject.SetActive (false);
		transform.parent = null;
		//GetComponent<Character_Animation_Controller> ().anim.SetBool ("isDead", false);
		transform.rotation = Quaternion.identity;
		Vector3 pos = transform.position;
		transform.position = new Vector3 (CentralVariables.currentMovementindex, 0, pos.z);
		Camera.main.GetComponent<Camera> ().fieldOfView = 60;

		DisableCollision();
		StartCoroutine(ReviveBlinking(10,0.2f));
	}

	IEnumerator ReviveBlinking(int numBlinks,float seconds)
	{

		for (int i=0; i<numBlinks*2; i++) {

			//toggle renderer
			//playerMeshRenderer.enabled = !playerMeshRenderer.enabled;
			playerMesh.SetActive(!playerMesh.activeSelf);
			//wait for a bit
			yield return new WaitForSeconds(seconds);
		}

		//make sure renderer is enabled when we exit
		//playerMeshRenderer.enabled = true;
		CentralVariables.isReviving = false;
		playerMesh.SetActive(true);
		EnableCollision ();
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
