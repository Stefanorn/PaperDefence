using UnityEngine;
using System.Collections;

public class LightingAttackBoost : MonoBehaviour 
{
	public float Radius = 10.0f;
	public GameObject BoostEffect;
	
	void Clicked()
	{
		
		
		Collider[] targets = Physics.OverlapSphere(transform.position, Radius);
		
		foreach(Collider target in targets)
		{
			if(target.tag == "Turret")
			{
				GameObject instance = Instantiate(BoostEffect,target.transform.position,Quaternion.identity) as GameObject;
				instance.transform.parent = target.transform;				
			}
		}
		Destroy(gameObject);
	}
}
