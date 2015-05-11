using UnityEngine;
using System.Collections;

public class Player : Character {
	public float speed, jumpSpeed, bulletSpeed;
	float accReading, evaReading; 
	private bool onGround; 
	public static Player player;

//TODO: Find out why multiple reticules are doing shit
	
	protected override void Awake(){
		base.Awake ();
		if (player == null) {
			player = this;
			DontDestroyOnLoad(gameObject);
		} else if (player != this) {
			this.targeter.destroyReticule ();
			Destroy (gameObject);
			print ("Called every scene");
		}

	}

	// Use this for initialization
	protected override void Start () {
		print ("Called EXACTLY ONCE EVER");
		base.Start ();
		onGround = false;


	}
	
	// Update is called once per frame
	void Update () {
	
		updateAccReading ();
		updateEvaReading ();


		//"Circle button" = retarget
		if (Input.GetKeyDown (KeyCode.C) || Input.GetKeyDown (KeyCode.JoystickButton1))
			targeter.changeTarget ();
	}

	void FixedUpdate(){
		float up = Input.GetAxis ("Vertical") * Time.deltaTime * speed;
		float right = Input.GetAxis ("Horizontal") * Time.deltaTime * speed;
		float fly = 0;
		Rigidbody rigbody = GetComponent<Rigidbody> ();

		// "X" button = jump
		if ((Input.GetKeyDown (KeyCode.JoystickButton0) || Input.GetKeyDown (KeyCode.X)) && onGround) {
			rigbody.AddForce (0, jumpSpeed, 0);
			onGround = false;
		}
		transform.Translate (right, fly, up);

		// "Square" button = shoot"
		if ((Input.GetKey(KeyCode.Z) || Input.GetKey (KeyCode.JoystickButton2)) && weapon.shoot ()){
			
			Vector3 position = targeter.getPosition ().position;

			if (targeter.getTarget() != null){
			Vector3 translation = targeter.getTarget().transform.position - position;
			translation.Normalize ();


			GameObject sphere = (GameObject)Instantiate(Resources.Load("Bullet"));
			sphere.transform.position = position + translation/2;
			translation *= bulletSpeed * Time.deltaTime;
			Rigidbody body = sphere.GetComponent<Rigidbody>();
			body.AddForce (translation);

			deliverAttack ();
			}

			else {
				Vector3 translation = new Vector3(1,0,0);
				GameObject sphere = (GameObject)Instantiate(Resources.Load("Bullet"));
				sphere.transform.position = position + translation/2;
				translation *= bulletSpeed * Time.deltaTime;
				Rigidbody body = sphere.GetComponent<Rigidbody>();
				body.AddForce (translation);
			}
		}
	}

	public float getAccReading() {
		return accReading;
	}

	public float getEvaReading() {
		return evaReading;
	}

	void updateAccReading(){
		if (targeter != null && targeter.getTarget() != null) {
			float temp = (30.0f + manager.getTotalAccuracyBonus()) * (targeter.getVisibility ()) * (100.0f - targeter.getTarget ().getDodgeChance ()) / 100;
			accReading = temp >= 95.0f ? 95.0f : temp;
		} else {
			accReading = -1;
		}
	}

	void updateEvaReading(){
		float visibility = targeter.getVisibility ();
		if (visibility == 0.0f) {
			evaReading = 100.0f;
			return;
		}
		float dodgeChance = getDodgeChance ();
		evaReading = dodgeChance >= 95.0f ? 95.0f : dodgeChance / visibility;
	}

	void OnCollisionEnter(Collision d){
		onGround = true;
	}

	public Targeter getTargeter(){
		return targeter;
	}

	public void heal(float amount){
		hitPoints += amount;
		if (hitPoints > maxHitPoints)
			hitPoints = maxHitPoints;
	}
}
