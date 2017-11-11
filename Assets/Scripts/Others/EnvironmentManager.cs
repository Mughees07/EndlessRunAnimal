using UnityEngine;
using System.Collections;

public class EnvironmentManager : MonoBehaviour {

	// Use this for initialization
	private float SkyboxBlendFactor; 
	int currentPhase;


	private float lightIntensity;  

	bool TransitionComplete;
	bool DayToNight;

	/// Initializes working variables and performs starting calculations.  
	void Start()  
	{  
		
		//currentPhase = 1;
	
		lightIntensity = 0.6f;
		DayToNight = true;
		TransitionComplete = true;
		SkyboxBlendFactor = 0.02f;
		RenderSettings.skybox.SetFloat ("_Blend", SkyboxBlendFactor);
	}  

	private void UpdateSkyboxBlendFactor(){  
//		if (currentPhase == 1)  
//		{  			
//			SkyboxBlendFactor = 0;
//		
//		}  
//		else if (currentPhase == 2)  
//		{  
//			SkyboxBlendFactor = 0.25f;  
//		}  
//		else if (currentPhase == 3)  
//		{  
//			
//			SkyboxBlendFactor = 0.5f;  
//		}  
//		else if (currentPhase == 4)  
//		{  
//			
//			SkyboxBlendFactor = 0.75f;  
//		}  
//		else if (currentPhase == 5)  
//		{  
//			SkyboxBlendFactor = 1.0f;  
//		}  
//		if (currentPhase == 5) {
//			DayToNight = false;
//		}
//		if (DayToNight) {
//			currentPhase++;
//			lightIntensity-=0.1f;
//		} else {
//		
//			currentPhase--;
//			lightIntensity += 0.1f;
//		}


	
		GetComponent<Light> ().intensity=lightIntensity;	
		RenderSettings.skybox.SetFloat("_Blend", SkyboxBlendFactor);  
	}  

	void Update()
	{
		if (!TransitionComplete) {
			if (DayToNight) {
				SkyboxBlendFactor = Mathf.Lerp (SkyboxBlendFactor, 1f, Time.deltaTime / 10);
				RenderSettings.skybox.SetFloat ("_Blend", SkyboxBlendFactor);  
				GetComponent<Light> ().intensity = Mathf.Lerp (lightIntensity, 0f, Time.deltaTime / 10);
				//UpdateSkyboxBlendFactor ();
				CentralVariables.isDay=false;
			} else {
				SkyboxBlendFactor = Mathf.Lerp (SkyboxBlendFactor, 0f, Time.deltaTime / 10);
				RenderSettings.skybox.SetFloat ("_Blend", SkyboxBlendFactor);  
				GetComponent<Light> ().intensity = Mathf.Lerp (lightIntensity, 0.6f, Time.deltaTime / 10);
				//UpdateSkyboxBlendFactor ();
				CentralVariables.isDay=true;
			}

			if (SkyboxBlendFactor >= 0.99f) {
				DayToNight = false;
				TransitionComplete = true;
			} else if (SkyboxBlendFactor <= 0.01) {
				DayToNight = true;
				TransitionComplete = true;
			}

		}



		if (CentralVariables.TimeSeconds % 150 == 0) 
			TransitionComplete = false;

	
}
}