using UnityEngine;
using System.Collections;

public class SelectTowerOnClicked : MonoBehaviour 
{
	public int prizeOfTurret = 50;
	public GameObject tower;
	
	public Texture buttonPressedImage;
	
	private bool towerPicked = false;
	private Texture buttonNotPressed;
	
	void Start()
	{
		buttonNotPressed = renderer.material.mainTexture;
	}
	
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
			ButtonRed();
			towerPicked = true;
		}
	}
	public int GetCostOfTower()
	{
		return prizeOfTurret;
	}
	void ButtonRed()
	{
		renderer.material.mainTexture = buttonPressedImage;
	}
	void ButtonGreen()
	{
		renderer.material.mainTexture = buttonNotPressed;
	}
}
