using UnityEngine;
using System.Collections;

public class glassCollision : MonoBehaviour {

	// Use this for initialization
	bool isCollided;
	GameObject []glass;
	public GameObject smokeEffect;
	void Start () {
		for (int i = 0; i < transform.childCount; i++) {
			glass[i] = transform.GetChild (i).gameObject;
		}
	}
	// Update is called once per frame
	public void OnCollisionEnter(Collision other)
	{
		if (!isCollided) {
			GameManager.Instance.ChangeSoundState (GameManager.SoundState.GLASSBREAK);
			smokeEffect.SetActive (true);
			ActivateGlass ();
			isCollided = true;

			Time.timeScale = 0.5f;
		}
	}
	public void ActivateGlass()
	{
		foreach (GameObject g in glass) {
			
			g.AddComponent<Rigidbody> ();	
			g.GetComponent<Rigidbody> ().AddForce (Vector3.forward);	
		}
		

	}
}
