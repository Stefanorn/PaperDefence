using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	public GameObject[] pathPoints;
	public GameObject GraphicalPathObject;
	public GameObject[] spawnList;
	public float spawnTime;
	public int numberOfEnemys;
	public bool increseDifficultyByEachEnemy = true;
	
	private int spawnIndex = 0;
	private float increseSawnrate = 0.95f;
	
	// Use this for initialization
	void Start () 
	{
		CreateGraphicalPathObject();	
		Invoke("Spawn", spawnTime);
	}
	
	void Update () 
	{
	}
	
	void Spawn()
	{
		if(TowerSelector.Instance.gameHasStarted)
		{	
			//instantiate next enemy in spawnlist
			GameObject refrence = Instantiate(spawnList[spawnIndex], transform.position, Quaternion.identity) as GameObject;
			spawnIndex = Random.Range(0, spawnList.Length);
			
			if(increseDifficultyByEachEnemy)
			{
				increseSawnrate *= 1.001f;
				if(increseSawnrate >= 1.0f)
				{
					increseSawnrate = 1.0f;
				}
				spawnTime *= increseSawnrate;
	
			}
			
			
			HudDisplay.Instance.enemyConuter ++;
			
			
			if(!increseDifficultyByEachEnemy && numberOfEnemys == HudDisplay.Instance.enemyConuter)
			{
				CancelInvoke(); 
			}
		
	//		if(spawnIndex >= spawnList.Length)
	//		{
	//			CancelInvoke(); 
	//		}
			//Set enemy path info
			refrence.SendMessage("SetPathPoint", pathPoints);
		}
		Invoke("Spawn", spawnTime);
	}
	
	void CreateGraphicalPathObject()
	{
		//finnur punkt a milli byrjunar reit og næsta punkts
		Vector3 pathObjectPosition = ((pathPoints[0].transform.position - transform.position)*0.5f)+ transform.position;
		Quaternion pathObjectOrientation =  Quaternion.LookRotation(pathPoints[0].transform.position - transform.position);
		GameObject pathObject = Instantiate(GraphicalPathObject, pathObjectPosition, pathObjectOrientation) as GameObject;
		
		Vector3 newScale = Vector3.one; //Lengir Quatinn þannig að hann nai fra byrjunarreit og næsta punkts
		newScale.z = (pathPoints[0].transform.position - transform.position).magnitude;
		pathObject.transform.localScale = newScale;
		
		Vector2 newTextureScale = Vector2.one;//Lengir Texturinn þannig að hann birti fleirri örvar
		newTextureScale.y = (pathPoints[0].transform.position - transform.position).magnitude;
		pathObject.renderer.material.mainTextureScale = newTextureScale;
		
		for(int i = 1; i < pathPoints.Length; i++)
		{
					//finnur punkt a milli byrjunar reit og næsta punkts
			pathObjectPosition = ((pathPoints[i].transform.position - pathPoints[i-1].transform.position)*0.5f)+ pathPoints[i-1].transform.position;
			pathObjectOrientation =  Quaternion.LookRotation(pathPoints[i].transform.position - pathPoints[i-1].transform.position);
			pathObject = Instantiate(GraphicalPathObject, pathObjectPosition, pathObjectOrientation) as GameObject;
			
			newScale = Vector3.one; //Lengir Quatinn þannig að hann nai fra byrjunarreit og næsta punkts
			newScale.z = (pathPoints[i].transform.position - pathPoints[i-1].transform.position).magnitude;
			pathObject.transform.localScale = newScale;
			
			newTextureScale = Vector2.one;//Lengir Texturinn þannig að hann birti fleirri örvar
			newTextureScale.y = (pathPoints[i].transform.position - pathPoints[i-1].transform.position).magnitude;
			pathObject.renderer.material.mainTextureScale = newTextureScale;
		}
	}
	
	void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position,pathPoints[0].transform.position);
		for(int i = 1; i < pathPoints.Length; i++)
		{
			Gizmos.DrawLine(pathPoints[i-1].transform.position,pathPoints[i].transform.position);
		}
	}
	
}