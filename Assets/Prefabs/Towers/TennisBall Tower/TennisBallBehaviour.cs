using UnityEngine;
using System.Collections;

public class TennisBallBehaviour : MonoBehaviour 
{

	public GameObject bullet;
	public float bulletSpeed = 1.0f;
	public float fireRate = 1.0f;
	public float fireRadius = 5.0f;
	public float bulletCount = 10.0f;
	public Transform healthBarDisplay;
	private float maxBullets;
	public Transform turretBarrel;
	public Transform bulletSpawner;

	


	// Use this for initialization
	void Start () 
	{
		maxBullets = bulletCount;
		Invoke("SpawnBullet",fireRate);
	}
	
	void SpawnBullet()
	{
		if(bulletCount == 0)
		{
			Destroy(gameObject);
		}
		
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
				GameObject newBullet = Instantiate(bullet, bulletSpawner.position, Quaternion.LookRotation(target.transform.position - transform.position)) as GameObject;
				newBullet.rigidbody.AddForce((target.transform.position - transform.position).normalized*bulletSpeed,ForceMode.VelocityChange);
				bulletCount--;
					fireRate = fireRate * 1.1f;
			}
		healthBarDisplay.localScale = new Vector3( 1 * (bulletCount / maxBullets), 1 * (bulletCount / maxBullets), healthBarDisplay.localScale.z);

		Invoke("SpawnBullet",fireRate);
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