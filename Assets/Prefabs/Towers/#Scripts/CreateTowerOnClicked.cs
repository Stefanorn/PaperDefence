using UnityEngine;
using System.Collections;

public class CreateTowerOnClicked : MonoBehaviour 
{

	
	void Clicked(Vector3 position)
	{
		if(HudDisplay.Instance.energy >= TowerSelector.Instance.GetSelectedTowerCost())
		{
			GameObject tower = TowerSelector.Instance.GetSelectedToewr();
			Instantiate (tower, position + Vector3.up*0.5f, tower.transform.rotation);
			HudDisplay.Instance.energy -= TowerSelector.Instance.GetSelectedTowerCost();
		}
	}
}
