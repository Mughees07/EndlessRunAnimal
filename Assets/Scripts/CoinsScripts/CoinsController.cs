using UnityEngine;
using System.Collections;

public class CoinsController : MonoBehaviour {


	public GameObject coinCollectEffect;
	GameObject target;

	bool moveTowardsPlayer=false;



	void Start()
	{

		target=GameObject.FindGameObjectWithTag("Player").transform.FindChild("CoinRefrence").gameObject;
	}

	void OnEnable(){

		//coinCollectEffect.SetActive(false);
		moveTowardsPlayer=false;
	}

	void OnTriggerEnter(Collider other) {

	 if (other.gameObject.tag == "MagnetTrigger") {
			
			moveTowardsPlayer=true;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(moveTowardsPlayer)
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 30f*Time.deltaTime);			
	}

//	IEnumerator wait()
//	{	
//		yield return new WaitForSeconds (1.0f);
//		moveTowardsPlayer = false;
//
//
//
//	}




}
