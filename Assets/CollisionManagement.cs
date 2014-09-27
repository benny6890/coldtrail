using UnityEngine;
using System.Collections;

public class CollisionManagement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter( Collider other) {

		Debug.Log ("Enter Collision");
		
		}


	private void OnTriggerExit( Collider other) {

		Debug.Log ("Exit Collision");

	}


	private void OnTriggerStay( Collider other) {

		Debug.Log ("Stay Collision");

	}



}
