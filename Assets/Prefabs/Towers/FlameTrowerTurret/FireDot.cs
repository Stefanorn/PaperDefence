using UnityEngine;
using System.Collections;

public class FireDot : MonoBehaviour 
{
	
	public GameObject flameEffect;
	
	
	void OnCollisionEnter(Collision col)
	{
		if(col.collider.tag == "Enemy")
		{
			if(col.collider.GetComponentInChildren<FlameEffect>() == null)
			{
				GameObject flameEffectRefrence = Instantiate(flameEffect, col.collider.transform.position, Quaternion.identity) as GameObject;	
				flameEffectRefrence.transform.parent = col.collider.transform;

			}
		
		}
	}
}
