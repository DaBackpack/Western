using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]

public class Character : MonoBehaviour {

	protected BonusManager manager;

	// Hit points and max hit points. 
	protected float hitPoints;
	public float maxHitPoints;

	// Targeter is pointing at a target. 
	protected Targeter targeter;

	// Weapon has power, attack speed, and accuracy.
	protected Weapon weapon;

	protected virtual void Awake(){
		if (targeter == null) {
			targeter = GetComponentInChildren<Targeter> ();
		}

		if (weapon == null)
			weapon = GetComponentInChildren<Weapon> ();

		manager = GetComponentInChildren<BonusManager> ();
	}

	public Collider getCollider(){
		return GetComponent<Collider>();
	}

	// Use this for initialization
	protected virtual void Start () {
		hitPoints = maxHitPoints;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void receiveAttack(ProjectileAttack attack){
		// We have a ProjectileAttack which has successfully connected with the player.
		// Now we determine what happens based on player evasion.

		// Base evasion is = 5.0f. 
		// quarterChance is the probability that the attack completely misses. 

		float quarterChance = getDodgeChance ();

		// From there, there are six outcomes: miss, 25%, 50%, 75%, 100% dmg, and crit (125% dmg).
		// These thresholds are equidistant from each other. 
		float halfDmg = (1 - quarterChance) / 5 + quarterChance;
		float threeQuarterDmg = 2* (1 - quarterChance) / 5 + quarterChance;
		float fullDmg = 3* (1 - quarterChance) / 5 + quarterChance;
		float critDmg = 4* (1 - quarterChance) / 5 + quarterChance;

		float randomEvent = Random.Range (0, 100);

		// No damage occurs. 
		if (randomEvent <= quarterChance) {
			attackDodged (attack);
			return;
		}
		if (randomEvent <= halfDmg) {
			quarterAttacked (attack);
			return;
		}
		if (randomEvent <= threeQuarterDmg) {
			halfAttacked (attack);
			return;
		}
		if (randomEvent <= fullDmg) {
			threeQuarterAttacked (attack);
			return;
		}
		if (randomEvent <= critDmg) {
			fullAttacked (attack);
			return;
		}

		critAttacked (attack);
		return;

	}

	protected virtual void deliverAttack(){
		if (weapon == null || targeter == null) {
			Debug.Log ("derp");
			return;
		}

		ProjectileAttack attack = new ProjectileAttack (weapon, targeter, manager.getTotalPowerBonus(), manager.getTotalAccuracyBonus());
		attack.attack ();
		return;
	}

	public float getDodgeChance(){
		return 5.0f + manager.getTotalEvaBonus (); 
	}

	protected virtual void attackDodged(ProjectileAttack p){
		return;
	}

	protected virtual void quarterAttacked(ProjectileAttack p){
		hitPoints -= p.getPower () / 4;
		if (hitPoints <= 0)
			die ();
	}

	protected virtual void halfAttacked(ProjectileAttack p){
		hitPoints -= 2 * p.getPower () / 4;
		if (hitPoints <= 0)
			die ();
	}

	protected virtual void threeQuarterAttacked(ProjectileAttack p){
		hitPoints -= 3 * p.getPower () / 4;
		if (hitPoints <= 0)
			die ();
	}

	protected virtual void fullAttacked(ProjectileAttack p){
		hitPoints -= p.getPower ();
		if (hitPoints <= 0)
			die ();
	}

	protected virtual void critAttacked(ProjectileAttack p){
		hitPoints -= 5* p.getPower() / 4;
		if (hitPoints <= 0)
			die ();
	}

	protected void die(){
		targeter.destroyReticule ();
		Destroy (gameObject);
		return;
	}

	public float getHitPoints(){
		return hitPoints;
	}
	
}
