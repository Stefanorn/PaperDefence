using UnityEngine;
using System.Collections;

public class DeatAfterTime : MonoBehaviour 
{
	public float Duration = 10.0f;
	public Transform healthBarDisplay;
	
	private float currentDurationTime = 0.0f;
	// Use this for initialization
	void Start () 
	{
		currentDurationTime = Duration;
		Invoke("DieTime",Duration);
	}
	
	void Update()
	{

		if(currentDurationTime == 0)
		{
			currentDurationTime = 0.0001f;
		}
		healthBarDisplay.localScale = new Vector3( 1 * (currentDurationTime / Duration),  1 * (currentDurationTime / Duration), healthBarDisplay.localScale.z);
		
		
		
		currentDurationTime -= Time.deltaTime;
		
		
	}
	
	void DieTime()
	{
		Destroy(gameObject);
	}
}