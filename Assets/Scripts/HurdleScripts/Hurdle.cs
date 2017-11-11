using UnityEngine;
using System.Collections;

public class Hurdle : MonoBehaviour {

	float zDistance = 50;
	GameObject player;
	public bool jumpTrigger=false;
	public bool slideTrigger=false;
	GameObject Hud1;
	//HudMenuLocalize hudlistener;

	GameObject Player;
	void Start()
	{
		slideTrigger = false;
		jumpTrigger = false;

	

	}

	void FixedUpdate () {
		
		if(player == null){
			player = GameObject.FindGameObjectWithTag("Player");
			
		}
		
		float dist = player.transform.position.z - transform.position.z;
		if(dist>zDistance){
			gameObject.SetActive(false);
		}

	
		
	}

	public void Remove()
	{
		//Debug.Log("coming: Remove");
		Hud1=GameObject.FindGameObjectWithTag("Hud");
		if(Hud1 != null)
		{
			//Debug.Log("Hud1: OK ");
			Hud1.GetComponent<HUDMenuController>().left.SetActive(false);
			Hud1.GetComponent<HUDMenuController>().right.SetActive(false);
		}
		if(player != null)
		{
			//Debug.Log("player: OK ");
			//player.GetComponent<CarMovement>().enabled=true;
			player.GetComponentInChildren<Animator>().enabled=true;
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "JumpNow") {

		 	//player.GetComponent<CarMovement>().enabled=false ;
			player.GetComponentInChildren<Animator>().enabled=false;
			Hud1=GameObject.FindGameObjectWithTag("Hud");
			Hud1.GetComponent<HUDMenuController>().jump.SetActive(true);
			Hud1.GetComponent<HUDMenuController>().slide.SetActive(false);
			


			} 
		else if (other.tag == "SlideNow") {

			//player.GetComponent<CarMovement>().enabled=false ;
			player.GetComponentInChildren<Animator>().enabled=false;

			Hud1=GameObject.FindGameObjectWithTag("Hud");
			Hud1.GetComponent<HUDMenuController>().slide.SetActive(true);
			Hud1.GetComponent<HUDMenuController>().jump.SetActive(false);


			} 

		else if (other.tag == "TiltRight") {
			//CarMovement.isFlagEnabled = false;
			//player.GetComponent<CarMovement>().enabled=false ;
			player.GetComponentInChildren<Animator>().enabled=false;

			Hud1=GameObject.FindGameObjectWithTag("Hud");
			Hud1.GetComponent<HUDMenuController>().slide.SetActive(false);
			Hud1.GetComponent<HUDMenuController>().jump.SetActive(false);
			Hud1.GetComponent<HUDMenuController>().right.SetActive(true);
			Hud1.GetComponent<HUDMenuController>().left.SetActive(false);


		} 
		else if (other.tag == "TiltLeft") {
			//CarMovement.isFlagEnabled = false;
			//player.GetComponent<CarMovement>().enabled=false ;
			player.GetComponentInChildren<Animator>().enabled=false;

			Hud1=GameObject.FindGameObjectWithTag("Hud");
			Hud1.GetComponent<HUDMenuController>().slide.SetActive(false);
			Hud1.GetComponent<HUDMenuController>().jump.SetActive(false);
			Hud1.GetComponent<HUDMenuController>().right.SetActive(false);
			Hud1.GetComponent<HUDMenuController>().left.SetActive(true);

		} 
	}

}



