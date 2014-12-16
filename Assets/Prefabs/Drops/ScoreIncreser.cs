using UnityEngine;
using System.Collections;

public class ScoreIncreser : MonoBehaviour 
{
	public int scoreAmount = 50;
	void Clicked()
	{
		HudDisplay.Instance.score += scoreAmount;
		Destroy(gameObject);
	}
}
