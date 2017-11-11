using UnityEngine;
using System.Collections;

public class VehicleMovement : MonoBehaviour {

	// Use this for initialization

	public Transform moveTowardsPosition;
	public Transform movePassPosition;
	public GameObject vehicle;
	public AudioSource source;

	public bool moving = false;
	Vector3 startPos;
	 void Start()
	{
		source = vehicle.GetComponent<AudioSource> ();
	}

	void Update()
	{
		if (source) {
			if (CentralVariables.isDead || CentralVariables.isPaused)
				source.enabled = false;
			else
				source.enabled = true;
		}

	}


	public void checkMode()
	{
		if(CentralVariables.DIFFICULTY_MODE == CentralVariables.EASY_MODE)
			CentralVariables.VehicleMovementTime=3f;
		else if(CentralVariables.DIFFICULTY_MODE == CentralVariables.MEDIUM_MODE)
			CentralVariables.VehicleMovementTime=2f;
		else if(CentralVariables.DIFFICULTY_MODE == CentralVariables.HARD_MODE)
			CentralVariables.VehicleMovementTime=1f;

	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.transform.root.gameObject.tag == "Player") {	
			Debug.Log ("Vehicle Movement Start");
			checkMode();

			if (this.gameObject.transform.parent.gameObject.tag == "CrossVehicle") {
				generateRandom ();
			}
			else
			{
				StartCoroutine (MoveFromTo (vehicle.transform.localPosition, moveTowardsPosition.localPosition, CentralVariables.VehicleMovementTime));	
			}
		}
	}

	public void generateRandom()
	{
		//vehicle.transform.position = startPos;
		int number=Random.Range (0,vehicle.transform.childCount);
		int variation = Random.Range (0, 2);
		for(int i=0;i<vehicle.transform.childCount;i++)
		{
			if (i != number)
				vehicle.transform.GetChild (i).gameObject.SetActive (false);
			else
				vehicle.transform.GetChild (i).gameObject.SetActive (true);
		}
		Vector3 newPos = vehicle.transform.localPosition;
		Vector3 newPos1;
		if(variation==0)
			newPos1=moveTowardsPosition.localPosition;
		else
			newPos1=movePassPosition.localPosition;
		
		newPos.z = newPos1.z;
		moveTowardsPosition.localPosition = newPos;

		StartCoroutine (MoveFromTo (vehicle.transform.localPosition, moveTowardsPosition.localPosition, 2f+number));

	}

	IEnumerator MoveFromTo(Vector3 pointA, Vector3 pointB, float time){
		if (!moving){ // do nothing if already moving`
			moving = true; // signals "I'm moving, don't bother me!"
			float t = 0f;

			while (t < 1f){
				if (CentralVariables.isDead)
					yield break;
				t += 0.02f/ time; // sweeps from 0 to 1 in time seconds
				//Debug.Log(Time.deltaTime);
				//t+=0.004f;
				vehicle.transform.localPosition = Vector3.Lerp(pointA, pointB, t); // set position proportional to t
				yield return 0; // leave the routine and return here in the next frame
			}
			moving = false; // finished moving
		}
	}
}
