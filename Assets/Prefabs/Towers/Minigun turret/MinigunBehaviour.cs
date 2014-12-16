using UnityEngine;
using System.Collections;

public class MinigunBehaviour : MonoBehaviour {

	public GameObject bullet;
	public GameObject bulletBurstExplosion;
	public Transform bulletBurstSpace;
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
				//turretBarrel.rotation = Quaternion.RotateTowards(turretBarrel.rotation,Quaternion.LookRotation(target.transform.position - turretBarrel.position),100);
				GameObject newBullet = Instantiate(bullet, bulletSpawner.position, Quaternion.LookRotation(target.transform.position - transform.position)) as GameObject;
				newBullet.rigidbody.AddForce((target.transform.position - transform.position).normalized*bulletSpeed,ForceMode.VelocityChange);
				Instantiate(bulletBurstExplosion, bulletBurstSpace.transform.position, Quaternion.identity);
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
			
			turretBarrel.rotation = Quaternion.RotateTowards(turretBarrel.rotation,Quaternion.LookRotation(lookDir),500);
		}
		
		}
	public float RangeForHud()
	{
		return fireRate;
	}

}