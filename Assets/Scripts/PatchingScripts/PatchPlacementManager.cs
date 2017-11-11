using UnityEngine;
using System.Collections;

public class PatchPlacementManager : MonoBehaviour {

	// Patch 
	public GameObject currentPatch;
	public GameObject lastPatch;
	public int currentPatchNo;

	//Hurdle
	public GameObject hurdles;
	public HurdleManager hurdleManager;
	public BoosterManager boosterManager;






	void Start () {
		
		addNextPatch ();
	}
	
	// Update is called once per frame


	public void addNextPatch()
	{
		int PatchNo = Random.Range (1, 4);
		Vector3 initPoint = Vector3.zero;

		if (currentPatch) {
			GameObject g = currentPatch.transform.FindChild ("PatchInitiator").gameObject;
			initPoint = g.transform.FindChild ("PatchRefrence").position;
			lastPatch = currentPatch;
		}

		if (CentralVariables.GameStart) {
			PatchNo = 1;
			CentralVariables.GameStart = false;	
		}
	
			switch (PatchNo) {

			case 1:
				currentPatch	= PatchPool.instance.GetObjectForType ("patch_01", true, initPoint);
				break;
			case 2:
				currentPatch = PatchPool.instance.GetObjectForType ("patch_02", true, initPoint);
				break;
			case 3:
				currentPatch= PatchPool.instance.GetObjectForType ("patch_03", true, initPoint);
				break;

			}





			
			currentPatch.transform.SetParent (transform);
			hurdles = currentPatch.transform.FindChild ("Hurdles").gameObject;

		if (CentralVariables.isTutorialLoaded)
			StartCoroutine (Wait ());
		else
			dontWaitLoadTutorial ();
	

	
	}


	public void  RecycleOldPatch()
	{	
		if (lastPatch) {
			hurdles = lastPatch.transform.FindChild ("Hurdles").gameObject;
			hurdleManager = hurdles.GetComponent<HurdleManager> ();
			boosterManager=hurdles.GetComponent<BoosterManager>();
			hurdleManager.RemoveHurdles ();
			boosterManager.RemoveBoosters();
			PatchPool.instance.PoolObject (lastPatch);
		}

	}

	IEnumerator Wait( )
	{
		float waitTime = 2.0f;

		
		yield return new WaitForSeconds (waitTime);
		hurdleManager = hurdles.GetComponent<HurdleManager> ();
		boosterManager = hurdles.GetComponent<BoosterManager> ();
		hurdleManager.AddHurdles();
		yield return new WaitForSeconds (waitTime);
		boosterManager.AddBooster();
		if (CentralVariables.GameStart) {
			currentPatch.transform.FindChild ("Coins").gameObject.SetActive (false);

			hurdles.SetActive (false);
		} else if (!CentralVariables.isTutorialLoaded) {
			//CentralVariables.isTutorialSeen = true;
			hurdleManager.tutorialhurdles.SetActive (true);
			currentPatch.transform.FindChild ("Coins").gameObject.SetActive (false);
			hurdles.SetActive (false);
			CentralVariables.isTutorialLoaded = true;
			//hurdleManager.tutorialhurdles.SetActive (false);

		} else {
			hurdles.SetActive (true);
			hurdleManager.tutorialhurdles.SetActive (false);
		}


	}

	void dontWaitLoadTutorial()
	{
		hurdleManager = hurdles.GetComponent<HurdleManager> ();
		boosterManager = hurdles.GetComponent<BoosterManager> ();
		hurdleManager.AddHurdles();
		boosterManager.AddBooster();
		if (CentralVariables.GameStart) {
			currentPatch.transform.FindChild ("Coins").gameObject.SetActive (false);
			CentralVariables.GameStart = false;	
			hurdles.SetActive (false);
		} else if (!CentralVariables.isTutorialLoaded) {
			//CentralVariables.isTutorialSeen = true;
			hurdleManager.tutorialhurdles.SetActive (true);
			currentPatch.transform.FindChild ("Coins").gameObject.SetActive (false);
			hurdles.SetActive (false);
			CentralVariables.isTutorialLoaded = true;
			//hurdleManager.tutorialhurdles.SetActive (false);

		} else {
			hurdles.SetActive (true);
			hurdleManager.tutorialhurdles.SetActive (false);
		}
	}


}
