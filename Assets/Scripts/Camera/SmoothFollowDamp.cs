using UnityEngine;
using System.Collections;

public class SmoothFollowDamp : MonoBehaviour {

	// Use this for initialization
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;

	float velocityX=0.0f;

	public Transform target;
	Camera camera;
	public float distance=10.0f;
	public float hieght=10.0f;
	// Update is called once per frame

	void Start()
	{
		camera = Camera.main;
	}

	void LateUpdate()
	{
		if (target)
		{
			

			Vector3 delta = target.position - new Vector3(target.position.x,target.position.y+hieght,target.position.z-distance); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = target.position-delta; 
		


			//transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
			Vector3 startX=transform.position;



			float newPosition = Mathf.SmoothDamp(startX.x, destination.x, ref velocityX , dampTime);
			transform.position = new Vector3 (destination.x, startX.y, destination.z);


			transform.LookAt(target);

		}

	}
}
