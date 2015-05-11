using UnityEngine;
using System.Collections;

public abstract class Level : MonoBehaviour {

 	protected int enemiesRemaining; 
	protected Vector3 startingPosition;

	protected virtual void Awake(){
		placePlayer (Player.player);
	}

	// Use this for initialization
	protected virtual void Start () {

	}

	protected void placePlayer(Player p){
		p.transform.position = startingPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public abstract bool isFinished();


}
