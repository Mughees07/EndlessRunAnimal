using UnityEngine;
using System.Collections;

public class AnimationBottom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		//iTween.MoveFrom(  this.gameObject, iTween.Hash(  "y",  -3f,  "time", 0.7, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
		iTween.MoveFrom(  this.gameObject, iTween.Hash(  "y", transform.position.y +3f,  "time", 0.7, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
