// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden

using UnityEngine;
using System.Collections;

// Place the script in the Camera-Control group in the component menu
[AddComponentMenu("Camera-Control/Smooth Follow CSharp")]

public class SmoothFollowCSharp : MonoBehaviour
{
	/*
     This camera smoothes out rotation around the y-axis and height.
     Horizontal Distance to the target is always fixed.
     
     There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.
     
     For every of those smoothed values we calculate the wanted value and the current value.
     Then we smooth it using the Lerp function.
     Then we apply the smoothed values to the transform's position.
     */
	
	// The target we are following
	private Transform target;
	// The distance in the x-z plane to the target
	public float distance = 10f;
	private float initialDistance;
	// the height we want the camera to be above the target
	public float height = 10f;
	private float initialHeight;
	// Follow on x axis as well
	public bool isHorizontalFollow = false;
	// How much we 
	public float heightDamping = 0.0f;
	public float rotationDamping = 0.0f;
	public float leftRightDamping=2.0f;


	public float dampTime = 0.15f;


	float velocityX=0.0f;

	bool CameraAlignment;



	private Vector3 velocity = Vector3.zero;

	float cameraXPosition;
	float previousPosition;
	bool triggerCamera;
	public static int COUNT = 0;
	GameObject playerBody;
	void Start()
	{
		this.findTarget();
		playerBody= GameObject.FindGameObjectWithTag("PlayerBody");
		initialHeight = 0;
		initialDistance = 0;
		cameraXPosition = target.transform.position.x;
		previousPosition = target.transform.position.x;
		triggerCamera = false;
	}

	void OnEnable()
	{
		
	}



	private void findTarget()
	{
		
		if(!target)
		{
			Transform emptyBody = GameObject.FindGameObjectWithTag("SmoothFollowTarget").transform;

			this.target = emptyBody;
		}

	}

	void  FixedUpdate ()
	{
		if (CentralVariables.isDead)
			transform.LookAt (playerBody.transform);
	
		
		float angle= Mathf.MoveTowardsAngle(transform.eulerAngles.x, 9.4f, 4f*Time.deltaTime);
		transform.eulerAngles = new Vector3(angle,0, 0); 

		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;
		
		// Damp the rotation around the y-axis

		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		
		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		
		// Convert the angle into a rotation
	 


		Quaternion currentRotation = Quaternion.Euler (10, currentRotationAngle, 0);



		Vector3 startX=transform.position;
		Vector3 destination = target.position; 


		 


		float newPosition = Mathf.SmoothDamp(startX.x, destination.x, ref velocityX , dampTime);
		transform.position = new Vector3(newPosition,destination.y, destination.z);


		transform.position -= currentRotation * Vector3.forward * distance;
		transform.position -= currentRotation * Vector3.up * height;

	}



	#region Camera Shake

	float magnitude=0.05f;
	float duration=0.2f;
	float elapsed = 0.0f;

	public void ShakeCamera()
	{
		elapsed = 0.0f;
		StartCoroutine (Shake ());
	}

	IEnumerator Shake() {		

		while(elapsed < duration) {

			elapsed += Time.deltaTime;      
			float percentComplete = elapsed / duration; 

			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
			x *= magnitude;
			y *= magnitude;
			Vector3 originalCamPos = transform.position;
			originalCamPos.x += x;
			originalCamPos.y += y;
			transform.position = originalCamPos;


			yield return null;

		}
	}

	#endregion
}