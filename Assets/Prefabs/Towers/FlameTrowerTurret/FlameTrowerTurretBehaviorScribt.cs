using UnityEngine;
using System.Collections;

public class FlameTrowerTurretBehaviorScribt : MonoBehaviour 
{

	public GameObject bullet;
	public float bulletSpeed = 1.0f;
	public float targetingSpeed = 1.0f;
	public float fireRate = 1.0f;
	public float fireRadius = 5.0f;

	public Transform turretBarrel;
	public Transform bulletSpawner;


	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("SpawnBullet",targetingSpeed, fireRate);
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
				
				Vector3 lookDir = target.transform.position - turretBarrel.position;
				lookDir.y = 0.0f;
				GameObject newBullet = Instantiate(bullet, bulletSpawner.position, Quaternion.LookRotation(lookDir)) as GameObject;
				newBullet.rigidbody.AddForce((target.transform.position - transform.position).normalized*bulletSpeed,ForceMode.VelocityChange);
	
			}
		

	}
	void Update()
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
			
			Vector3 lookDir = target.transform.position - turretBarrel.position;
			lookDir.y = 0.0f;
			Debug.Log(lookDir.magnitude);
			turretBarrel.rotation = Quaternion.LookRotation(lookDir);
		}
		
		}
	public float RangeForHud()
	{
		return fireRate;
	}

}