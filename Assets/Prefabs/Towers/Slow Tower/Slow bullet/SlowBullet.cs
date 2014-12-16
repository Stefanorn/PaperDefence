using UnityEngine;
using System.Collections;

public class SlowBullet : MonoBehaviour 
{
	public float slowPercentage = 0.5f;
	public float slowSpeed = 1.0f;
	public float damage = 1.0f;
	public GameObject restoreSoeedObhect;
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col)
	{
		if(col.collider.tag == "Enemy")
		{
			col.collider.SendMessage("ApplyDamage", damage,SendMessageOptions.DontRequireReceiver);

			if(col.collider.GetComponentInChildren<RestoreSpeed>() == null)
			{
				PathTroughObject scriptInstance = col.collider.GetComponent<PathTroughObject>();
				
				
				GameObject restoreSpeedIntsnce = Instantiate(restoreSoeedObhect, col.collider.transform.position, Quaternion.identity) as GameObject;	
				restoreSpeedIntsnce.transform.parent = col.collider.transform;
				RestoreSpeed scriptInstance2 = restoreSpeedIntsnce.GetComponent<RestoreSpeed>();			
				scriptInstance2.time = slowSpeed;
				scriptInstance2.originalSpeed = scriptInstance.speed;
				
				scriptInstance.speed *= slowPercentage;
			}
			Destroy(gameObject);
		
		}

	}
}
