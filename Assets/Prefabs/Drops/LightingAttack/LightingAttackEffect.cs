using UnityEngine;
using System.Collections;

public class LightingAttackEffect : MonoBehaviour 
{
	public GameObject bullet;
	public float bulletSpeed = 1.0f;
	public float fireRate = 1.0f;
	public float fireRadius = 5.0f;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("SpawnBullet",fireRate, fireRate);
	}
	
	void SpawnBullet()
	{
		GameObject target = null;
		
		foreach(Collider col in Physics.OverlapSphere(transform.position, fireRadius))
		{
			if(col.tag == "Enemy")
			{
				target = col.gameObject;
				break;
			}
		}
		if(target != null)
		{
			GameObject newBullet = Instantiate(bullet, transform.position, bullet.transform.rotation) as GameObject;
			newBullet.rigidbody.AddForce((target.transform.position - transform.position).normalized*bulletSpeed,ForceMode.VelocityChange);
		}

	}
//	void Update()
//	{
//		GameObject target = null;
//		
//		foreach(Collider col in Physics.OverlapSphere(transform.position, fireRadius))
//		{
//			if(col.tag == "Enemy")
//			{
//				target = col.gameObject;
//				break;
//			}
//		}
//	if(target != null)
//		{
//			turretBarrel.rotation = Quaternion.RotateTowards(turretBarrel.rotation,Quaternion.LookRotation(target.transform.position - turretBarrel.position),500);
//		}
//		
//		}
//	public float RangeForHud()
//	{
//		return fireRate;
//	}
}