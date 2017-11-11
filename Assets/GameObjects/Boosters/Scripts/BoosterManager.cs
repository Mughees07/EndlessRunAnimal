using UnityEngine;
using System.Collections;

public class BoosterManager : MonoBehaviour {

	// Use this for initialization	
	public Transform [] boosterPoints;
	public GameObject[] boosters;
	int lastBoosterId = 0;
	int randomBoosterId=0;

	void Start () {



	}
	bool isCollected = false; 

	void OnTriggerEnter(Collider other) {

			
		
		}		


	public void AddBooster()
	{
		boosters = new GameObject[CentralVariables.patchBoostersCount];
		
		int i = 0;
		

		
		foreach (Transform point in boosterPoints) {
			
			
			randomBoosterId = Random.Range (0,CentralVariables.PoolBoostersCount-1);
			if(randomBoosterId==lastBoosterId)
				randomBoosterId = Random.Range (0,CentralVariables.PoolBoostersCount-1);

			//randomBoosterId = 4;
			boosters[i]=BoosterPool.instance.GetBoosterObjectForId(randomBoosterId,true,point.position);	
			boosters[i].transform.SetParent (point);

			//if (CentralVariables.TimeSeconds < 20)
				//boosters [i].SetActive (false);
			//else
				boosters [i].SetActive (true);
		

			i++;		
			
			
		}

		
	}
	
	
	public void RemoveBoosters()
	{
		foreach (GameObject b in boosters) {
			BoosterPool.instance.PoolObject (b);
		}

		
	}



}
