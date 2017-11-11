using UnityEngine;
using System.Collections;

public class GameEnd : MonoBehaviour {

	// Use this for initialization


	GameObject player;
	//GameObject catcher;
	Vector3 toPoint;

	bool moving=false;
	bool orbit;

	void Start () {
	

		player = GameObject.FindGameObjectWithTag ("Player");
		//catcher = GameObject.FindGameObjectWithTag ("Catcher");

	}



	public void Catch()
	{
		orbit = true;
		GetComponent<SmoothFollowCSharp> ().enabled = false;

		toPoint = player.transform.position;
		toPoint.z -= 1;
		toPoint.y = 1;
	}


	void Update () {

		if (orbit) {

			transform.LookAt(player.transform);
			if(CentralVariables.currentMovementindex < 2)
			transform.RotateAround(player.transform.position,Vector3.up,-25f*Time.deltaTime);
			else 
				transform.RotateAround(player.transform.position,Vector3.up,25f*Time.deltaTime);

			GetComponent<Camera>().fieldOfView+=15f*Time.deltaTime;

			Vector3 pos=transform.position;
			pos.y+=Time.deltaTime/2;
			transform.position=pos;
		}
	
	}
}
