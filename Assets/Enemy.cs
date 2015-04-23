using UnityEngine;
using System.Collections;

public class Enemy : Character {


	// Use this for initialization
	protected override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		if (weapon.shoot ()){
		Vector3 position = targeter.getPosition ().position;
		
		if (targeter.getTarget() != null){
			Vector3 translation = targeter.getTarget().transform.position - position;
			translation.Normalize ();
			
			
			GameObject sphere = (GameObject)Instantiate(Resources.Load("Bullet"));
			sphere.transform.position = position + translation/2;
			translation *= 40000 * Time.deltaTime;
			Rigidbody body = sphere.GetComponent<Rigidbody>();
			body.AddForce (translation);
			
			deliverAttack ();
			
			}
		}

	}
}