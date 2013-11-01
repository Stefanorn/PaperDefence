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
	
	
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameHasStarted)
		{
			towerIcons[selectedTower].transform.Rotate(Vector3.up, towerIconRotateRate * Time.deltaTime);
			
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
		}
		
		
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
			foreach(GameObject menuItem in GameObject.FindGameObjectsWithTag("GameMenuItems"))
			{
				menuItem.gameObject.SetActive(false);
			//	Destroy(menuItem);
			}
			gameHasStarted = true;
			float xPos = -6.0f;
			float yPos = 3.5f;
			foreach(GameObject tower in towerIcons)
			{
				tower.transform.position = new Vector3(xPos, yPos, 108.0f);
				yPos -= 2;
			}
			hudItems.gameObject.SetActive(true);
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
