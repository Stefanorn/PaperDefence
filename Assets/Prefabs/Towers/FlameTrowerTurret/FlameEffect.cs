using UnityEngine;
using System.Collections;

public class FlameEffect : MonoBehaviour {
	
	public float repeteRate = 1.0f;
	public float damage = 1.0f;
	
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("FireDot", 0 , repeteRate);
	}
	
	// Update is called once per frame
	void FireDot () 
	{
		transform.parent.SendMessage("ApplyDamage", damage,SendMessageOptions.DontRequireReceiver);
	}
}
