using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
	float alive;
	// Use this for initialization
	void Start () {
		alive = 0;
	}
	
	// Update is called once per frame
	void Update () {
		alive += Time.deltaTime;
		if (alive >= 3) {
			Destroy (gameObject);
		}
	
	}

	void OnCollisionEnter(Collision c){

	}
}
