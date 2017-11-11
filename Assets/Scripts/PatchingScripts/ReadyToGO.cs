using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ReadyToGO : MonoBehaviour {

	public GameObject []go;
	GameObject player;
	GameObject puppies;

	public GameObject Hud;

	public static int count = 3;


	public void Awake()
	{

		DontDestroyOnLoad (this.gameObject);
		MainMenuManager.Instance.Loading.SetActive (false);

		puppies = GameObject.FindGameObjectWithTag ("Puppies");

		for (int i = 0; i < puppies.transform.childCount; i++) {
			if (i != CentralVariables.currentSelectedDog)
				puppies.transform.GetChild (i).gameObject.SetActive (false);
			else
				puppies.transform.GetChild (i).gameObject.SetActive (true);

		}

	}


	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");

		foreach(GameObject g in go)
		{
			g.SetActive(false);
		}
		Go();

	}

	public void Go(){

		CentralVariables.IsRunning = false;
		player.GetComponentInChildren<Animator> ().enabled = false;
		player.GetComponent<PlayerMovement> ().enabled = false;
//		Camera.main.GetComponent<SmoothFollowCSharp>().enabled = true;
		float y = 4f;
	
		GameObject.FindGameObjectWithTag ("PlayerBody").transform.eulerAngles= new Vector3(0f,4f,0f);
		StartCoroutine (Counter());

	}

	IEnumerator Counter()
	{
		Hud.SetActive (false);
		for (int i=0; i<go.Length; i++) {
			go [i].SetActive (true);
			iTween.ScaleTo (go [i], new Vector3 (3, 3, 3), 1f);
			if(i<3)
				GameManager.Instance.ChangeSoundState (GameManager.SoundState.TIMER);
			else
				GameManager.Instance.ChangeSoundState (GameManager.SoundState.GO);
			yield return new WaitForSeconds(1f);
			disableAll();
		}

		player.GetComponentInChildren<Animator> ().enabled = true;
		player.GetComponent<PlayerMovement> ().enabled = true;
		CentralVariables.IsRunning = true;
		Hud.SetActive (true);
		//Camera.main.GetComponent<SmoothFollowCSharp>().enabled = true;
		yield return null;


	}

	public void disableAll()
	{

		foreach (GameObject g in go) {		
			g.SetActive(false);
		
		}

	}







}
