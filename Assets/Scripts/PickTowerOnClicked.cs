using UnityEngine;
using System.Collections;

public class PickTowerOnClicked : MonoBehaviour 
{
	
	public GameObject towerSelector;
	
	void Clicked()
	{
		towerSelector.SendMessage("PickTower", gameObject);
	}
	
}
