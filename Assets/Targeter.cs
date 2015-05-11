using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targeter : MonoBehaviour {

	private Transform position;
	protected Character target;
	private GameObject reticule;
	private List<Character> targetList;
	private int charIndex;

	void Awake(){
		if (reticule == null) {
			reticule = (GameObject)Instantiate (Resources.Load ("Reticule"));
		}
		position = transform.parent;


		charIndex = 0;
	}


	// Use this for initialization
	void Start () {
		findTargets ();
	}

	void findTargets(){

		if (transform.parent.gameObject.tag == "Player") {
			targetList = GameController.gameController.getEnemies ();
			
		} else {
			targetList = GameController.gameController.getPlayers();
		}

	}
	
	// Update is called once per frame
	void Update () {

		// If we are entering from another scene...
		if (reticule == null) {
			Awake ();
		}


		findTargets ();
		if (target == null) {
			changeTarget ();
			reticule.SetActive (false);
		}

		if (target != null) {
			reticule.SetActive (true);
			reticule.transform.position = target.transform.position;
		}
	}


	void targetObject(Character o){
		target = o;
	}

	public void changeTarget(){
		int size = targetList.Count;
		if (size == 0) {
			return;
		}

		charIndex++;
		if (charIndex >= size) {
			charIndex = -1;
			changeTarget ();
			return;
		} else
		if (targetList [charIndex] == null || targetList [charIndex].gameObject == null) {
			targetList.RemoveAt (charIndex);
			changeTarget ();
			return;
		} else {
			targetObject (targetList[charIndex]);
			return;
		}


	}

	public Transform getPosition(){
		return position;
	}

	// Returns a numerical representation of visiblity 
	public float getVisibility(){
		if (target == null)
			return -1;
		// First, we go through every Environment object in the scene. If there is an intersection, return 0.0f.
		Ray ray = new Ray (position.position, target.transform.position - position.position);
		EnvironmentObject[] objects = FindObjectsOfType<EnvironmentObject> ();
		float distance = 0;
		target.getCollider ().bounds.IntersectRay (ray, out distance);

		foreach (EnvironmentObject x in objects) {
			float record = 0;
			if (x.getCollider ().bounds.IntersectRay(ray, out record) && record < distance)
			    return 0.0f;
		}

		return (10.0f / distance) >= 1.0f ? 1.0f : 10.0f / distance;
	}

	public Character getTarget(){
		return target;
	}

	public void destroyReticule(){
		Destroy (reticule);
	}
}
