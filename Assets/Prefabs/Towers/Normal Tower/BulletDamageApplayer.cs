using UnityEngine;
using System.Collections;

public class BulletDamageApplayer : MonoBehaviour 
{
	public float damage = 1.0f;
	void OnCollisionEnter(Collision col)
	{
	if(col.collider.tag == "Enemy")
		{
			col.collider.SendMessage("ApplyDamage", damage,SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
}
