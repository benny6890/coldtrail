using UnityEngine;
using System.Collections;

public class EnemyRadar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	private void OnTriggerEnter2D (Collider2D other){
			Debug.Log (other.name);
		
		if (other.name == "bait") {
			
			transform.parent.GetComponent<EnemyMovement>().huntedPlayer = other.gameObject;
			transform.parent.GetComponent<EnemyMovement>().isHuntingPlayer = true;
			

		}
	}

}
