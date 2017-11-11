using UnityEngine;
using System.Collections;

public class ShakeEffect : MonoBehaviour {
	public float speed = 40f; //how fast it shakes
	public float amount = 0.03f;
	public Vector3 movement;
	// Use this for initialization
	void Start () {
		movement = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.Sin (Time.deltaTime), transform.position.y, transform.position.z);
	}
}
