using UnityEngine;
using System.Collections;

public class MortarAi : MonoBehaviour 
{
	public GameObject explosion;

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col)
	{
		Instantiate(explosion,col.contacts[0].point, Quaternion.identity);

		Destroy(gameObject);
		
	}
}
