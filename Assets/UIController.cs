using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {
	public Player player; 
	public UnityEngine.UI.Text accText, enemyHPText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		accText.text = round(player.getHitPoints()) + "      " + round(player.getAccReading ()) + "      " + round(player.getEvaReading ());
		Character target = player.getTargeter ().getTarget ();
		if (target != null) {
			enemyHPText.text = "" +  round(player.getTargeter().getTarget ().getHitPoints ());
		} else {
			enemyHPText.text = "No enemy targeted.";
		}

	}

	private float round(float input){
		return (float)(System.Math.Round((double) input, 0));
	}
}
