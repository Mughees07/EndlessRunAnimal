using UnityEngine;
using System.Collections;

public class DogCatcherMovement : MonoBehaviour {


	Animator anim;
	Animator playerAnim;
	public GameObject dogHand;
	public GameObject player;
	Vector3 newPos;

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerAnim = player.GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		newPos = transform.position;		
		newPos.y=Mathf.Clamp (newPos.y, 0f, 0f);
		transform.position = newPos;
	}

	public void PickDog()
	{
		playerAnim.SetBool ("ragdoll",true);
		player.transform.SetParent (dogHand.transform);
		player.transform.localPosition = Vector3.zero;
		player.transform.localRotation = Quaternion.identity;
		playerAnim.SetBool ("ragdoll",false);
	}
}
