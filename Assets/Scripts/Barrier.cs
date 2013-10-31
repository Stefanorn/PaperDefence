using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		if(col.collider.tag == "Bullets")
		{
		Destroy(col.gameObject);			
		}
	}
}

