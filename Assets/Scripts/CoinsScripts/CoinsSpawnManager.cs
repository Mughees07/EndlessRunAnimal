	using UnityEngine;
using System.Collections;

public class CoinsSpawnManager : MonoBehaviour {

	public GameObject []coinsCollection;

	private float DistanceSpawn = 200;
	private float nextDistance =0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if((GameConstants.GameVariable.DISTANCE/3) > nextDistance){
			SpawnCoins( nextDistance);
			nextDistance +=DistanceSpawn;
			
		}
		
	}
	
	public void SpawnCoins( float z){
		Vector3 position; 
		position = new Vector3(0,-1.5f,z+DistanceSpawn/*Random.Range(z,z+DistanceSpawn)*/);
		
		int randomPowerUpType = Random.Range(0,coinsCollection.Length);
		coinsCollection[randomPowerUpType].Spawn(position,Quaternion.identity) ;
		
		
	}


}
