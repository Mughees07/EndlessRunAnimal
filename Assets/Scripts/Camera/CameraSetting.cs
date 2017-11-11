using UnityEngine;
using System.Collections;
//using UnityStandardAssets.Utility;
using UnityEngine.UI;

public class CameraSetting : MonoBehaviour {

	// Use this for initialization
	public bool SettingControls;
	public Text distanceText;
	public Text heightText;

	SmoothFollowCSharp smoothFollow;

	void Start()
	{
		smoothFollow=Camera.main.GetComponent<SmoothFollowCSharp>();
	}

	void Update () {
		if(!SettingControls)
		{
			gameObject.SetActive(false);
		}
		else
		{			
			heightText.text = "Height = "+smoothFollow.height;
			distanceText.text = "Distance = "+smoothFollow.distance;
		}
	}

	public void Distance(float factor)
	{
		smoothFollow.distance+=factor;
		//distanceText.text = "Distance = "+smoothFollow.distance;
	}

	public void Height(float factor)
	{
		smoothFollow.height+=factor;
		//heightText.text = "Height = "+smoothFollow.height;

	}
	

}
