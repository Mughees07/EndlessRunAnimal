using UnityEngine;
using System.Collections;

public class CatchTrigger : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void OnTriggerEnter(Collider collider){

		if(collider.gameObject.tag=="Catcher")
		{
			if (CentralVariables.isDead) {
				anim = collider.gameObject.GetComponent<Animator> ();
				anim.SetBool ("catch", true);
			}

			//Camera.main.GetComponent<GameEnd>().Catch();
		}
		
	}
}
