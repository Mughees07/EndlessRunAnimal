using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class SelectionMenuController : MonoBehaviour {

	// Use this for initialization

	//public GameObject DogsCamera;
	GameObject [] dogPrefabs= new GameObject[5];
	GameObject dogs;

	public GameObject totalCoins;
	public GameObject popUp;

	public GameObject[] PetMenus;

	GameObject price;
	GameObject selectButton;
	GameObject tryButton;
	GameObject unlockButton;
	GameObject selectedButton;


	int unlockIndex;


	int currentDog=0;
	public GameObject left,right;
	Vector3 startPos;


	float movementfactor=10f;

	GameObject camera;
	bool rightPressed,leftPressed;

	void Start () {
		//DontDestroyOnLoad (this.gameObject);
		left.SetActive(false);
		//dogs = dogPrefabs [0].transform.parent.gameObject;
		camera = Camera.main.gameObject;
		rightPressed = false;
		leftPressed = false;
		dogs = GameObject.FindGameObjectWithTag ("SelectionDogs");
		startPos = dogs.transform.position;
		//for (int i = 0; i < CentralVariables.petSelection.Length; i++) {
			SetMenu (0);		
		//}

	}

	void OnEnable()
	{
		
		dogs = GameObject.FindGameObjectWithTag ("SelectionDogs");
		dogs.transform.position = Vector3.zero;
		SetMenu (0);
		for (int i = 0; i < dogs.transform.childCount; i++) {
			dogPrefabs [i] = dogs.transform.GetChild (i).gameObject;
			dogPrefabs [i].SetActive (true);
		}
		totalCoins.GetComponent<Text>().text=""+CentralVariables.PlayerTotalCoins;
		currentDog = 0;
		if (!startPos.Equals (Vector3.zero))			
		dogs.transform.position = startPos;
		
		rightPressed = false;
		leftPressed = false;
		left.SetActive(false);
		right.SetActive (true);

	}

	void OnDisable()
	{
		
		dogs = GameObject.FindGameObjectWithTag ("SelectionDogs");
		
		if (dogs) {
			for (int i = 0; i < dogs.transform.childCount; i++) {
				dogPrefabs [i] = dogs.transform.GetChild (i).gameObject;
				dogPrefabs [i].SetActive (false);
			}
		}
	}
	// Update is called once per frame
	public void UnlockPet(int index)
	{
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		if (CentralVariables.PlayerTotalCoins >= CentralVariables.petSelection [index].Price) {
			unlockIndex = index;
			//MainMenuManager.Instance.ShowPopUp ("Are you Sure?");p
			popUp.transform.parent.gameObject.SetActive (true);
			popUp.GetComponent<Animator> ().SetBool ("play", true);
			//popUp.SetActive(true);
			dogs.SetActive (false);

		} else
			MainMenuManager.Instance.ShowPopUp ("Not Enough Coins !!");

	}

	public void UnlockPetYes()
	{
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		GAManager.Instance.LogDesignEvent ("PetSelection:UnlockedPet" + unlockIndex);
		int startVal = CentralVariables.PlayerTotalCoins;
		CentralVariables.PlayerTotalCoins -= CentralVariables.petSelection [unlockIndex].Price;
		GameManager.Instance.ChangeSoundState(GameManager.SoundState.DOUBLECOINSOUND);
		MainMenuManager.Instance.textCounterEffect (totalCoins.GetComponent<Text> (), startVal, CentralVariables.PlayerTotalCoins,CentralVariables.petSelection [unlockIndex].Price , false);
		//totalCoins.GetComponent<Text> ().text = "" + CentralVariables.PlayerTotalCoins;
		CentralVariables.petSelection [unlockIndex].UnlockStatus = true;
		CentralVariables.petSelection [unlockIndex].TryStatus = true;
		SetMenu (unlockIndex);		

		CentralVariables.SaveToFile ();
		float upgradePrice = CentralVariables.petSelection [unlockIndex].Price;
		GAManager.Instance.LogResourceEvent (true, "coins", upgradePrice, "UnlockedPet", "" + unlockIndex);

		popUp.transform.parent.gameObject.SetActive (false);
		popUp.GetComponent<Animator> ().SetBool ("play", false);
		dogs.SetActive (true);
	}

	public void UnlockPetNo()
	{
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		//popUp.SetActive (false);
		dogs.SetActive (true);
		popUp.transform.parent.gameObject.SetActive (false);
		popUp.GetComponent<Animator> ().SetBool ("play", false);
	}

	public void TryFree(int index)
	{
		
		//StartCoroutine (MainMenuManager.Instance.showLoading ());
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		GAManager.Instance.LogDesignEvent("PetSelection:TryFree"+index);
		CentralVariables.DogTry = true;
		CentralVariables.DogTryStatus = true;
		CentralVariables.videoAdRewardType = CentralVariables.VideoAdReward.PLAYER_UNLOCK;
		CentralVariables.currentIndexMenu = index;
		UnityAdsHelper.ShowAd (CentralVariables.RewardedZoneId);

		//UnityAdsHelper.
			


		//SetMenu (index);
	}

	public void SelectPet(int index)
	{
		//MainMenuManager.Instance.startLoadingGameplay ();
		//StartCoroutine (MainMenuManager.Instance.showLoading ());
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		GAManager.Instance.LogDesignEvent("PetSelection:SelectedPet"+index);
		CentralVariables.currentSelectedDog = index;
		for (int k = 0; k < CentralVariables.petSelection.Length; k++) {
			if (k == index)
				CentralVariables.petSelection [k].Selected = true;				
			else
				CentralVariables.petSelection [k].Selected = false;
		}
		SetMenu (index);
		CentralVariables.SaveToFile ();
		MainMenuManager.Instance.DogSelectionPanel.SetActive (false);
		MainMenuManager.Instance.MainMenuPanel.SetActive (true);
		MainMenuManager.Instance.GamePlayEvent ();

	}


	public void SetMenu(int i)
	{
		
		for (int k = 0; k < PetMenus.Length; k++) {
			if (k == i)
				PetMenus [k].SetActive (true);
			else
				PetMenus [k].SetActive (false);
		}


		unlockButton = PetMenus [i].transform.FindChild ("Unlock").gameObject;
		tryButton = PetMenus [i].transform.FindChild ("TryFree").gameObject;
		selectButton = PetMenus [i].transform.FindChild ("Select").gameObject;
		selectedButton = PetMenus [i].transform.FindChild ("Selected").gameObject;





		if (CentralVariables.petSelection [i].UnlockStatus) {
			unlockButton.SetActive (false);
			tryButton.SetActive (false);

			if (!CentralVariables.petSelection [i].Selected) {
				selectButton.SetActive (true);
				selectedButton.SetActive(false);
			} else {
				selectedButton.SetActive(true);
				selectButton.SetActive (false);
			}
		}
		else {


			selectButton.SetActive (false);
			selectedButton.SetActive (false);

			if (CentralVariables.petSelection [i].TryStatus) {
				iTween.ValueTo(this.gameObject, iTween.Hash("from", (unlockButton.GetComponent<RectTransform>().anchoredPosition.y+100),"to", unlockButton.GetComponent<RectTransform>().anchoredPosition.y,"easetype", "EaseOutBounce","time", 0.5f,"onupdate", "Move"));
				unlockButton.SetActive (true);
				tryButton.SetActive (false);		
			} else {
				iTween.ValueTo(this.gameObject, iTween.Hash("from", (tryButton.GetComponent<RectTransform>().anchoredPosition.y+100),"to", tryButton.GetComponent<RectTransform>().anchoredPosition.y,"easetype", "EaseOutBounce","time", 0.5f,"onupdate", "Move"));
				tryButton.SetActive (true);		
				unlockButton.SetActive (false);		
			}

		}


	}

	public void Movetry(float y)
	{

		Vector2 pos1= tryButton.GetComponent<RectTransform> ().anchoredPosition;
		Vector2 pos2= unlockButton.GetComponent<RectTransform> ().anchoredPosition;
		pos1.y = y;
		pos2.y = y;
		unlockButton.GetComponent<RectTransform> ().anchoredPosition = pos1;
		tryButton.GetComponent<RectTransform> ().anchoredPosition = pos2;
	}



	#region LeftRightMovement

	public void OnLeft()
	{
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		currentDog--;
		leftPressed = true;
		left.SetActive(false);
		right.SetActive(false);
		SetMenu (currentDog);

		//Vector3 newpos=dogs.GetComponent<RectTransform>().anchoredPosition;
		Vector3 newpos=dogs.transform.position;
		newpos.x += movementfactor;
		//StartCoroutine(MoveFromTo(dogs.GetComponent<RectTransform>().anchoredPosition,newpos,0.5f));
		StartCoroutine(MoveFromTo(dogs.transform.position,newpos,0.5f));
		//showDog ();
	}

	public void OnRight()
	{
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		currentDog++;
		rightPressed = true;
		left.SetActive(false);
		right.SetActive(false);
		SetMenu (currentDog);
		Vector3 newpos=dogs.transform.position;;
		newpos.x -= movementfactor;
		StartCoroutine(MoveFromTo(dogs.transform.position,newpos,0.5f));

		//showDog ();
	}

	public void showDog()
	{
		for (int i=0; i< dogPrefabs.Length; i++) {
			if(i!= currentDog)
				dogPrefabs[i].SetActive(false);
			else
				dogPrefabs[i].SetActive(true);

		}

	}

	public bool moving = false;

	IEnumerator MoveFromTo(Vector3 pointA, Vector3 pointB, float time){
		if (!moving){ // do nothing if already moving`
			moving = true; // signals "I'm moving, don't bother me!"
			float t = 0f;
			while (t < 1f){
				t += Time.deltaTime / time; // sweeps from 0 to 1 in time seconds
				//	dogs.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(pointA, pointB, t); // set position proportional to t
				dogs.transform.position = Vector3.Lerp(pointA, pointB, t); 
				yield return 0; // leave the routine and return here in the next frame
			}
			moving = false; // finished moving
			LeftRightButtons();
		}
	}

	public void LeftRightButtons()
	{
		if (currentDog == (dogPrefabs.Length-1) && rightPressed)
		{
			right.SetActive(false);
			left.SetActive(true);
			rightPressed=false;
		}
		else if  (currentDog == 0 && leftPressed)
		{
			left.SetActive(false);
			right.SetActive(true);
			leftPressed=false;
		}
		else {
			left.SetActive(true);
			right.SetActive(true);
		}
	}

	#endregion

	
}
