using UnityEngine;
using System.Collections;

public class TowerSelectorInBegining : MonoBehaviour 
{
	public GameObject[] towerIcons;
	
	public float xPos = -5.0f;
	public float xPosEnd = 5.0f;
	public float yPos = 2.0f;
	public float zPos = 108.0f;
	public float spaceBetweenTurrets = 2.0f;
	

	// Use this for initialization
	void Start () 
	{
		float xPosRestart = xPos;
		foreach(GameObject tower in towerIcons)
		{
			if( xPos >= xPosEnd )
			{
				yPos += spaceBetweenTurrets;
				xPos = xPosRestart;
			}
			Instantiate(tower, new Vector3(xPos,yPos,zPos), Quaternion.identity);
			xPos += spaceBetweenTurrets;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
