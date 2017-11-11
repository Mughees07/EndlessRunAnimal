using UnityEngine;
using System.Collections;

public class CoinsSpawnManagerNew : MonoBehaviour {

	public GameObject []coinsCollection;
	
	private float DistanceSpawn = 600;
	private float nextDistance =0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(GameConstants.GameVariable.DISTANCE > nextDistance){
			SpawnCoins( nextDistance);
			nextDistance +=DistanceSpawn;
			
		}
		
	}
	
	public void SpawnCoins( float z){
		Vector3 position; 
		position = new Vector3(Random.Range(-4,4),0f,z+DistanceSpawn/*Random.Range(z,z+DistanceSpawn)*/);
		
//		int randomPowerUpType = Random.Range(0,coinsCollection.Length);
//		coinsCollection[randomPowerUpType].Spawn(position,Quaternion.identity) ;
//		


		int rand = Random.Range(0,3);
		int count =0;
		
		while(coinsCollection[rand].activeSelf && count< coinsCollection.Length){
			count++;
			rand = Random.Range(0,3);
		}
		
		coinsCollection[rand].transform.position = position;
		coinsCollection[rand].SetActive(true);

	}
}
