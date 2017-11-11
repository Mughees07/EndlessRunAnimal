using UnityEngine;
using System.Collections;

public class DiagonalMoving : MonoBehaviour {

	/// Use this for initialization
	public float moveSpeed=0.5f;

	private float newPosX;
	private float newPosZ;

	public float StartX;
	//offset of start towards right
	public float offsetRight;
	//offset of where it will end towards left
	public float offsetLeft;
	//for moving the hurdle in plane Giving Value 1 and 1 will move in the upper dialogonal
	//for moving the hurdle in plane Giving Value -1 and 1 will move in the lower dialogonal
	public int DirectionX;

	public int DirectionZ;
	void Start () {
		newPosX=Time.deltaTime * moveSpeed*DirectionX;
		newPosZ=Time.deltaTime * moveSpeed*DirectionZ;
		StartX = transform.position.x;

	}
	
	// Update is called once per frame
	void Update () {
		

		//LogManager.Log (transform.position.x.ToString(),LogManager.LogType.GENERAL);
		if (StartX + offsetRight < transform.position.x&&DirectionX==1) {
			newPosX=-Time.deltaTime * moveSpeed;
			newPosZ=-Time.deltaTime * moveSpeed;
		
		}

		if (StartX - offsetLeft > transform.position.x&&DirectionX==1) {
			newPosX=Time.deltaTime * moveSpeed;
			newPosZ=Time.deltaTime * moveSpeed;


		}
		if (StartX + offsetRight < transform.position.x&&DirectionX==-1) {
			newPosX=-Time.deltaTime * moveSpeed;
			newPosZ=Time.deltaTime * moveSpeed;
			
		}
		if (StartX - offsetLeft > transform.position.x && DirectionX == -1) {

			newPosX=Time.deltaTime * moveSpeed;
			newPosZ=-Time.deltaTime * moveSpeed;


		}


		transform.Translate (newPosX,0,newPosZ,Space.World);
		
		
	}
}
