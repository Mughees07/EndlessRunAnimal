using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	GameObject player;
	public GameObject readyToGo;
	public Transform []path;

	float percentsPerSecond = 0.3f; // % path moved per second
	float currentPathPercent = 0.0f;

	bool idle;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		idle = true;
		Time.timeScale = 0.8f;

		readyToGo=GameObject.FindGameObjectWithTag ("ReadyToGO");
		readyToGo.GetComponent<ReadyToGO> ().Go ();
		//iTween.DrawPath(path);	
		//StartCoroutine(StartGame());
		//GetComponent<SmoothFollowCSharp> ().enabled = true;


	
	}
	void OnDrawGizmos(){
		//iTween.DrawPath(path);	
		//iTween.DrawPathGizmos (path);
		//	Debug.Log ("Path Drawn");
	}
	public void Update()
	{		
//		if (!idle) {
//			currentPathPercent += percentsPerSecond * Time.deltaTime;
//			iTween.PutOnPath (player, path, currentPathPercent);
//			iTween.MoveUpdate (Camera.main.gameObject, iTween.Hash ("position", Camera.main.gameObject.transform.position, "time", 3, "looktarget", player.transform.position));
//			iTween.RotateTo (player, iTween.Hash ("y", 0, "time", 3, "easetype", iTween.EaseType.linear));
//			iTween.ValueTo (gameObject, iTween.Hash ("from", 60, "to", 80, "time", 1, "onUpdate", "animateFieldOfView", "easetype", "easeinoutcubic"));
//			iTween.ValueTo (gameObject, iTween.Hash ("from", 80, "to", 60, "time", 2, "delay", 1, "onUpdate", "animateFieldOfView", "easetype", "easeinoutcubic"));
//		}
	}

	public void animateFieldOfView( float newFieldOfView){
		Camera.main.fieldOfView = newFieldOfView;
	}

	public IEnumerator StartGame()
	{
		yield return new WaitForSeconds (0.3f);
		player.GetComponentInChildren<Animator> ().enabled = true;
		yield return new WaitForSeconds (2f);
		idle = false;
		yield return new WaitForSeconds (3f);	

		FaddingMenu.Instance.FadeIn ();
		yield return new  WaitForSeconds (0.5f);
		readyToGo.GetComponent<ReadyToGO> ().Go ();
		Time.timeScale = 1f;



		this.enabled = false;
	}





//	public bool moving1 = false;
//	public bool moving2 = false;
//
//	IEnumerator MovePlayer(Vector3 pointA, Vector3 pointB, float time){
//		if (!moving){ // do nothing if already moving`
//			moving = true; // signals "I'm moving, don't bother me!"
//			float t = 0f;
//			while (t < 1f){
//				t += Time.deltaTime / time; // sweeps from 0 to 1 in time seconds
//				player.transform.position = Vector3.Lerp(pointA, pointB, t); // set position proportional to t
//				yield return 0; // leave the routine and return here in the next frame
//			}
//			moving = false; // finished moving
//
//		}
//	}
//
//		IEnumerator MoveCatcher(Vector3 pointA, Vector3 pointB, float time){
//			if (!moving1){ // do nothing if already moving`
//				moving1 = true; // signals "I'm moving, don't bother me!"
//				float t = 0f;
//				while (t < 1f){
//				t += Time.deltaTime / time; // sweeps from 0 to 1 in time seconds
//					catcher.transform.position= Vector3.Lerp(pointA, pointB, t); // set position proportional to t
//					yield return 0; // leave the routine and return here in the next frame
//				}
//				moving1 = false; // finished moving
//			//enabled=false;
//
//			GetComponent<SmoothFollowCSharp>().enabled=true;
//
//			}
//		}


}
