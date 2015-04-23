using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public float interval;
	private float time;

	// Use this for initialization
	void Start () {
		time = interval;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= interval) {
			GameObject enemy = (GameObject)Instantiate(Resources.Load("Enemy"));
			enemy.transform.position = new Vector3(Random.Range (-15, 15), 7, Random.Range (-15, 15));
			time = 0;
		}
	}
}
