using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour 
{
	public float health = 10.0f;
	public Transform HealthBarDisplay;
	public GameObject[] drops;
	public float dropChanse = 50.0f;
	public int mobScore = 50;
	
	private float maxHealth;
	
	// Use this for initialization
	void Start ()
	{

		maxHealth = health;

	}
	
	// Update is called once per frame
	void ApplyDamage(float damage)
	{
		health -= damage;
		HealthBarDisplay.localScale = new Vector3( 1 * (health / maxHealth), HealthBarDisplay.localScale.y, HealthBarDisplay.localScale.y);	
		
		if(health <= 0)
		{
			if(Random.Range(0.0f,100.0f) >= dropChanse)
			{
				int d = Random.Range(0,drops.Length); 
				Instantiate (drops[d],transform.position, Quaternion.identity);
			}
			HudDisplay.Instance.score += mobScore;		
			Destroy(gameObject);
		}
		
	}
	
//	void OnCollisionEnter(Collision col)
//	{
//		if(col.collider.tag == "Bullets")
//		{	
//	
//			health--; //laga
//			HealthBarDisplay.localScale = new Vector3( 1 * (health / maxHealth), HealthBarDisplay.localScale.y, HealthBarDisplay.localScale.y);	
//			Destroy(col.gameObject);
//		}
//		if(health <= 0)
//		{
//			if(Random.Range(0.0f,100.0f) >= dropChanse)
//			{
//				int d = Random.Range(0,drops.Length); 
//				Debug.Log(d);
//				Instantiate (drops[d],transform.position, Quaternion.identity);
//			}
//			HudDisplay.Instance.score += mobScore;
//			Destroy(col.gameObject);			
//			Destroy(gameObject);
//		}
//	}
}