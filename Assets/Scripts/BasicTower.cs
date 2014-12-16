using UnityEngine;
using System.Collections;

public class BasicTower : MonoBehaviour 
{
	public GameObject bullet;
	public float bulletSpeed = 1.0f;
	public float fireRate = 1.0f;
	public float fireRadius = 5.0f;
	public float lobAmountFyrirMortarTower = 11.0f;
	public Transform turretBarrel;
	public Transform bulletSpawner;
	public bool mortarTower = false;

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
		if(mortarTower && target != null)
		{

			GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.LookRotation(target.transform.position - transform.position) ) as GameObject;
			Vector3 VericalForce = new Vector3(0,lobAmountFyrirMortarTower,0);
			Vector3 horizontalDirection = (target.transform.position - transform.position).normalized;
			float speed = lobAmountFyrirMortarTower/-Physics.gravity.y;
			newBullet.rigidbody.AddForce(VericalForce + (horizontalDirection*speed),ForceMode.VelocityChange);
		}
		else
		{
			if(target != null)
			{
				Debug.Log("target ekki null");
				//turretBarrel.rotation = Quaternion.RotateTowards(turretBarrel.rotation,Quaternion.LookRotation(target.transform.position - turretBarrel.position),100);
				GameObject newBullet = Instantiate(bullet, bulletSpawner.position, Quaternion.LookRotation(target.transform.position - transform.position)) as GameObject;
				newBullet.rigidbody.AddForce((target.transform.position - transform.position).normalized*bulletSpeed,ForceMode.VelocityChange);
			}
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
			turretBarrel.rotation = Quaternion.RotateTowards(turretBarrel.rotation,Quaternion.LookRotation(target.transform.position - turretBarrel.position),500);
		}
		
		}
	public float RangeForHud()
	{
		return fireRate;
	}
}

//Quaternion.RotateTowards(cannonParent.rotation, Quaternion.LookRotation(player.transform.position - cannonParent.position),lazerRotationSpeed*Time.deltaTime);