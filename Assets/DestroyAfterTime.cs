using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {
	
	public float time = 10.0f;
	
	// Use this for initialization
	void Start () {
		Invoke ("DestroyNow", time);
	}
	void DestroyNow()
	{
		Destroy(gameObject);
	}
	
}
