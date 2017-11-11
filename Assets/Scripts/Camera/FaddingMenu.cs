using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FaddingMenu : SingeltonBase<FaddingMenu> {

	// Use this for initialization
	public GameObject FadingImage;
	void Start () {
		//PlayerPrefs.DeleteAll();
		FadingImage.GetComponent<Image>().enabled=true;
		FadingImage.GetComponent<Image>().CrossFadeAlpha(0,0,true);
		FadingImage.SetActive(false);
		//iTween.FadeTo (FadingImage, 0f, 1f);

		//FadingImage.gameObjects
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void FadeIn()
	{
		FadingImage.SetActive(true);
		FadingImage.GetComponent<Image>().CrossFadeAlpha(0,0,true);
		FadingImage.GetComponent<Image>().CrossFadeAlpha(1,0.5f,true);
		Invoke("FadeOut",0.5f);
	}

	public void FadeOut()
	{
		FadingImage.GetComponent<Image>().CrossFadeAlpha(0,1f,true);
		Invoke ("Disable", 1f);
	}

	void Disable()
	{
		FadingImage.SetActive(false);
	}

}
