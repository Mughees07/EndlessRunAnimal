using UnityEngine;
using System.Collections;

public class rampJumpTrigger : MonoBehaviour {

	Rigidbody r ;
	RigidbodyConstraints rc;
	public bool isCollided;

	public Character_Animation_Controller animController;

	void Start()
	{
		animController = GameObject.FindGameObjectWithTag ("PlayerBody").GetComponent<Character_Animation_Controller> ();
	}
	// Use this for initialization
	public void OnTriggerEnter(Collider other)
	{
		GameObject tmp = other.gameObject.transform.root.gameObject;

		if (other.gameObject.tag!="MagnetTrigger" && tmp.tag == "Player") {
		
			if(!isCollided )
			{
				if (CentralVariables.isReviving || CentralVariables.Stealth)
					GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ().EnableCollision ();
				
			r = tmp.GetComponent<Rigidbody> ();			 
			rc = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
			r.constraints = rc;
			r.useGravity = true;
			
			isCollided=true;

			StartCoroutine (EnableConstraint ());
			}
		
		}

	}


	IEnumerator EnableConstraint()
	{
		yield return new WaitForSeconds (0.2f);
		animController.anim.SetBool ("isJump", true);
		animController.anim.speed=0.8f;
		CentralVariables.rampJump = true;
		//yield return new WaitForSeconds (1.0f);
		isCollided = false;
	
	}
}
