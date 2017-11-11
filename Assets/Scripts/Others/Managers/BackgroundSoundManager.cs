using UnityEngine;
using System.Collections;

public class BackgroundSoundManager :SingeltonBase<BackgroundSoundManager> {
	
	
	 public AudioSource backgrpundmusicSource;
	public AudioClip backgroundMusicClip;
	public AudioClip GameplayMusicClip;

	bool isMusicPlayed = false;
	// Use this for initialization
	
	void Start () {
		DontDestroyOnLoad(gameObject);
		backgrpundmusicSource = gameObject.GetComponent<AudioSource>();

	}
	// Update is called once per frame
	void Update () {
	
		//if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.GAMEPLAY && isMusicPlayed == true)
		{
			backgrpundmusicSource.GetComponent<AudioSource>().clip = GameplayMusicClip;
			backgrpundmusicSource.Play();
			isMusicPlayed = false;
		}
		//else if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU && isMusicPlayed == true)
		{
			backgrpundmusicSource.GetComponent<AudioSource>().clip = backgroundMusicClip;
			backgrpundmusicSource.Play();
			isMusicPlayed = false;
		}

	}

}
