using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]

public class EnvironmentObject : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}

	public Collider getCollider(){
		return GetComponent<Collider>();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
