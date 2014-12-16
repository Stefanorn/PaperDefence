using UnityEngine;
using System.Collections;

public class TowerSelector : MonoBehaviour 
{
	public GameObject[] towerIcons;
	public GameObject[] towers;
	public int[] towerCostr;
	
	
	
	public float towerIconRotateRate = 1.0f;
	
	public float towerTime = 0.0f;
	
	public int selectedTower = 0;
	public bool gameHasStarted = false;
	public GameObject hudItems;	
	private int towerPickerIndex = 0;
	
	
	// Update is called once per frame
	void Update () 
	{
		if(gameHasStarted)
		{
			for( int i = 0; i < towerIcons.Length; i++)
			{
				if(i == selectedTower)
				{
					towerIcons[i].SendMessage("ButtonGreen");
				}
				if(i != selectedTower)
				{
					towerIcons[i].SendMessage("ButtonRed");
				}
			}
			
			if(Input.GetKeyDown("1"))
			{
				selectedTower = 0;
			}
			if(Input.GetKeyDown("2"))
			{
				selectedTower = 1;
			}
			if(Input.GetKeyDown("3"))
			{
				selectedTower = 2;
			}
			if(Input.GetKeyDown("4"))
			{
				selectedTower = 3;
			}
		}
		
	}
	public void ResetGame()
	{
		for ( int i = 0; i < towers.Length; i++){
  			 towerIcons[i] = null;
			 towers[i] = null;
			 towerCostr[i] = 0;
			
		}
		towerPickerIndex = 0;
		HudDisplay.Instance.lives = 10;
		
		
	}
	public GameObject GetSelectedToewr()
	{
		return towers[selectedTower];
	}
	
	public int GetSelectedTowerCost()
	{
		return towerCostr[selectedTower];
	}
	
	void SetSelectedTower(GameObject inputTower)
	{
		int index = 0;
		foreach(GameObject towerIncon in towerIcons)
		{
			if(inputTower == towerIncon)
			{
				selectedTower = index;
			}
			index++;
		}
	}
	void PickedTower(GameObject pickedTower)
	{
		towerIcons[towerPickerIndex] = pickedTower;
		towerIcons[towerPickerIndex].tag = "Untagged";
		towerPickerIndex++;	

		if(towerPickerIndex == towerIcons.Length)
		{
			StartCoroutine("ScrollUp");
			gameHasStarted = true;
			float xPos = -5.4f;
			float yPos = 3.0f;
			foreach(GameObject tower in towerIcons)
			{
				//towerIcons[selectedTower].SendMessage("ButtonGreen");
				tower.transform.position = new Vector3(xPos, yPos, 108.0f);
				yPos -= 2;
			}
			hudItems.gameObject.SetActive(true);
		}
	}
	
	IEnumerator ScrollUp()
	{
		float scrollTime = 1.0f;
		float scrollSpeed = 26.5f;

		float t = 0.0f;
		
		while(t < scrollTime)
		{	
		
			foreach(GameObject menuItem in GameObject.FindGameObjectsWithTag("GameMenuItems"))
			{
				menuItem.transform.localPosition += new Vector3(0,-1,0) *scrollSpeed*Time.deltaTime * (1-(t/scrollTime));

			}
			t += Time.deltaTime;
			yield return null;
		}
		foreach(GameObject menuItem in GameObject.FindGameObjectsWithTag("GameMenuItems"))
			{
				menuItem.gameObject.SetActive(false);		
			}

	}
	void SendPrizeOfTower(int prize)
	{
		towerCostr[towerPickerIndex -1] = prize;
	}
	void ResiveTower(GameObject Tower)
	{
		towers[towerPickerIndex - 1 ] = Tower;
	}

	private static TowerSelector instance = null;
	public static TowerSelector Instance
	{
		get { return instance; }
	}
	
	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
		{
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
		gameObject.name = "$TowerSelector";
	}
}
