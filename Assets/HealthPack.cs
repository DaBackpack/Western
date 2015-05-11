using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour {
	float value; 

	// Use this for initialization
	void Start () {
		value = 15;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision c){
		Player p = c.gameObject.GetComponent<Player> ();
		if (p != null) {
			p.heal (value);
			Destroy (gameObject);
		}
	}
}
