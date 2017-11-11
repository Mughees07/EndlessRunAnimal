using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class HurdlesPoolVariation
{

	public GameObject[] hurdlePrefabs;
	public GameObject[] VehiclePrefabs;

	public List<GameObject>[] pooledHurdlesObjects;
	public List<GameObject>[] pooledVehiclesObjects;
}


public class HurdlesPool : MonoBehaviour {

	public static HurdlesPool instance;

	/// <summary>
	/// The object prefabs which the pool can handle.
	/// </summary>
	public HurdlesPoolVariation[] objectPrefabs;

	/// <summary>
	/// The pooled objects currently available.
	/// </summary>


	/// <summary>
	/// The amount of objects of each type to buffer.
	/// </summary>
	public int[] amountToBuffer;

	public int defaultBufferAmount = 2;

	/// <summary>
	/// The container object that we will keep unused pooled objects so we dont clog up the editor with objects.
	/// </summary>
	protected GameObject containerObject;



	// Use this for initialization
	void Awake ()
	{
		instance = this;

		containerObject = new GameObject("HurdlesPool");

		//Loop through the object prefabs and make a new list for each one.
		//We do this because the pool can only support prefabs set to it in the editor,
		//so we can assume the lists of pooled objects are in the same order as object prefabs in the array


		int i = 0;
		for (int j = 0; j < 3; j++) {

			objectPrefabs[j].pooledHurdlesObjects = new List<GameObject>[objectPrefabs[j].hurdlePrefabs.Length];

			objectPrefabs[j].pooledVehiclesObjects = new List<GameObject>[objectPrefabs[j].VehiclePrefabs.Length];


			foreach (GameObject objectPrefab in objectPrefabs[j].hurdlePrefabs) {
				objectPrefabs[j].pooledHurdlesObjects [i] = new List<GameObject> (); 

				int bufferAmount;

				if (i < amountToBuffer.Length)
					bufferAmount = amountToBuffer [i];
				else
					bufferAmount = defaultBufferAmount;

				for (int n = 0; n < bufferAmount; n++) {
					GameObject newObj = Instantiate (objectPrefab) as GameObject;
					newObj.name = objectPrefab.name;
					PoolHurdleObject (newObj);
				}

				i++;
			}

			i = 0;

			foreach (GameObject objectPrefab in objectPrefabs[j].VehiclePrefabs) {
				objectPrefabs[j].pooledVehiclesObjects [i] = new List<GameObject> (); 

				int bufferAmount;

				if (i < amountToBuffer.Length)
					bufferAmount = amountToBuffer [i];
				else
					bufferAmount = defaultBufferAmount;

				for (int n = 0; n < bufferAmount; n++) {
					GameObject newObj = Instantiate (objectPrefab) as GameObject;
					newObj.name = objectPrefab.name;
					PoolVehicleObject (newObj);
				}

				i++;
			}

			i = 0;
		}
		Debug.Log ("Hurdle Pool Created");
	}



	#region hurdlePooling

	public GameObject GetHurdleObjectForId ( int i , bool onlyPooled , Vector3 position)
	{

		GameObject prefab = objectPrefabs[CentralVariables.DIFFICULTY_MODE].hurdlePrefabs[i];


		GameObject pooledObject = null;;

		while(true)
		{
			if (objectPrefabs[CentralVariables.DIFFICULTY_MODE].pooledHurdlesObjects[i].Count > 0)
			break;			
			
			i = (i + 1) % objectPrefabs[CentralVariables.DIFFICULTY_MODE].hurdlePrefabs.Length;				
		}
		pooledObject = objectPrefabs[CentralVariables.DIFFICULTY_MODE].pooledHurdlesObjects [i][0];
		objectPrefabs[CentralVariables.DIFFICULTY_MODE].pooledHurdlesObjects[i].RemoveAt (0);
		pooledObject.transform.parent = null;
		pooledObject.transform.position = position;
		pooledObject.SetActive (true);
			return pooledObject;

		//If we have gotten here either there was no object of the specified type or non were left in the pool with onlyPooled set to true

	}



	/// <summary>
	/// Pools the object specified.  Will not be pooled if there is no prefab of that type.
	/// </summary>
	/// <param name='obj'>
	/// Object to be pooled.
	/// </param>
	/// 
	/// 
	public void PoolHurdleObject ( GameObject obj )
	{
		for (int j = 0; j < 3; j++) {

			for (int i = 0; i < objectPrefabs[j].hurdlePrefabs.Length; i++) {
				if (objectPrefabs [j].hurdlePrefabs [i].name == obj.name) {
					obj.SetActive (false);
					obj.transform.parent = containerObject.transform;
				//	Debug.Log ("Added");
					objectPrefabs [j].pooledHurdlesObjects [i].Add (obj);
					return;
				}
			}
		}
	}
	#endregion



	#region vehiclePooling

	public GameObject GetVehicleObjectForId ( int i , bool onlyPooled , Vector3 position)
	{

		//GameObject prefab = objectPrefabs[CentralVariables.DIFFICULTY_MODE].VehiclePrefabs[i];


		GameObject pooledObject = null;

		while(true)
		{
			if (objectPrefabs[CentralVariables.DIFFICULTY_MODE].pooledVehiclesObjects [i].Count > 0)
				break;			
			i = (i + 1) % objectPrefabs[CentralVariables.DIFFICULTY_MODE].pooledVehiclesObjects.Length;				
		}
		pooledObject = objectPrefabs[CentralVariables.DIFFICULTY_MODE].pooledVehiclesObjects [i][0];
		objectPrefabs[CentralVariables.DIFFICULTY_MODE].pooledVehiclesObjects[i].RemoveAt (0);
		pooledObject.transform.parent = null;
		pooledObject.transform.position = position;
		pooledObject.SetActive (true);
		return pooledObject;

		//If we have gotten here either there was no object of the specified type or non were left in the pool with onlyPooled set to true

	}



	/// <summary>
	/// Pools the object specified.  Will not be pooled if there is no prefab of that type.
	/// </summary>
	/// <param name='obj'>
	/// Object to be pooled.
	/// </param>
	/// 
	public void PoolVehicleObject ( GameObject obj )
	{
		for (int j = 0; j < 3; j++) {

			for (int i = 0; i < objectPrefabs [j].VehiclePrefabs.Length; i++) {
				if (objectPrefabs [j].VehiclePrefabs [i].name == obj.name) {
					obj.SetActive (false);
					obj.transform.parent = containerObject.transform;

					objectPrefabs [j].pooledVehiclesObjects [i].Add (obj);
					return;
				}
			}
		}
	}

	#endregion

}
