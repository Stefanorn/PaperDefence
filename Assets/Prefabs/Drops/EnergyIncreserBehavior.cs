using UnityEngine;
using System.Collections;

public class EnergyIncreserBehavior : MonoBehaviour {
	
	public int energyAmmount = 50;

	void Clicked()
	{
		HudDisplay.Instance.maxEnergy += energyAmmount;
		HudDisplay.Instance.energy += energyAmmount;
		Destroy(gameObject);
	}
}
