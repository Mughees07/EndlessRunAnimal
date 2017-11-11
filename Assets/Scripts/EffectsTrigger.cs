using UnityEngine;
using System.Collections;

public class EffectsTrigger : MonoBehaviour {

	public GameObject butterFlyEffect;
	public GameObject rainEffect;
	bool effect;

	public void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.transform.root.gameObject.tag == "Player") {

			Debug.Log ("Effect");
				
			if (effect) {
				
				if (CentralVariables.isDay)
					butterFlyEffect.SetActive (true);
				else
					rainEffect.SetActive (true);

				effect = false;
				
			}
		}

	}

	 void Update()
	{
		if(CentralVariables.TimeSeconds%30==0)
				effect=true;

	}
}
