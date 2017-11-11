

using UnityEngine;
using System.Collections;

//#if UNITY_EDITOR
[ExecuteInEditMode]
public class GameGizmos : MonoBehaviour {

	// Use this for initialization
	Transform[] pointsArray;
	public float radius;
	public bool drawPathOnChilds=false;
	public bool drawFilledSphereOnChilds=true;
	public bool drawEmptySphereOnSelf=false;
	Color color;
	int childCount;

	void Start () {
		//Debug.Log(transform.childCount);

		childCount=transform.childCount;
		GetPath();

		color=new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));
	}



	void OnDrawGizmos() {

		Gizmos.color = color;
		if(childCount<transform.childCount)
		{
			GetPath();
		}

		#region DrawFillSphereChilds
		if(drawFilledSphereOnChilds)
		{

			for(int i=0;i<pointsArray.Length;i++)
			{
				if(pointsArray[i])
					Gizmos.DrawSphere(pointsArray[i].position, radius);
			}
		}
		#endregion

		#region DrawPathChilds
		if(drawPathOnChilds)
		{			
			for(int i=1;i<pointsArray.Length;i++)
			{
				if(!pointsArray[i])
				{
					GetPath();
					childCount=transform.childCount;
					return;
				}
				Gizmos.DrawLine(pointsArray[i-1].position,pointsArray[i].position);
			}
		}
		#endregion

		#region DrawEmptySphereSelf
		if(drawEmptySphereOnSelf)
		{
			Gizmos.DrawWireSphere(transform.position,radius);
		}
		#endregion
	}
		


	void GetPath()
	{
		pointsArray = new Transform[transform.childCount];
		for(int i=0;i<transform.childCount;i++)
		{
			pointsArray[i]=transform.GetChild(i);
		}
	}
}
//#endif
