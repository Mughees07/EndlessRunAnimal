using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDMenuController : MonoBehaviour {

	public Text TextPlayerDistance;
	public Text TextCoinsCoint;
	GameObject Player;
	public Text CoinsMultiplierGeneral;
	//public int PlayerDistance;
	public Text CoinsMultiplier;
	public GameObject CoinsBarFilled;



	public GameObject[] BoosterBars;
	

	public GameObject jump;
	public GameObject slide;
	public GameObject left;
	public GameObject right;


	// Use this for initialization
	void Start () 
	{
		//Player = GameObject.FindGameObjectWithTag ("Player").gameObject;
		jump.SetActive(false);
		slide.SetActive(false);
		right.SetActive(false);
		left.SetActive(false);
		InvokeRepeating("CoinsFill", 0.01f, 0.01f);
		CoinsBarFilled.GetComponent<Image> ().fillAmount = 0.02f;
	}

	int a = 0;
	float b=0;
	// Update is called once per frame
	void Update () 
	{
		
		if (Player != null) {
			if (!CentralVariables.isDead) {
//			
				TextPlayerDistance.text = "" + CentralVariables.PlayerCurrentDistance;

				TextCoinsCoint.text =  "" +CentralVariables.PlayerCurrentCoins; 

				//CoinsMultiplierGeneral.text= "" +CentralVariables.CoinsMultiplier+"X"; 

				if(CentralVariables.DoubleCoins)
					CoinsMultiplier.text = "" + (CentralVariables.CoinsMultiplier-2) + "X";
				else
					CoinsMultiplier.text = "" + CentralVariables.CoinsMultiplier + "X";
				
					CoinsMultiplierGeneral.text= "" +CentralVariables.CoinsMultiplier+"X"; 
			}
		} else {
			Player = GameObject.FindGameObjectWithTag ("Player").gameObject;
		}


	}

	public void CoinsFill()
	{
		
		if (CentralVariables.IsRunning)
			CoinsBarFilled.GetComponent<Image> ().fillAmount += 0.0001f;

		if (CoinsBarFilled.GetComponent<Image> ().fillAmount == 1) {
			CentralVariables.CoinsMultiplier++;
			CoinsBarFilled.GetComponent<Image> ().fillAmount = 0.02f;
		}


	}



	public void OnPause_Event()
	{
		GameManager.Instance.ChangeSoundState (GameManager.SoundState.CLICKSOUND);
		//Camera.main.GetComponent<AudioListener> ().enabled = false;
		//SoundManager.Instance.mute ();
		MainMenuManager.Instance.GamePauseEvent ();
		Invoke ("PauseScaler",0f);

	}
	void PauseScaler(){
		Time.timeScale = 0f;
	}

	public void Tilt()
	{
		GameObject player;
		player=GameObject.FindGameObjectWithTag("Player");


	}



	public IEnumerator MagnetboosterBar()
			{
		BoosterBars [1].SetActive (true);
		Image bar = BoosterBars [1].transform.GetChild(1).gameObject.GetComponent<Image> ();
		bar.fillAmount = 1;

		while (CentralVariables.Magnet) {
			bar.fillAmount -= (0.1f/CentralVariables.MagnetTime );	
			yield return  new WaitForSeconds(0.1f);
		}

		BoosterBars [1].SetActive (false);
		}



	public IEnumerator ShieldboosterBar()
	{
		BoosterBars [2].SetActive (true);
		Image bar = BoosterBars [2].transform.GetChild(1).gameObject.GetComponent<Image> ();
		bar.fillAmount = 1;

		while (CentralVariables.Stealth) {
			bar.fillAmount -= (0.1f/CentralVariables.StealthTime);	
			yield return  new WaitForSeconds(0.1f);
		}
		BoosterBars [2].SetActive (false);
	}
	public IEnumerator SpeedboosterBar()
	{
		BoosterBars [0].SetActive (true);
		Image bar = BoosterBars [0].transform.GetChild(1).gameObject.GetComponent<Image> ();
		bar.fillAmount = 1;

		while (CentralVariables.SpeedBooster) {
			bar.fillAmount -= (0.1f/CentralVariables.SpeedBoosterTime);
			yield return  new WaitForSeconds(0.1f);
		}
		BoosterBars [0].SetActive (false);
	}

	public IEnumerator DoubleCoinsboosterBar()
	{
		BoosterBars [3].SetActive (true);
		Image bar = BoosterBars [3].transform.GetChild(1).gameObject.GetComponent<Image> ();		
		bar.fillAmount = 1;

		while (CentralVariables.DoubleCoins) {
			bar.fillAmount -= (0.1f/CentralVariables.DoubleCoinsTime);	
			yield return  new WaitForSeconds(0.1f);
		}
		BoosterBars [3].SetActive (false);
	}

			
			}


