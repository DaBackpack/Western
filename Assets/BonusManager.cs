using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BonusManager : MonoBehaviour {

	List<Bonus> bonuses;
	// Use this for initialization
	void Awake (){
		bonuses = new List<Bonus> ();
		bonuses.Add (new Bonus ());
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float getTotalAccuracyBonus(){
		float accBonus = 0;
		foreach (Bonus x in bonuses) {
			accBonus += x.getAccuracyBonus ();
		}
		return accBonus;
	}

	public float getTotalEvaBonus(){
		float evaBonus = 0;
		foreach (Bonus x in bonuses) {
			evaBonus += x.getEvasionBonus ();
		}
		return evaBonus;
	}

	public float getTotalPowerBonus(){
		float powerBonus = 0;
		foreach (Bonus x in bonuses) {
			powerBonus += x.getPowerBonus ();
		}
		return powerBonus;
	}
	

}
