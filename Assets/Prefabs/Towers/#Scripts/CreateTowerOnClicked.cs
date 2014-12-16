using UnityEngine;
using System.Collections;

public class CreateTowerOnClicked : MonoBehaviour 
{
	public GameObject poffEffect;
	public GameObject lowEnergyEffect;
	
	private bool canSpawnLowEnergyEffect = true;
	private float time = 0.0f;
	private float antyspamTime = 0.35f;
	
	void Update()
	{
		time += Time.deltaTime;
	}
	
	void Clicked(Vector3 position)
	{
		if(HudDisplay.Instance.energy >= TowerSelector.Instance.GetSelectedTowerCost())
		{
			GameObject tower = TowerSelector.Instance.GetSelectedToewr();
			Instantiate (tower, position, tower.transform.rotation);
			Instantiate(poffEffect, position, tower.transform.rotation);
			HudDisplay.Instance.energy -= TowerSelector.Instance.GetSelectedTowerCost();
		}
		else
		{	
			if(time > antyspamTime)
			{
				Instantiate(lowEnergyEffect, position, Quaternion.identity);
				time = 0.0f;
			}
		}
	}
}
