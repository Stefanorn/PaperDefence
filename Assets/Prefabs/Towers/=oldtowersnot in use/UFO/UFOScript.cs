using UnityEngine;
using System.Collections;

public class UFOScript : MonoBehaviour {

	public Transform laser;
	//public GameObject shootingEffect;
	public float laserSpeed = 1.0f;
	public float targetingSpeed = 1.0f;
	public float fireRate = 1.0f;
	public float fireRadius = 5.0f;
	public float laserDuration = 1.0f;
	public Transform turretBarrel;
	public float reloadTime = 2.0f;
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
				Invoke("FireLazer", reloadTime);
			}
	}
	void FireLazer()
	{
		StartCoroutine("LaserCoroutine");
	}
	IEnumerator LaserCoroutine()
	{
		
		float t = 0.0f;
		while(t < laserDuration)
			{
				if(laser != null)
				{
					Vector3 newScale = laser.localScale;
					newScale.y += laserSpeed*Time.deltaTime;
					laser.localScale = newScale;
				}
			t += Time.deltaTime;
			yield return null;
		}
		LaserCooldown();
	}
	void LaserCooldown()
	{

			if(laser != null)
			{
				Vector3 newScale = laser.localScale;
				newScale.y = 0;
				//laser.gameObject.SetActive(false);
				laser.localScale = newScale;
				//Instantiate(spawnLazer,laser.position,laser.rotation);
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
}