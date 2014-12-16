using UnityEngine;
using System.Collections;

public class RotaryGunBarrel : MonoBehaviour 
{
	public float rotationSpeed = 50.0f;
	public float rotationIncreser = 1.1f;
	public Vector3 axis = Vector3.forward;
	
	// Update is called once per frame
	void Update () 
	{
		rotationSpeed += rotationIncreser;
		transform.Rotate(axis, rotationSpeed * Time.deltaTime);
	}
}
