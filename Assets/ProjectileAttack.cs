using UnityEngine;
using System.Collections;

public class ProjectileAttack {
	private Weapon weapon;
	private Targeter targeter; 
	private float power, accuracy;

	public ProjectileAttack(Weapon w, Targeter t, float powerBonus, float accuracyBonus){
		weapon = w;
		power = weapon.attack + powerBonus;
		accuracy = (accuracyBonus + 30.0f) * t.getVisibility ();
		if (accuracy >= 95.0f)
			accuracy = 95.0f;
		targeter = t;
	}

	bool accuracyCheck(){
		float randomEvent = Random.Range (0, 100);
		if (randomEvent <= accuracy)
			return true;
		return false;
	}

	public void attack(){
		if (accuracyCheck ())
			targeter.getTarget().receiveAttack (this);
	}

	public float getPower(){
		return power;
	}
}