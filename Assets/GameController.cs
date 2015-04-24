using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameController : MonoBehaviour {
	public float interval;
	private float time;
	public static GameController gameController;
	private List<Character> enemies;
	private List<Character> players;
	public Level level;
	public Player p;
	public GameObject exit;


	// Persistent data is passed to this Game Controller after the previous scene ends. 
	// The previous GameController is then destroyed in Awake().

	void inherit(GameController c){
		//TODO: Any persistent stats are copied to here. 
	}

	void Awake() {
		if (gameController == null) {
			DontDestroyOnLoad (this);
			gameController = this;
		} else if (gameController != this) {
			this.inherit (gameController);
			Destroy (gameController.gameObject);
			gameController = this;
			DontDestroyOnLoad (this);
		}

		
		enemies = new List<Character> ();
		players = new List<Character> ();

		exit.SetActive (false);

	
	}
	// Use this for initialization
	void Start () {
		time = interval;
		GameController.gameController.addPlayer (p);
	}
	
	// Update is called once per frame
	void Update () {
		if (level.isFinished ()) {
			exit.SetActive (true);
		}
	}

	public List<Character> getEnemies(){
		return enemies;
	}

	public List<Character> getPlayers(){
		return players;
	}

	public void characterDead(Character c){
		if (c is Enemy) {
			enemies.Remove ((Enemy) c);
		}

		if (c is Player) {
			// Game Over
		}
	}

	public bool addEnemy(Enemy c){
		if (enemies.Contains (c))
			return false;
		enemies.Add (c);
		return true;
	}

	public bool addPlayer(Player c){
		if (players.Contains (c))
			return false;
		players.Add (c);
		return true;
	}



}
