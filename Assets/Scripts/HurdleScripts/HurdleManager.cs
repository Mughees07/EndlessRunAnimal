using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class HurdlePositionVariation
{

	public Transform[] HurdleVariation;
	public Transform[] VehicleVariation;

}

public class HurdleManager : MonoBehaviour {
	
	public HurdlePositionVariation[] hurdlePoints;
	public GameObject[] hurdles;
	public GameObject[] vehicles;

	public GameObject tutorialhurdles;

	public GameObject butterFlyEffect;
	public GameObject rainEffect;



	 int lastVehicleId=0;
	int randomVehicleId=0;

	int lastHurdleId = 0;
	int randomHurdleId=0;
	// Update is called once per frame
	int hurdleDistanceVariation;

	public Vector3 crossVehiclePosition;
	public GameObject crossVehicle;




	public void AddHurdles()
	{
//
//		if (CentralVariables.TimeSeconds % 3 == 0) {	
//		
//			if (CentralVariables.isDay)
//				butterFlyEffect.SetActive (true);
//			else
//				rainEffect.SetActive (true);
//		} 
		//if(CentralVariables.

		hurdles = new GameObject[CentralVariables.patchHurdlesCount];

		int i = 0;

		 hurdleDistanceVariation=Random.Range (0,1);

		foreach (Transform point in hurdlePoints[hurdleDistanceVariation].HurdleVariation) {


			randomHurdleId = Random.Range (0,CentralVariables.PoolHurdlesCount-1);
			if(randomHurdleId==lastHurdleId)
					randomHurdleId = Random.Range (0,CentralVariables.PoolHurdlesCount-1);
			
			hurdles[i]=HurdlesPool.instance.GetHurdleObjectForId(randomHurdleId,true,point.position);	
			hurdles[i].transform.SetParent (point);

				//hurdles[i].SetActive(false);

			
			i++;
			lastHurdleId = randomHurdleId;
		



		}

		AddVehicles ();

	}


	public void RemoveHurdles()
	{
		butterFlyEffect.SetActive (false);
		rainEffect.SetActive (false);
		foreach (GameObject h in hurdles) {
			HurdlesPool.instance.PoolHurdleObject (h);
		}
		RemoveVehicles ();

	}


	public void AddVehicles()
	{
		int j = 0;
		int i = 0;
		vehicles=  new GameObject[CentralVariables.patchVehiclesCount];
		foreach (Transform point in hurdlePoints[hurdleDistanceVariation].VehicleVariation) {
	
			if (i != 2) {
				randomVehicleId = Random.Range (0, CentralVariables.PoolVehicleCount - 1); 
				if (randomHurdleId == lastVehicleId)
					randomVehicleId = Random.Range (0, CentralVariables.PoolVehicleCount - 1); 
			
				vehicles [j] = HurdlesPool.instance.GetVehicleObjectForId (randomVehicleId, true, point.position);	
				vehicles [j].transform.SetParent (point);
				j++;
				lastVehicleId = randomVehicleId;
			}

			i++;

		}

		//crossVehiclePosition = crossVehicle.transform.localPosition;
	}


	public void RemoveVehicles()
	{
		crossVehicle.transform.localPosition = crossVehiclePosition;
		foreach (GameObject v in vehicles) {
			HurdlesPool.instance.PoolVehicleObject(v);
		}
	}


}
