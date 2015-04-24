using UnityEngine;
using System.Collections;

public abstract class Level : MonoBehaviour {

 	protected int enemiesRemaining; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public abstract bool isFinished();


}
