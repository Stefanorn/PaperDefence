using UnityEngine;
using System.Collections;

public class LowEnergyScript : MonoBehaviour {
	public float speed = 1.0f;
	public float DeathTime = 2.0f;
	// Use this for initialization
	void Start () 
	{
		Invoke("DieTime", DeathTime);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.localPosition += Vector3.up*speed*Time.deltaTime;
	}
	void DieTime()
	{
		Destroy(gameObject);
	}
}
