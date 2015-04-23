using UnityEngine;
using System.Collections;

public class Bonus {

	private float accuracyBonus = 10, evaBonus = 10, powerBonus = 10;

	protected virtual bool checkCondition(){
		return true;
	}

	public float getAccuracyBonus(){
		if (checkCondition ())
			return accuracyBonus;
		return 0;
	}

	public float getEvasionBonus(){
		if (checkCondition())
			return evaBonus;
		return 0;
	}

	public float getPowerBonus(){
		if (checkCondition())
			return powerBonus;
		return 0;
	}
}
