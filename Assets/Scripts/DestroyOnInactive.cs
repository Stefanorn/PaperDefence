using UnityEngine;
using System.Collections;

public class DestroyOnInactive : MonoBehaviour {

	// Use this for initialization
	void Start () {
	Invoke("DestroyNow", gameObject.particleSystem.duration);
	}
	void DestroyNow()
	{
		Destroy(gameObject);
	}
}
