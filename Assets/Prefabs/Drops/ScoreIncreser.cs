using UnityEngine;
using System.Collections;

public class ScoreIncreser : MonoBehaviour 
{
	public int scoreAmount;
	void Clicked()
	{
		HudDisplay.Instance.score += scoreAmount;
		Destroy(gameObject);
	}
}
