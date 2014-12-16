using UnityEngine;
using System.Collections;

public class RocketLockTarget : MonoBehaviour 
{
	public float range = 5.0f;
	public float rotationSpeed = 20;
	public float bulletSpeed = 5.0f;

	void Update () 
	{		
		GameObject target = null;
		
	foreach(Collider col in Physics.OverlapSphere(transform.position, range))
		{
			if(col.tag == "Enemy")
			{
				target = col.gameObject;
				break;
			}
		}
	if(target != null)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(target.transform.position - transform.position),rotationSpeed * Time.deltaTime);
			transform.position += transform.forward*bulletSpeed*Time.deltaTime;
		//	gameObject.rigidbody.AddForce((transform.forward).normalized*bulletSpeed*Time.deltaTime,ForceMode.VelocityChange);
			
		}
	transform.position += transform.forward*bulletSpeed*Time.deltaTime;
	}
	void OnCollisionEnter(Collision col)
	{
		Debug.Log(col.collider);
		
	}
}
