using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print (Application.levelCount);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c){
		if (c.GetComponent<Player> () != null) {
			Application.LoadLevel((Application.loadedLevel + 1) % Application.levelCount);

		}
	}
}
