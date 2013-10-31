using UnityEngine;
using System.Collections;

public class EnergyBonusOnDestroy : MonoBehaviour 
{
	
	public SelectTowerOnClicked SelectTowerOnClicked;
	
//	private TowerSelector towerSelector;
	
	void Start()
	{
		if(TowerSelector.Instance.gameHasStarted)
		{
			
		}
		//towerSelector = GameObject.Find ("UI Camera").GetComponent("TowerSelector") as GameObject;
	}
	
 	void OnDestroy()
	{
		HudDisplay.Instance.energy += SelectTowerOnClicked.GetCostOfTower();
	}
}
