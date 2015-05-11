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
	public GameObject exit;



	// Persistent data is passed to this Game Controller after the previous scene ends. 
	// The previous GameController is then destroyed in Awake().

	void dontDestroy(Transform c){
		DontDestroyOnLoad (this.gameObject);
		foreach (Transform child in c.transform){
			DontDestroyOnLoad (child.gameObject);
			dontDestroy (child);
		}
	}

	void Awake() {
		/*if (gameController == null) {
			DontDestroyOnLoad (gameObject);
			dontDestroy (transform);
			gameController = this;
		} else if (gameController != this) {
			//this.inherit (gameController);
			Destroy (gameObject);

		}

			*/		
		gameController = this;
		
		enemies = new List<Character> ();
		exit.SetActive (false);
		Player[] playerArr = FindObjectsOfType<Player> ();
		players = new List<Character>(playerArr);
	
	}
	// Use this for initialization
	void Start () {
		time = interval;
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
