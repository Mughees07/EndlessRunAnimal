using UnityEngine;
using System.Collections;
using System;

public class SoundManager : SingeltonBase<SoundManager>{

	public AudioSource GameSounds;
	public AudioSource BackgroundSounds;

	public AudioClip CoinCollectionSound;
	public AudioClip StumbleSound;
	public AudioClip JumpSound;
	public AudioClip SlideSound;
	public AudioClip barkSound;
	public AudioClip GlassBreak;


	public AudioClip LevelSuccess;
	public AudioClip LevelFail;
	public AudioClip Revivesound;
	public AudioClip CountDown;
	public AudioClip ClickSound;


	public AudioClip MagnetSound;
	public AudioClip StealthSound;
	public AudioClip DoubleCoinsSound;
	public AudioClip SpeedSound;

	public AudioClip BgSoundMenu;
	public AudioClip BgSoundGamePlay;

	public AudioClip timer;
	public AudioClip Go;
	public AudioClip hit;
	
	public const int MUSIC_TYPE_GAME_PLAY = 1;
	public const int MUSIC_TYPE_MENU = 2;




	public enum Fade {In, Out};

	public enum VoiceState {
		VOICE_AMAZING,
		VOICE_ASTOUNDING,
		VOICE_AWESOME,
		VOICE_COOL,
		VOICE_GOOD,
		VOICE_GREAT,
		VOICE_NICE,
		VOICE_STRIKING
	};

	public delegate void AudioCallback();

	void Start () {

		DontDestroyOnLoad (this);
		BackgroundSounds=this.GetComponent<AudioSource>();
		playMainMenuSound ();

	}
	
	// Update is called once per frame
	void Update () {

	
		

	}

	/// <summary>
	/// Music Fader.
	/// </summary>
	/// <param name="fadeTime">Fade time.</param>
	/// <param name="pFade">P fade.</param>
	/// 

	public void playMainMenuSound()
	{
		if(BackgroundSounds)
		BackgroundSounds.clip = BgSoundMenu;

		if (CentralVariables.isPlayMusic) {
			
			BackgroundSounds.Play ();		
		}
	}

	public void playGamePlaySound()
	{
		if(BackgroundSounds)
		BackgroundSounds.clip = BgSoundGamePlay;
		if (CentralVariables.isPlayMusic) {
			
			BackgroundSounds.Play();
		}
	}

	public void bgMusicMute(bool status)
	{
		//GameSounds.mute=true;
		if (!status) {
			BackgroundSounds.Pause ();
			CentralVariables.isPlayMusic = false;
		} else {
			
			BackgroundSounds.UnPause ();

			if (!BackgroundSounds.isPlaying)
				BackgroundSounds.Play ();
			CentralVariables.isPlayMusic = true;
		}

	}
	public void mute()
	{


		BackgroundSounds.Pause ();
	}
	public void unmute()
	{
		if(BackgroundSounds)
		BackgroundSounds.UnPause();

	}

	public void musicFader (float fadeTime, Fade pFade ) {
		StartCoroutine(FadeAudio(fadeTime, pFade));
	}

	/// <summary>
	/// Fades the audio.
	/// </summary>
	/// <returns>The audio.</returns>
	/// <param name="timer">Timer.</param>
	/// <param name="fadeType">Fade type.</param>
	private IEnumerator FadeAudio (float timer, Fade fadeType) {
		float start = fadeType == Fade.In? 0.0F : 1.0F;
		float end = fadeType == Fade.In? 1.0f : 0.0f;
		float vol = 0.0f;
		float step = 1.0f/timer;

		while (vol <= 1.0f) {
			vol += step * Time.deltaTime;
			this.GetComponent<AudioSource>().volume = Mathf.Lerp(start, end, vol);
			yield return new WaitForSeconds(step * Time.deltaTime);
		}
	}
	
	/// <summary>
	/// Plaies the background music.
	/// </summary>
	/// <param name="pPlay">If set to <c>true</c> p play.</param>


	/// <summary>
	/// Plaies the background music.
	/// </summary>
	/// <param name="pPlay">If set to <c>true</c> p play.</param>
	/// <param name="isPause">If set to <c>true</c> is pause.</param>


	/// <summary>
	/// Plaies the sound.
	/// </summary>
	/// 
	/// 
	public void PlaySound()
	{
		if (CentralVariables.isPlaySound ) {

			if(GameSounds != null) {
				switch (GameManager.Instance.GetSoundState ()) {
			
				case GameManager.SoundState.CLICKSOUND:
					GameSounds.PlayOneShot(ClickSound);
					break;
				case GameManager.SoundState.COINCOLLECTSOUND:
					if (!CentralVariables.isDead) {
						GameSounds.PlayOneShot (CoinCollectionSound);
						GameSounds.volume = 0.5f;
					}
					break;
				case GameManager.SoundState.CountDown:
					GameSounds.PlayOneShot(CountDown);
					break;
			
				case GameManager.SoundState.STUMBLE_SOUND:
					GameSounds.PlayOneShot(StumbleSound);
					break;
				case GameManager.SoundState.JUMP_SOUND:
					GameSounds.PlayOneShot(JumpSound);
					break;
				case GameManager.SoundState.SLIDESOUND:
					GameSounds.PlayOneShot(SlideSound);
					break;
				case GameManager.SoundState.LEVEL_SUCCESS:
					GameSounds.PlayOneShot(LevelSuccess);
					break;
				case GameManager.SoundState.LEVEL_FAIL:
					GameSounds.PlayOneShot(LevelFail);
					break;
				case GameManager.SoundState.REVIVESOUND:
					GameSounds.PlayOneShot(Revivesound);
					break;

				case GameManager.SoundState.MAGNETSOUND:
					GameSounds.PlayOneShot(MagnetSound);
					break;
				case GameManager.SoundState.STEALTHSOUND:
					GameSounds.PlayOneShot(StealthSound);
					break;
				case GameManager.SoundState.DOUBLECOINSOUND:
					GameSounds.PlayOneShot(DoubleCoinsSound);
					break;
				case GameManager.SoundState.SPEEDSOUND:
					GameSounds.PlayOneShot(SpeedSound);
					break;
				case GameManager.SoundState.BARK:
					GameSounds.PlayOneShot(barkSound);
					break;
				case GameManager.SoundState.GO:
					GameSounds.PlayOneShot(Go);
					break;
				case GameManager.SoundState.TIMER:
					GameSounds.PlayOneShot(timer);
					break;
				case GameManager.SoundState.HIT:
					GameSounds.PlayOneShot(hit);
					break;
				case GameManager.SoundState.GLASSBREAK:
					Debug.Log ("Glass break");
					GameSounds.PlayOneShot(GlassBreak);
					break;
			
				

				}
			}

		}
 	 }

	/// <summary>
	/// Random voices.
	/// </summary>
	/// <returns>The voice.</returns>
	public VoiceState randomVoice() {
		
		Array values = Enum.GetValues (typeof(VoiceState));
		System.Random random = new System.Random ();
		return (VoiceState)values.GetValue (random.Next (values.Length));

		}


	public void PlaySoundWithCallback(float pExtraDelay, AudioCallback callback){
		if (CentralVariables.isPlayMusic) {
			
			if (GameSounds != null) {
//				switch (GameManager.Instance.GetSoundState ()) {
//				case GameManager.SoundState.SNAKENLADDER_BUS_START:
//					PlaySoundWithCallback(snakeNLadderBusStart, pExtraDelay, callback);
//					break;
//				}
			}
		}
	}

	public void PlaySoundWithCallback(AudioClip clip, float pExtraDelay, AudioCallback callback){
		GetComponent<AudioSource>().PlayOneShot(clip);
//		if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAIN_MENU){
			StartCoroutine(DelayedCallback(clip.length+pExtraDelay, callback));
//		}
	}

	/// <summary>
	/// Delayed callback.
	/// </summary>
	/// <returns>The callback.</returns>
	/// <param name="time">Time.</param>
	/// <param name="callback">Callback.</param>
	/// 
	private IEnumerator DelayedCallback(float time, AudioCallback callback)	{
		yield return new WaitForSeconds(time);
		callback();
	}



}
