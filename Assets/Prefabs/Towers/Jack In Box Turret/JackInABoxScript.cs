using UnityEngine;
using System.Collections;

public class JackInABoxScript : MonoBehaviour {

	public GameObject bullet;
	public float bulletSpeed = 1.0f;
	public float fireRate = 1.0f;
	public float fireRadius = 5.0f;
	public Transform turretBarrel;
	public Transform bulletSpawner;
	
	public GameObject missilDisplay;
	

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("SpawnBullet",0.2f, fireRate);
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
			newBullet.rigidbody.AddForce((target.transform.position - transform.position).normalized*bulletSpeed,ForceMode.Force);
			missilDisplay.gameObject.SetActive(false);
		}
		Invoke("ReactiveMissle",2.0f);
	}
	void ReactiveMissle()
	{
		missilDisplay.gameObject.SetActive(true);
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
			turretBarrel.rotation = Quaternion.RotateTowards(turretBarrel.rotation,Quaternion.LookRotation(target.transform.position - turretBarrel.position),500);
		}
		
		}
	public float RangeForHud()
	{
		return fireRate;
	}
}

//Quaternion.RotateTowards(cannonParent.rotation, Quaternion.LookRotation(player.transform.position - cannonParent.position),lazerRotationSpeed*Time.deltaTime);