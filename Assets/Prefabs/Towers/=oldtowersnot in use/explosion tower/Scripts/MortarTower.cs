using UnityEngine;
using System.Collections;

public class MortarTower : MonoBehaviour 
{
	public GameObject bullet;
	//public float bulletSpeed = 1.0f;
	public float lobAmount = 50.0f;
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
		
			Vector3 VericalForce = new Vector3(0,lobAmount,0);
			Vector3 horizontalDirection = (target.transform.position - transform.position).normalized;
			float speed = lobAmount/-Physics.gravity.y;
			
			
			newBullet.rigidbody.AddForce(VericalForce + (horizontalDirection*speed),ForceMode.VelocityChange);
		}

	}
}
