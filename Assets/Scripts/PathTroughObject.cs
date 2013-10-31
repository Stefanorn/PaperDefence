using UnityEngine;
using System.Collections;

public class PathTroughObject : MonoBehaviour 
{
	public GameObject[] pathPoints;
	public float speed = 1.0f;
	public float goalSize = 0.1f;
	

	
	private int currentPathIndex = 0;
	private Vector3 movementDirection;
	
	void Start()
	{
		movementDirection = (pathPoints[currentPathIndex].transform.position - transform.position).normalized;

	}
	void Update () 
	{	
		transform.position += movementDirection*speed*Time.deltaTime;
		

	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name == pathPoints[currentPathIndex].name)
			{
				//transform.position = pathPoints[currentPathIndex].transform.position;
				currentPathIndex++;
			if(currentPathIndex >= pathPoints.Length)
			{
				HudDisplay.Instance.lives--;
				Destroy(gameObject);
			}
			else
			{
				movementDirection = (pathPoints[currentPathIndex].transform.position - transform.position).normalized;	
			}
			}
	}
	void SetPathPoint(GameObject[] inputPathPoints)
	{
		pathPoints = inputPathPoints;
	}
}
