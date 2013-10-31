using UnityEngine;
using System.Collections;

public class RestoreSpeed : MonoBehaviour {
	
	public float originalSpeed;
	public float time = 1.0f;
	// Use this for initialization
	void Start () 
	{
		Invoke("RestorSpeedFunction", time);
	}
	
	void RestorSpeedFunction()
	{
		
		PathTroughObject scriptInstance = gameObject.transform.parent.GetComponent<PathTroughObject>();
		scriptInstance.speed = originalSpeed;
		Destroy(gameObject);
	}
}
