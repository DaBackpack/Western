using UnityEngine;
using System.Collections;

public class CloseWeapon : MonoBehaviour {

	float awakeTime;
	float delay;
	float attack;
	Renderer renderer;

	void Awake(){
		awakeTime = 0;
		delay = 1;
		attack = 10;
	}

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		renderer.enabled = false;
	}

	public float getAttack(){
		return attack;
	}

	// Update is called once per frame
	void Update () {
		if ((Input.GetKey (KeyCode.JoystickButton3) || Input.GetKey (KeyCode.V)) && awakeTime == 0) {
			renderer.enabled = true;
			print ("DUH");
			awakeTime += Time.deltaTime;
		}

		if (awakeTime > 0) {
			awakeTime += Time.deltaTime;
			if (awakeTime >= delay){
				awakeTime = 0;
				renderer.enabled = false;
			}
		}
	}

	void OnTriggerEnter(Collider c){
		/*if (renderer.enabled && c.gameObject.GetComponent<Rigidbody> () != null)
			c.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (100, 0, 0));
		*/
		Character cha = c.gameObject.GetComponent<Character> ();
		if (renderer.enabled && cha != null) {
			cha.receiveAttack(this);
		}
	}
}
