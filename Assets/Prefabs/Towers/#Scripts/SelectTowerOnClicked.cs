using UnityEngine;
using System.Collections;

public class SelectTowerOnClicked : MonoBehaviour 
{
	public int prizeOfTurret = 50;
	public GameObject tower;
	
	private bool towerPicked = false;
		
	void Clicked()
	{
		if(towerPicked)
		{
			TowerSelector.Instance.SendMessage("SetSelectedTower", gameObject);
		}
		else
		{
			TowerSelector.Instance.SendMessage("PickedTower", gameObject);
			TowerSelector.Instance.SendMessage("SendPrizeOfTower", prizeOfTurret);
			TowerSelector.Instance.SendMessage("ResiveTower", tower);
			towerPicked = true;
		}
	}
	public int GetCostOfTower()
	{
		return prizeOfTurret;
	}
}
