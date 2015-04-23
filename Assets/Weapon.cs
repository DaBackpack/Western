using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float attack, shootSpeed;
	private float shootTimer;
	// Use this for initialization
	void Start () {
		shootTimer = shootSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		shootTimer += Time.deltaTime;
	}

	public bool shoot(){
		if (shootTimer >= shootSpeed) {
			shootTimer = 0;
			return true;
		}
		return false;
	}


}
