using UnityEngine;
using System.Collections;

public class rampJump : MonoBehaviour {

	// Use this for initialization
	public Character_Animation_Controller animController;

	void Start()
	{
		animController = GameObject.FindGameObjectWithTag ("PlayerBody").GetComponent<Character_Animation_Controller> ();
	}

	public void OnTriggerEnter(Collider other)
	{
//		if (other.gameObject.transform.root.gameObject.tag == "Player") {
//			
//			animController.anim.SetBool ("isJump", true);
//			animController.anim.SetInteger("Jump_Selector",Random.Range(1,2));
//			//animController.anim.speed=0.8f;
//		}


	}

}
