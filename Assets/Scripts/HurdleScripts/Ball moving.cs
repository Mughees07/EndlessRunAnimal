using UnityEngine;
using System.Collections;

public class Ballmoving: MonoBehaviour {
	
	// Use this for initialization
	private float moveSpeed=10f;
	public float offset;
	private float rotatingSpeed=3;
	private Vector3 movement;
	public float StartX;
	//offset of start towards right
	public float offsetRight;
	//offset of where it will end towards left
	public float offsetLeft;
	void Start () {
		movement = Vector3.right;
		StartX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (movement*Time.deltaTime*moveSpeed,Space.World);
		transform.Rotate(rotatingSpeed, 0, rotatingSpeed, Space.World);
		if (StartX+offsetRight < transform.position.x)
			movement = Vector3.left;
		if (StartX-offsetLeft >transform.position.x)
			movement = Vector3.right;
		
		
		
	}
	
}
