using UnityEngine;
using System.Collections;

public class HudDisplay : MonoBehaviour {
	public int initialEnergy = 500;
	public int maxEnergy = 0;
	public GameObject energyDisplay;
	public GameObject NameDisplay;
	public GameObject enemyCounterDisplay;
	public GameObject timeDisplay;
	public GameObject damageDisplay;
	public GameObject fireRateDisplay;
	public GameObject speccial;
	public GameObject scoreDisplay;
	public GameObject costDisplay;
	//public TowerSelector towerSelector;
	
	public int enemyConuter;
	public float energy;
	public int lives = 10;
	
	public bool gameHasEndede = false;
	public int endScore;
	public int score;
	
	private int[] highScore = new int[11];

	// Use this for initialization
	void Start () 
	{

		energy = initialEnergy;
		maxEnergy = initialEnergy;
		ReadHighScore();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject tower =  TowerSelector.Instance.GetSelectedToewr();
				
		if(TowerSelector.Instance.gameHasStarted){ 
			enemyCounterDisplay.GetComponent<TextMesh>().text = "Enemys : " + enemyConuter.ToString(); 
			NameDisplay.GetComponent<TextMesh>().text = "name : " + tower.name;
			costDisplay.GetComponent<TextMesh>().text = "Energy : " + TowerSelector.Instance.towerCostr[TowerSelector.Instance.selectedTower ].ToString();
			energyDisplay.GetComponent<TextMesh>().text = "Energy : " +  energy.ToString() + " / " + maxEnergy.ToString();
			timeDisplay.GetComponent<TextMesh>().text = "Lives : " + lives.ToString();
			scoreDisplay.GetComponent<TextMesh>().text = "Score : " + score.ToString();
		}
		if(lives == 0)
		{
			gameHasEndede = true;
			endScore = enemyConuter;
			damageDisplay.GetComponent<TextMesh>().text = "endScore : " + endScore.ToString();
			lives--;
			SetHighScore();
			Application.LoadLevel("HighScore");
		}
		
		
	}
	
	void SetHighScore()
	{
		highScore[10] = score;
	
		
		int j = 0;
		int temp = 0;
		
		for(int index = 1; index < highScore.Length; index++)
		{
			j = index;
			temp = highScore[index];
			while((j > 0) && (highScore[j-1] > temp))
			{
				highScore[j] = highScore[j-1];
				j--;
			}
			highScore[j] = temp;
		}
		for(int i = 0; i < highScore.Length; i++)
		{
			PlayerPrefs.SetInt("highScoreNr" + (highScore.Length - i) , highScore[i]);
		}

	}
	void ReadHighScore()
	{
		for(int i = 0; i < (highScore.Length - 1); i++)
		{
			highScore[i] = PlayerPrefs.GetInt("highScoreNr" +(i+1) );
		}
	}
	private static HudDisplay instance = null;
	public static HudDisplay Instance
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
		gameObject.name = "$HudDisplay";
	}
}
